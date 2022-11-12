namespace Dstricts.Models
{
    public class TravelAppCompanyLocationsResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "latitude")]
        public string Latitude { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "longitude")]
        public string Longitude { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "street_name_v")]
        public string StreetName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "city_v")]
        public string City { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "port_number")]
        public string PortNumber { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "postal_code_v")]
        public string PostalCode { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "country_v")]
        public string Country { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "langitude")]
        public string Langitude { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "distance")]
        public int Distance { get; set; }
    }
}
