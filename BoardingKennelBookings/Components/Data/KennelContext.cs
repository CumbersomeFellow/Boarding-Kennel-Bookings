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
        public DbSet<BookingDogKennel> BookingDogKennel { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookingDogKennel>()
                .HasOne(bdk => bdk.Booking)
                .WithMany()
                .HasForeignKey(bdk => bdk.BookingID);
        }
    }

   
}
