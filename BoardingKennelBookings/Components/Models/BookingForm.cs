using System.ComponentModel.DataAnnotations;

namespace BoardingKennelBookings.Components.Models
{
    public class BookingForm
    {
        [Required(ErrorMessage = "Please select an owner")]
        public Guid? OwnerID { get; set; }
        
        [Required]
        public DateTime StartDate { get; set; }
        
        [Required]
        public DateTime EndDate { get; set; }
        
        [Required]
        public bool AMPickup { get; set; }

        [Required]
        public bool AMDropoff { get; set; }

        [Required(ErrorMessage = "Please select a kennel for each dog")]
        public Dictionary<Guid, int> DogKennelAssignments { get; set; } = new();

    }
}
