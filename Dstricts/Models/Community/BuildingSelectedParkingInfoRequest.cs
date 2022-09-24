namespace Dstricts.Models
{
    public class BuildingSelectedParkingInfoRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "building_id")]
        public int BuildingId { get; set; }
    }
}
