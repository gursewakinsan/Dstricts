using Xamarin.Forms;
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

        [Newtonsoft.Json.JsonProperty(PropertyName = "community_eat_drink_amenity")]
        public List<ApartmentCommunity> CommunityEatDrinkAmenityList { get; set; }
    }

    public class ApartmentCommunity : BaseModel
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


        private bool isSelected;
        public bool IsSelected
        {
            get => isSelected;
            set
            {
                isSelected = value;
                if (isSelected)
                    ButtonBg = Color.FromHex("#45C366");
                else
                    ButtonBg = Color.FromHex("#242A37");
                OnPropertyChanged("IsSelected");
            }
        }

        private Color buttonBg;
        public Color ButtonBg
        {
            get => buttonBg;
            set
            {
                buttonBg = value;
                OnPropertyChanged("ButtonBg");
            }
        }
    }
}
