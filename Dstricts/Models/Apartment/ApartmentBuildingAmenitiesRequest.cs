namespace Dstricts.Models
{
    public class ApartmentBuildingAmenitiesRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "building_id")]
        public int BuildingId { get; set; }
    }
}
