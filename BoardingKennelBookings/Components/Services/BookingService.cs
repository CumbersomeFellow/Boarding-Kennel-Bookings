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
        public async Task<List<Booking>> FindBookingsWithDateOwnerID(DateTime startDate, DateTime endDate, Guid OwnerID)
        {
            return await _context.Bookings.Where(booking => startDate <= booking.EndDate && endDate >= booking.StartDate && booking.OwnerID == OwnerID).ToListAsync();
        }
        public async Task<Booking> CreateBookingAsync(Booking booking)
        {
            _context.Bookings.Add(booking);

            await _context.SaveChangesAsync();

            return booking;
        }
        public async Task EditBooking(Booking updatedBooking)
        {
            var existingBooking = await _context.Bookings.FirstOrDefaultAsync(booking => booking.BookingID == updatedBooking.BookingID);

            if (existingBooking == null) return;

            existingBooking.StartDate = updatedBooking.StartDate;
            existingBooking.EndDate = updatedBooking.EndDate;
            existingBooking.AMDropoff = updatedBooking.AMDropoff;
            existingBooking.AMPickup = updatedBooking.AMPickup;

            await _context.SaveChangesAsync();
        }
        public async Task<BookingDogKennel> CreateBookingDogKennel(BookingDogKennel bookingDogKennel)
        {
            _context.BookingDogKennel.Add(bookingDogKennel);

            await _context.SaveChangesAsync();

            return bookingDogKennel;
        }

        public async Task<List<BookingDogKennel>> FindBookingDogKennelsWithBookingID(Guid bookingID)
        {
            return await _context.BookingDogKennel.Where(bdk => bookingID == bdk.BookingID).ToListAsync();
        }

        public async Task EditBookingDogKennels(BookingDogKennel updatedBDK)
        {            
            var existingBDK = await _context.BookingDogKennel.FirstOrDefaultAsync(bdk => bdk.BookingDogKennelID == updatedBDK.BookingDogKennelID);
            
            if (existingBDK == null) return;

            existingBDK.KennelID = updatedBDK.KennelID;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookingDogKennels(Guid bdkID)
        {
            var existingBDK = await _context.BookingDogKennel.FirstOrDefaultAsync(bdk => bdk.BookingDogKennelID == bdkID);

            if (existingBDK == null) return;

            _context.BookingDogKennel.Remove(existingBDK);

            await _context.SaveChangesAsync();
        }
    }
}
