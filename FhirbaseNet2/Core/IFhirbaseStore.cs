using System;
using Hl7.Fhir.Model;
using Netrika.FhirbaseNet2.Helpers;

namespace Netrika.FhirbaseNet2
{
    public interface IFhirbaseStore
    {
        Resource Create(Resource resource);
        Resource Read(ResourceKey key);
        Resource VersionRead(ResourceKey key);
        Resource Update(Resource resource);
        Resource Delete(ResourceKey key);

     
        Bundle ResourceHistory(string resourceType, string resourceID, HistoryParameters parameters = null);
        Bundle ResourceTypeHistory(string resourceType, HistoryParameters parameters = null);
        Bundle AllResourcesHistory(HistoryParameters parameters = null);

        Bundle Search(string resourceType, SearchParameters parameters = null);

        Bundle Transaction(Bundle bundle);
        Boolean IsExists(ResourceKey key);
        Boolean IsExists(Resource resource);
        Boolean IsExists(string resourceName, string id);
        Boolean IsDeleted(ResourceKey key);
        Boolean IsLatest(ResourceKey key);
    }
}