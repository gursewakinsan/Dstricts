﻿namespace Dstricts.Models
{
	public class CheckedInRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "dstricts_user_id")]
		public int UserId { get; set; }
	}
}
