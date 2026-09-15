namespace BoardingKennelBookings.Components.Models
{
    public class BookingForm
    {
        public Guid OwnerID { get; set; }
        public List<Guid> DogIDs { get; set; } = new List<Guid>();
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public bool AMPickup { get; set; }
        public bool AMDropoff { get; set; }
       
        public List<int> KennelIDs { get; set; } = new List<int>(); 
    }
}
