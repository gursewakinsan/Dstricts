namespace Dstricts.Models
{
    public class AddCommunityTicketImageRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "problem_id")]
        public int ProblemId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "ImageData")]
        public string ImageData { get; set; }
    }
}
