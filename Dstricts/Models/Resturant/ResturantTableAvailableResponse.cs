using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Dstricts.Models
{
	public class ResturantTableAvailableResponse : INotifyPropertyChanged
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "work_time")]
		public string WorkTime { get; set; }
		public bool IsSelected { get; set; }

		private Xamarin.Forms.Color selectedWorkTimeBg;
		public Xamarin.Forms.Color SelectedWorkTimeBg
		{
			get => selectedWorkTimeBg;
			set
			{
				selectedWorkTimeBg = value;
				OnPropertyChanged("SelectedWorkTimeBg");
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
