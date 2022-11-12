namespace Dstricts.Models
{
    public class TravelAppCompanyResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "tab_type")]
        public int TabType { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "front_display_name")]
        public string FrontDisplayName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "emergency_name")]
        public string EmergencyName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "sos_companies")]
        public System.Collections.Generic.List<SosCompany> SosCompanies { get; set; }
    }

    public class SosCompany
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
