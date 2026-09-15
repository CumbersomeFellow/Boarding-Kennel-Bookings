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

        public bool AMDropoff { get; set; }

    }
}
