namespace Dstricts.Models
{
	public class GuestServices : BaseModel
	{
		public int Id { get; set; }
		public string ServiceName { get; set; }
		public double ImgWidth { get; set; }
		public double ImgHeight { get; set; }

		private bool isSelected = false;
		public bool IsSelected
		{
			get => isSelected;
			set
			{
				isSelected = value;
				OnPropertyChanged("IsSelected");
			}
		}

		private Xamarin.Forms.Color selectedServiceBg;
		public Xamarin.Forms.Color SelectedServiceBg
		{
			get => selectedServiceBg;
			set
			{
				selectedServiceBg = value;
				OnPropertyChanged("SelectedServiceBg");
			}
		}

        public string AmenitiesIcons { get; set; }
    }
}
