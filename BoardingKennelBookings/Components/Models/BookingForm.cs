using System.ComponentModel.DataAnnotations;

namespace BoardingKennelBookings.Components.Models
{
    public class BookingForm
    {
        [Required(ErrorMessage = "Please select an owner")]
        public Guid? OwnerID { get; set; }

        [MinLength(1, ErrorMessage = "Please select at least one dog.")]
        public List<Guid> DogIDs { get; set; } = new List<Guid>();
        
        [Required]
        public DateTime StartDate { get; set; }
        
        [Required]
        public DateTime EndDate { get; set; }
        
        [Required]
        public bool AMPickup { get; set; }

        [Required]
        public bool AMDropoff { get; set; }

        [MinLength(1, ErrorMessage = "Please select at least one kennel.")]
        public List<int> KennelIDs { get; set; } = new List<int>();

        public Dictionary<Guid, int> DogKennelAssignments { get; set; } = new();

    }
}
