using BoardingKennelBookings.Components.Data;
using BoardingKennelBookings.Components.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BoardingKennelBookings.Components.Services
{
    public class KennelAvailabilityService
    {
        private readonly KennelContext _context;

        public KennelAvailabilityService(KennelContext context, BookingService bookingService, KennelService kennelService) 
        { 
            _context = context;
            this._bookingService = bookingService;
            this._kennelService = kennelService;
        }

        private readonly BookingService _bookingService;

        private readonly KennelService _kennelService;

        public async Task<bool> CheckKennelAvailability(DateTime startDate, DateTime endDate, int kennelID)
        {

            return false;
        }

        //check all kennels
        //add is clean check later - shouldnt be hard to implement right!?
        public async Task<List<Kennel>> GetAllKennelsAvailable(DateTime startDate, DateTime endDate)
        {
            List<Kennel> result = new List<Kennel>();

            //check bookings between date range
            //get booking IDs
            
            List<Booking> bookings = await _bookingService.FindBookingsWithInDateRange(startDate, endDate);
            List<Kennel> kennels = await _kennelService.GetAllKennels();
            List<BookingDogKennel> BookingDogKennelResult = new List<BookingDogKennel>();


            //filter bookingDogKennel with BookingDogKennels IDs
            //we now have all the kennel ids in use
            //list out all kennels that are not in use
            //check each kennel - if ID appears - remove from list
            if (bookings.Count > 0)
            {
                foreach (var booking in bookings)
                {
                    BookingDogKennelResult = _context.BookingDogKennel.Where(bookDogKennel => booking.BookingID == bookDogKennel.BookingID).ToList();
                }               
            }
           
            if(BookingDogKennelResult.Count > 0)
            {
                foreach (var BookingDogKennelSingle in BookingDogKennelResult)
                {
                    //i'll be able to shorten
                    if (!kennels.Contains(await _kennelService.GetKennel(BookingDogKennelSingle.KennelID))){
                        result.Add(await _kennelService.GetKennel(BookingDogKennelSingle.KennelID));
                    }
                }
            }

            return result; 
        }
    }
}
