using Xamarin.Forms;

namespace Dstricts.Models
{
    public class ApartmentCommunityParkingsResponse : BaseModel
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "building_name")]
        public string BuildingName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "image_path")]
        public string ImagePath { get; set; }

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
