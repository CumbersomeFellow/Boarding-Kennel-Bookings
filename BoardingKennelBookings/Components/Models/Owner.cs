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

        public string? AddressLine1 {  get; set; }

        public string? AddressLine2 { get; set; }

        public string? TownCity { get; set; }
        public string? Postcode { get; set; }

        public List<Booking>? Bookings { get; set; }

        public List<Dog> Dogs { get; set; } = new List<Dog>();

        public Owner(string FirstName, string LastName, string Email, string ContactNumber, string? AddressLine1, string? AddressLine2, string? TownCity,string? postcode)
        {
            this.OwnerID = Guid.NewGuid();
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.ContactNumber = ContactNumber;
            this.AddressLine1 = AddressLine1;
            this.AddressLine2 = AddressLine2;
            this.TownCity = TownCity;
            this.Postcode = postcode;
        }

        public Owner() {}
    }
}
