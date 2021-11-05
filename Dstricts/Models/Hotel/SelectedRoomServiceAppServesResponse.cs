using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Dstricts.Models
{
	public class SelectedRoomServiceAppServesResponse : INotifyPropertyChanged
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "serve_type")]
		public int ServeType { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "serve_info")]
		public string ServeInfo { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "serve_image")]
		public string ServeImage { get; set; }

		public double ImgWidth { get; set; }
		public double ImgHeight { get; set; }
		
		private bool isSelectedRoomService = false;
		public bool IsSelectedRoomService
		{
			get => isSelectedRoomService;
			set
			{
				isSelectedRoomService = value;
				OnPropertyChanged("IsSelectedRoomService");
				OnPropertyChanged("SelectedRoomServiceBg");
			}
		}


		private Xamarin.Forms.Color selectedRoomServiceBg;
		public Xamarin.Forms.Color SelectedRoomServiceBg
		{
			get => selectedRoomServiceBg;
			set
			{
				/*if (IsSelectedRoomService)
					value = Xamarin.Forms.Color.FromHex("#6263ED");
				else
					value = Xamarin.Forms.Color.FromHex("#2A2A31");*/
				selectedRoomServiceBg = value;
				OnPropertyChanged("SelectedRoomServiceBg");
			}
		}

		#region On Property Changed.
		public event PropertyChangedEventHandler PropertyChanged;
		public virtual void OnPropertyChanged([CallerMemberName] string name = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}
		#endregion
	}
}
