using BoardingKennelBookings.Components.Data;
using BoardingKennelBookings.Components.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BoardingKennelBookings.Components.Services
{
    public class KennelAvailabilityService
    {
        private readonly KennelContext _context;

        public KennelAvailabilityService(KennelContext context) 
        { 
            _context = context;
        }

        private readonly BookingService bookingService;

        private readonly KennelService kennelService;

        public async Task<bool> CheckKennelAvailability(DateTime startDate, DateTime endDate, int kennelID)
        {

            return false;
        }

        //check all kennels
        //add is clean check later - shouldnt be hard to implement right!?
        public async Task<List<Kennel>>? GetAllKennelsAvailable(DateTime startDate, DateTime endDate)
        {
            List<Kennel> result = new List<Kennel>();

            //check bookings between date range
            //get booking IDs
            
            List<Booking> bookings = await bookingService.FindBookingsWithInDateRange(startDate, endDate);
            List<Kennel> kennels = await kennelService.GetAllKennels();
            List<BookingDogKennel> BookingDogKennelResult = null;


            //filter bookingDogKennel with BookingDogKennels IDs
            //we now have all the kennel ids in use
            //list out all kennels that are not in use
            //check each kennel - if ID appears - remove from list
            if (bookings != null)
            {
                foreach (var booking in bookings)
                {
                    BookingDogKennelResult = _context.BookingDogKennel.Where(bookDogKennel => booking.BookingID == bookDogKennel.BookingID).ToList();
                }               
            }
           
            if(BookingDogKennelResult != null)
            {
                foreach (var BookingDogKennelSingle in BookingDogKennelResult)
                {
                    //this check and add i'll be able to shorten
                    if (!kennels.Contains(await kennelService.GetKennel(BookingDogKennelSingle.KennelID))){
                        result.Add(await kennelService.GetKennel(BookingDogKennelSingle.KennelID));
                    }
                }
            }

            return result; 
        }
    }
}
