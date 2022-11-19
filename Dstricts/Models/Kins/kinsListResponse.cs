using System.Collections.Generic;

namespace Dstricts.Models
{
    public class kinsListResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "last_name")]
        public string LastName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "created_on")]
        public string CreatedOn { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "country_phone_id")]
        public string CountryPhoneId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "connect_phone")]
        public string ConnectPhone { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "connect_by")]
        public int ConnectBy { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "country_phone")]
        public string CountryPhone { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "phone_number")]
        public string PhoneNumber { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "country_code")]
        public string CountryCode { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "uid")]
        public int Uid { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "is_missing")]
        public bool IsMissing { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "images")]
        public List<kinImages> Images { get; set; }

        public string ImgUrl { get; set; }
        //public string ImgUrl => Images?.Count > 0 ? Images[0].ImagePath : string.Empty;
    }

    public class kinImages
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "image_path")]
        public string ImagePath { get; set; }
    }
}
