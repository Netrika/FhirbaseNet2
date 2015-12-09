using System;

namespace Netrika.FhirbaseNet2.DataModel
{
    internal static class FhirSchema
    {
        public static readonly String Name = "public";

        public static class Func
        {
            public static readonly String IsExists = "is_exists";

            public static readonly String IsDeleted = "is_deleted";

            public static readonly String IsLatest = "is_latest";

            public static readonly String Create = "fhir_create_resource";

            public static readonly String Read = "fhir_read_resource";

            public static readonly String VRead = "fhir_vread_resource";

            public static readonly String Update = "fhir_update_resource";

            public static readonly String Delete = "fhir_delete_resource";

            public static readonly String InstanceHistory = "fhir_resource_history";

            public static readonly String TypeHistory = "fhir_resource_type_history";

            public static readonly String Search = "fhir_search";

            public static readonly String GenTables = "generate_tables";

            public static readonly String Conformance = "conformance";

            public static readonly String StructureDefinition = "structuredefinition";

            public static readonly String Transaction = "fhir_transaction";

            public static readonly String IndexSearchParam = "index_search_param";

            public static readonly String DropIndexSearchParam = "drop_index_search_param";

            public static readonly String IndexResource = "index_resource";

            public static readonly String DropResourceIndexes = "drop_resource_indexes";

            public static readonly String IndexAllResources = "index_all_resources";

            public static readonly String DropAllResourceIndexes = "drop_all_resource_indexes";

            public static readonly String AdminDiskUsageTop = "admin_disk_usage_top";
        }
    }
}