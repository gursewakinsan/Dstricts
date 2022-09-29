using Xamarin.Forms;
using System.Collections.Generic;

namespace Dstricts.Models
{
    public class GetSratedDetailResponse : BaseModel
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "get_started_title")]
        public string GetStartedTitle { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "switch_on")]
        public bool IsSwitchOn { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "get_started_description")]
        public string GetStartedDescription { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "mannual_image")]
        public string MannualImage { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "images")]
        public List<GetSratedImage> Images { get; set; }

        public string DisplayGetStartedTitle => $"{GetStartedTitle}{System.Environment.NewLine}on & Off";

        public string ButtonTextIcon { get; set; }

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

    public class GetSratedImage
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "image_path")]
        public string ImagePath { get; set; }
    }
}
