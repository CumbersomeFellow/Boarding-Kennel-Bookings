using BoardingKennelBookings.Components.Data;
using BoardingKennelBookings.Components.Models;
using Microsoft.EntityFrameworkCore;

namespace BoardingKennelBookings.Components.Services
{
    public class BookingService
    {
        private readonly KennelContext _context;

        public BookingService(KennelContext context)
        {
            _context = context;
        }

        public async Task<List<Booking>> FindBookingsWithInDateRange(DateTime startDate, DateTime endDate)
        {
            return await _context.Bookings.Where(booking => startDate <= booking.EndDate && endDate >= booking.StartDate).ToListAsync();
        }

        public async Task<Booking> CreateBookingAsync(Booking booking)
        {
            _context.Bookings.Add(booking);

            await _context.SaveChangesAsync();

            return booking;
        }
        public async Task<BookingDogKennel> CreateBookingDogKennel(BookingDogKennel bookingDogKennel)
        {
            _context.BookingDogKennel.Add(bookingDogKennel);

            await _context.SaveChangesAsync();

            return bookingDogKennel;
        }
    }
}
