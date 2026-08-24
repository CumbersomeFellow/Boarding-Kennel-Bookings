namespace BoardingKennelBookings.Components.Models
{
    public class Dog
    {
        public string DogName { get; set; }
        public Guid ID { get; set; }

        public string Breed { get; set; }

        public List<Booking>? Bookings { get; set; }

        public string? VacinationCertificateImage { get; set; }

        public Guid OwnerID { get; set; }

        public Owner Owner { get; set; }

        public Dog(string DogName, string Breed) {
            this.DogName = DogName;
            this.Breed = Breed;
            
        }   

        public Dog() { }
    }
}
