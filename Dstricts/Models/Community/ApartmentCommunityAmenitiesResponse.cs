using System.Collections.Generic;

namespace Dstricts.Models
{
    public class ApartmentCommunityAmenitiesResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "community_amenity")]
        public List<ApartmentCommunity> CommunityAmenityList { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "book")]
        public List<ApartmentCommunity> BookList { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "community_children_amenity")]
        public List<ApartmentCommunity> CommunityChildrenAmenityList { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "building_amenity")]
        public List<ApartmentCommunity> BuildingAmenityList { get; set; }
    }

    public class ApartmentCommunity
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "amenity_name")]
        public string AmenityName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "image_path")]
        public string ImagePath { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "adult_amenity")]
        public int AdultAmenity { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "community")]
        public int Community { get; set; }

        public int ItemWidth { get; set; }
    }
}
