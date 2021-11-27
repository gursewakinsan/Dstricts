using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Dstricts.Models
{
	public class CheckedInResponse : INotifyPropertyChanged
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "property_nickname")]
		public string PropertyNickName { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "address")]
		public string Address { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "enc")]
		public int Enc { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "qloud_checkout_id")]
		public int QloudCheckOutId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "image_path")]
		public string ImagePath { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "room_service")]
		public bool RoomService { get; set; }

		public string FirstLetterName => System.Globalization.StringInfo.GetNextTextElement(PropertyNickName, 0).ToUpper();

		private string firstLetterBg;
		public string FirstLetterBg
		{
			get => firstLetterBg;
			set
			{
				firstLetterBg = value;
				OnPropertyChanged("FirstLetterBg");
			}
		}

		private string firstLetterText;
		public string FirstLetterText
		{
			get => firstLetterText;
			set
			{
				firstLetterText = value;
				OnPropertyChanged("FirstLetterText");
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
