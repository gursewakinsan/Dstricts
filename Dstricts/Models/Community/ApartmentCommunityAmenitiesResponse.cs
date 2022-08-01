using System.Collections.Generic;

namespace Dstricts.Models
{
    public class ApartmentCommunityAmenitiesResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "community_amenity")]
        public List<CommunityAmenity> CommunityAmenityList { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "book")]
        public List<ApartmentCommunityBook> BookList { get; set; }
    }

    public class ApartmentCommunityBook
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "amenity_name")]
        public string AmenityName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "image_path")]
        public string ImagePath { get; set; }

        public int ItemWidth { get; set; }
    }

    public class CommunityAmenity
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "amenity_name")]
        public string AmenityName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "image_path")]
        public string ImagePath { get; set; }

        public int ItemWidth { get; set; }
    }
}
