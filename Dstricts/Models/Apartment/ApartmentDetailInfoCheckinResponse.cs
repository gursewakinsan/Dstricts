namespace Dstricts.Models
{
    public class ApartmentDetailInfoCheckinResponse : BaseModel
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "property_nickname")]
        public string PropertyNickname { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "name_on_house")]
        public string NameOnHouse { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
        public int UserId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "is_owner")]
        public bool IsOwner { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "qloud_checkout_id")]
        public string QloudCheckoutId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "owner_checked_in")]
        public int OwnerCheckedIn { get; set; }

        public string DisplayName => string.IsNullOrWhiteSpace(PropertyNickname) ? NameOnHouse : PropertyNickname;

        [Newtonsoft.Json.JsonProperty(PropertyName = "passport_count")]
        private bool passportCount;
        public bool PassportCount
        {
            get => passportCount;
            set
            {
                passportCount = value;
                OnPropertyChanged("PassportCount");
            }
        }

       [Newtonsoft.Json.JsonProperty(PropertyName = "card_count")]
        
        private bool cardCount;
        public bool CardCount
        {
            get => cardCount;
            set
            {
                cardCount = value;
                OnPropertyChanged("CardCount");
            }
        }
    }
}
