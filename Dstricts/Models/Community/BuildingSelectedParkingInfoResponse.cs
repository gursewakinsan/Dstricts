using System.Collections.Generic;

namespace Dstricts.Models
{
    public class BuildingSelectedParkingInfoResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "parking_open_month")]
        public string ParkingOpenMonth { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "parking_close_month")]
        public string ParkingCloseMonth { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "parking_hrs_sat_sun")]
        public bool IsParkingHrsSatSun { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "parking_hrs_sat_sun_open")]
        public string ParkingHrsSatSunOpen { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "parking_hrs_sat_sun_close")]
        public string ParkingHrsSatSunClose { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "parking_hrs_mon_fri")]
        public bool IsParkingHrsMonFri { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "parking_hrs_mon_fri_open")]
        public string ParkingHrsMonFriOpen { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "parking_hrs_mon_fri_close")]
        public string ParkingHrsMonFriClose { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "parking_description")]
        public string ParkingDescription { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "parking_number")]
        public string ParkingNumber { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "images")]
        public List<ParkingImage> Images { get; set; }
    }

    public class ParkingImage
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "image_path")]
        public string ImagePath { get; set; }
        public int ItemWidth { get; set; }
    }
}
