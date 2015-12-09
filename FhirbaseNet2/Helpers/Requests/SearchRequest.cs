using System;
using Newtonsoft.Json;

namespace Netrika.FhirbaseNet2.Helpers.Requests
{
    internal class SearchRequest
    {
        [JsonProperty("resourceType")]
        public String ResourceType { get; set; }

        [JsonProperty("queryString")]
        public String SearchQuery { get; set; }

        public String ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}