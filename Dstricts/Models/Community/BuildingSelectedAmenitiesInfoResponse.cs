using System.Collections.Generic;

namespace Dstricts.Models
{
    public class BuildingSelectedAmenitiesInfoResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "amenity_id")]
        public int AmenityId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "amenity_open_month")]
        public string AmenityOpenMonth { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "amenity_close_month")]
        public string AmenityCloseMonth { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "amenity_hrs_sat_sun")]
        public bool IsAmenityHrsSatSun { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "amenity_hrs_sat_sun_open")]
        public string AmenityHrsSatSunOpen { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "amenity_hrs_sat_sun_close")]
        public string AmenityHrsSatSunClose { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "amenity_hrs_mon_fri")]
        public bool IsAmenityHrsMonFri { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "amenity_hrs_mon_fri_open")]
        public string AmenityHrsMonFriOpen { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "amenity_hrs_mon_fri_close")]
        public string AmenityHrsMonFriClose { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "app_display")]
        public int AppDisplay { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "is_available")]
        public bool IsAvailable { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "amenity_name")]
        public string AmenityName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "amenity_description")]
        public string AmenityDescription { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "images")]
        public List<AmenityImage> Images { get; set; }
    }

    public class AmenityImage
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "image_path")]
        public string ImagePath { get; set; }

        public int ItemWidth { get; set; }
    }
}
