using System;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;

namespace Netrika.FhirbaseNet2.Helpers
{
    internal static class ResourceDataHelper
    {
        public static string FhirResourceToJson(Resource entry)
        {
            return FhirSerializer.SerializeResourceToJson(entry);
        }

        public static Resource JsonToFhirResource(string json)
        {
            try
            {
                return FhirParser.ParseResourceFromJson(json);
            }
            catch (Exception inner)
            {
                throw new FhirbaseException("Cannot parse Fhirbase's json into a feed entry: ", inner);
            }
        }

        public static Bundle JsonToBundle(string json)
        {
            var bundle = FhirParser.ParseFromJson(json);

            return (Bundle) bundle;
        }
    }
}
