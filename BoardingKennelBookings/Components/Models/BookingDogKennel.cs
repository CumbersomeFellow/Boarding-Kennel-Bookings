namespace BoardingKennelBookings.Components.Models
{
    public class BookingDogKennel
    {
        public Guid BookingDogKennelID { get; set; }
        public Guid BookingID { get; set; }
        public Booking? Booking { get; set; }

        public Guid DogID { get; set; }

        public int KennelID { get; set; }
    }
}
