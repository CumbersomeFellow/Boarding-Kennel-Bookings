using System.ComponentModel.DataAnnotations;

namespace BoardingKennelBookings.Components.Models
{
    public class Kennel
    {
        public int KennelID { get; set; }

        [Required(ErrorMessage = "Number is required")]
        public int KennelNumber { get; set; }

        public List<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
