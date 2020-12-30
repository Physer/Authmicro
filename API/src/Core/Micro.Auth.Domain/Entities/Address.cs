namespace Micro.Auth.Domain.Entities
{
    public class Address
    {
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public Geolocation Geo { get; set; }
    }
}
