using Hl7.Fhir.Model;

namespace Netrika.FhirbaseNet2
{
    public static class FhirbaseStoreExtensions
    {
        public static T Create<T>(this IFhirbaseStore store, T resource) where T : Resource
        {
            return (T) store.Create((Resource) resource);
        }

        public static T Read<T>(this IFhirbaseStore store, ResourceKey key) where T : Resource
        {
            return (T) store.Read(key);
        }

        public static T VersionRead<T>(this IFhirbaseStore store, ResourceKey key) where T : Resource
        {
            return (T) store.VersionRead(key);
        }

        public static T Update<T>(this IFhirbaseStore store, T resource) where T : Resource
        {
            return (T) store.Update((Resource) resource);
        }

        public static T Delete<T>(this IFhirbaseStore store, ResourceKey key) where T : Resource
        {
            return (T) store.Delete(key);
        }
    }
}