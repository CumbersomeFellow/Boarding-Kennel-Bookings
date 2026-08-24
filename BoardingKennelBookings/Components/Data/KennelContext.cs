using BoardingKennelBookings.Components.Models;
using Microsoft.EntityFrameworkCore;

namespace BoardingKennelBookings.Components.Data
{
    public class KennelContext : DbContext
    {
        public KennelContext(DbContextOptions<KennelContext> options)
            : base(options)
        {
        }

        public DbSet<Dog> Dogs { get; set; }

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Owner> Owners { get; set; }

        public DbSet<Kennel> Kennels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
                .HasMany(booking => booking.Dogs)
                .WithMany(d => d.Bookings)
                .UsingEntity<Dictionary<string, object>>(
                    "BookingDog",
                    j => j
                        .HasOne<Dog>()
                        .WithMany()
                        .HasForeignKey("DogsID")
                        .OnDelete(DeleteBehavior.NoAction),
                    j => j
                        .HasOne<Booking>()
                        .WithMany()
                        .HasForeignKey("BookingsBookingID")
                        .OnDelete(DeleteBehavior.Cascade));
        }
    }

   
}
