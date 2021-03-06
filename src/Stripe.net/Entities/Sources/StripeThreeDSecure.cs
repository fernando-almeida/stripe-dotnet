﻿namespace Stripe
{
    using Newtonsoft.Json;

    public class StripeThreeDSecure : StripeEntity
    {
        [JsonProperty("card")]
        public string CardId { get; set; }

        [JsonProperty("customer")]
        public string CustomerId { get; set; }

        [JsonProperty("authenticated")]
        public bool Authenticated { get; set; }
    }
}
