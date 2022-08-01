using System.Collections.Generic;

namespace Dstricts.Models
{
    public class GetCommunityDetailInfoResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "society_name")]
        public string SocietyName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "created_on")]
        public string CreatedOn { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "company_id")]
        public int CompanyId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "street_address")]
        public string StreetAddress { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "port_number")]
        public string PortNumber { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "zipcode")]
        public string ZipCode { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "city")]
        public string City { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "country_id")]
        public int CountryId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "phone_country_id")]
        public int PhoneCountryId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "phone_number")]
        public string PhoneNumber { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "entry_type")]
        public int EntryType { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "entry_code")]
        public string EntryCode { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "wifi_available")]
        public int WifiAvailable { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "wifi_username")]
        public string WifiUsername { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "wifi_password")]
        public string WifiPassword { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "images")]
        public List<GetCommunityDetailInfoImage> ImagesList { get; set; }
    }

    public class GetCommunityDetailInfoImage
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "building_photo_path")]
        public string BuildingPhotoPath { get; set; }
        public int ImgWidth { get; set; }
    }
}
