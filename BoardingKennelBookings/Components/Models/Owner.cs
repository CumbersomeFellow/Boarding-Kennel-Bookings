using Microsoft.Identity.Client;

namespace BoardingKennelBookings.Components.Models
{
    public class Owner
    {
        public Guid OwnerID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; } 

        public List<Booking>? Bookings { get; set; }

        public List<Dog> Dogs { get; set; } = new List<Dog>();

        public Owner(string FirstName, string LastName, string Email, string ContactNumber) {
            this.OwnerID = Guid.NewGuid();
            this.FirstName = FirstName;
            this.LastName = LastName;   
            this.Email = Email;
            this.ContactNumber = ContactNumber;
        }

        public Owner() {}
    }
}
