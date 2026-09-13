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

        public async Task<List<Kennel>> GetAllKennelsAvailable(DateTime startDate, DateTime endDate)
        {
            List<Kennel> result = new List<Kennel>();
            List<Booking> bookings = await _bookingService.FindBookingsWithInDateRange(startDate, endDate);
            List<Kennel> kennels = await _kennelService.GetAllKennels();
            List<BookingDogKennel> BookingDogKennelResult = new List<BookingDogKennel>();

            if (bookings.Count > 0)
            {
                foreach (var booking in bookings)
                {
                    BookingDogKennelResult = _context.BookingDogKennel.Where(bookDogKennel => booking.BookingID == bookDogKennel.BookingID).ToList();
                }               
            }
           
            if(BookingDogKennelResult.Count > 0)
            {
                foreach (var kennel in kennels)
                {
                    foreach (var BookingDogKennelSingle in BookingDogKennelResult)
                    {
                        if (BookingDogKennelSingle.KennelID != kennel.KennelID)
                        {
                            result.Add(kennel);
                        }
                    }
                }
            }
            else
            {
                result = kennels;
            }

            return result; 
        }
    }
}
