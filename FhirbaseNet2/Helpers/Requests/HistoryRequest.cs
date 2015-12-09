using System;
using Newtonsoft.Json;

namespace Netrika.FhirbaseNet2.Helpers.Requests
{
    internal class HistoryRequest
    {
        [JsonProperty("id")]
        public String ID { get; set; }

        [JsonProperty("resourceType")]
        public String ResourceType { get; set; }

        [JsonProperty("queryString")]
        public String Query { get; set; }

        public String ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}