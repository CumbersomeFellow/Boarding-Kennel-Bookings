namespace BoardingKennelBookings.Components.Models
{
    public class BookingForm
    {
        public Guid OwnerID { get; set; }
        public List<Dog> Dogs  { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public bool AMPickup { get; set; }
        public bool PMPickup { get; set; }
        public bool AMDropoff { get; set; }
        public bool PMDropoff { get; set; }

        public List<int> KennelIDs { get; set; }
    }
}
