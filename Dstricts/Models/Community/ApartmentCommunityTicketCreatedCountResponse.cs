namespace Dstricts.Models
{
    public class ApartmentCommunityTicketCreatedCountResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "new_ticket")]
        public int NewTicket { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "ongoing_ticket")]
        public int OngoingTicket { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "finished_ticket")]
        public int FinishedTicket { get; set; }
    }
}
