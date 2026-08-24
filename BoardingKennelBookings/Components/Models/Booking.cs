namespace BoardingKennelBookings.Components.Models
{
    public class Booking
    {
        public Guid BookingID { get; set; }
        public Guid OwnerID { get; set; }
        public Owner Owner { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool AMPickup { get; set; }
        public bool PMPickup { get; set; }
        public bool AMDropoff { get; set; }
        public bool PMDropoff { get; set; }
        
        public List<Dog> Dogs { get; set; } = new List<Dog>();
        //means create an empty list automatically when the object is created.
        //should i change this to just dogIDs?

        public List<Kennel> Kennels { get; set; } = new List<Kennel>();
        //attach the kennel to the booking - So I'll need to store a kennel ID.
        //right now im just listing all kennels to a booking.
        //a booking COULD have mutliple kennels

        public Booking()
        {

        }
    }
}
