using System;
using System.Linq;
using Hl7.Fhir.Model;
using Monads.NET;
using Netrika.FhirbaseNet2.DataModel;
using Netrika.FhirbaseNet2.Helpers;
using Netrika.FhirbaseNet2.Helpers.Requests;

namespace Netrika.FhirbaseNet2
{
    public class FhirbaseStore : IFhirbaseStore
    {
        private readonly FhirbaseContext _context;

        public FhirbaseStore(string nameOrConnectionString)
        {
            if (String.IsNullOrEmpty(nameOrConnectionString))
            {
                throw new ArgumentException("Connection string or connection string name must be specified",
                    nameof(nameOrConnectionString));
            }

            var connectionString = ConnectionStringHelper.GetConnectionString(nameOrConnectionString);

            _context = new FhirbaseContext(connectionString);
        }

        #region :: CRUD ::

        public Resource Create(Resource resource)
        {
            var resourceJson = ResourceDataHelper.FhirResourceToJson(resource);

            var createdResourceJson = _context
                .Call(FhirSchema.Name, FhirSchema.Func.Create)
                .WithJson(resourceJson)
                .Cast<String>();

            var createdResource = ResourceDataHelper.JsonToFhirResource(createdResourceJson);

            return createdResource;
        }

        public Resource Read(ResourceKey key)
        {
            var resourceJson = _context
                .Call(FhirSchema.Name, FhirSchema.Func.Read)
                .WithJson(key.ToJson())
                .Cast<String>();

            var resource = ResourceDataHelper.JsonToFhirResource(resourceJson);

            return resource;
        }
        
        public Resource VersionRead(ResourceKey key)
        {
            var resourceJson = _context
                .Call(FhirSchema.Name, FhirSchema.Func.VRead)
                .WithJson(key.ToJson())
                .Cast<String>();

            var resource = ResourceDataHelper.JsonToFhirResource(resourceJson);

            return resource;
        }
        
        public Resource Update(Resource resource)
        {
            var resourceJson = ResourceDataHelper.FhirResourceToJson(resource);

            var updatedResourceJson = _context
                .Call(FhirSchema.Name, FhirSchema.Func.Update)
                .WithJson(resourceJson)
                .Cast<string>();

            var updatedResource = ResourceDataHelper.JsonToFhirResource(updatedResourceJson);

            return updatedResource;
        }
        
        public Resource Delete(ResourceKey key)
        {
            var resourceJson = _context
                .Call(FhirSchema.Name, FhirSchema.Func.Delete)
                .WithJson(key.ToJson())
                .Cast<String>();

            var deletedResource = ResourceDataHelper.JsonToFhirResource(resourceJson);

            return deletedResource;
        }

        #endregion

        #region :: History :: 

        /// <summary>
        /// Retrieve the update history for a particular resource
        /// </summary>
        /// <param name="resourceType"></param>
        /// <param name="resourceID"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Bundle ResourceHistory(string resourceType, string resourceID, HistoryParameters parameters = null)
        {
            if (parameters == null)
            {
                parameters = HistoryParameters.Empty;
            }

            var request = new HistoryRequest()
            {
                ResourceType = resourceType,
                ID = resourceID,
                Query = parameters.ToString()
            };

            var historyResponse = _context.Call(FhirSchema.Name, FhirSchema.Func.InstanceHistory)
                .WithJson(request.ToJson())
                .Cast<String>();

            var resultBundle = ResourceDataHelper.JsonToBundle(historyResponse);

            return resultBundle;
        }

        public Bundle ResourceTypeHistory(string resourceType, HistoryParameters parameters = null)
        {
            if (parameters == null)
            {
                parameters = HistoryParameters.Empty;
            }

            var request = new HistoryRequest()
            {
                ResourceType = resourceType,
                Query = parameters.ToString()
            };
            
            var historyResponse = _context.Call(FhirSchema.Name, FhirSchema.Func.TypeHistory)
                .WithJson(request.ToJson())
                .Cast<String>();

            var resultBundle = ResourceDataHelper.JsonToBundle(historyResponse);

            return resultBundle;
        }

        public Bundle AllResourcesHistory(HistoryParameters parameters = null)
        {
            if (parameters == null)
            {
                parameters = HistoryParameters.Empty;
            }

            var historyResponse = _context.Call(FhirSchema.Name, FhirSchema.Func.InstanceHistory)
                .WithString(parameters.ToString())
                .Cast<String>();

            var resultBundle = ResourceDataHelper.JsonToBundle(historyResponse);

            return resultBundle;
        }

        #endregion

        #region :: Search ::

        public Bundle Search(string resourceType, SearchParameters parameters = null)
        {
            if (parameters == null)
            {
                parameters = SearchParameters.Empty;
            }

            var searchQuery = parameters.ToString();

            var request = new SearchRequest()
            {
                ResourceType = resourceType,
                SearchQuery = searchQuery
            };

            var jsonValue = request.ToJson();

            var searchResult = _context.Call(FhirSchema.Name, FhirSchema.Func.Search)
                .WithJson(jsonValue)
                .Cast<String>();

            var resultBundle = ResourceDataHelper.JsonToBundle(searchResult);

            return resultBundle;
        }

        #endregion

        #region :: Transactions ::

        public Bundle Transaction(Bundle bundle)
        {
            var transactionJson = ResourceDataHelper.FhirResourceToJson(bundle);

            var fhirbaseResult = _context.Call(FhirSchema.Name, FhirSchema.Func.Transaction)
                .WithJson(transactionJson)
                .Cast<String>();

            var transactionResult = ResourceDataHelper.JsonToBundle(fhirbaseResult);

            return transactionResult;
        }

        #endregion

        #region :: Resource Utility ::

        public Boolean IsExists(ResourceKey key)
        {
            var resource = Read(key);

            return resource != null;
        }

        public Boolean IsExists(Resource resource)
        {
            throw new NotSupportedException();

            //return resource != null
            //    && !String.IsNullOrEmpty(resource.TypeName)
            //    && !String.IsNullOrEmpty(resource.Id)
            //    && IsExists(resource.TypeName, resource.Id);
        }

        public Boolean IsExists(string resourceName, string id)
        {
            throw new NotSupportedException();

            //return _context.Call(FhirSchema.Name, FhirSchema.Func.IsExists)
            //    .WithString(resourceName)
            //    .WithString(id)
            //    .Cast<Boolean>();
        }

        public Boolean IsDeleted(ResourceKey key)
        {
            throw new NotSupportedException();

            //return _context.Call(FhirSchema.Name, FhirSchema.Func.IsDeleted)
            //    .WithString(key.ResourceType)
            //    .WithString(key.ID)
            //    .Cast<Boolean>();
        }

        public Boolean IsLatest(ResourceKey key)
        {
            throw new NotSupportedException();

            //var result = _context.Call(FhirSchema.Name, FhirSchema.Func.IsLatest)
            //   .WithString(key.ResourceType)
            //   .WithString(key.ID)
            //   .WithString(key.VersionID)
            //   .Cast<Boolean>();

            //return result;
        }

        #endregion
    }
}
