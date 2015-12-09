using System;
using Hl7.Fhir.Model;
using Newtonsoft.Json;

namespace Netrika.FhirbaseNet2
{
    public class ResourceKey
    {
        /// <summary>
        /// Resource id.
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; }

        /// <summary>
        /// Type name of Resource.
        /// </summary>
        [JsonProperty("resourceType")]
        public string ResourceType { get; set; }

        /// <summary>
        /// Version id.
        /// </summary>
        [JsonProperty("versionId")]
        public string VersionID { get; set; }

        public static implicit operator ResourceKey(Resource resource)
        {
            return new ResourceKey
            {
                ID = resource.Id,
                ResourceType = resource.TypeName,
                VersionID = resource.VersionId
            };
        }
        
        public String ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}