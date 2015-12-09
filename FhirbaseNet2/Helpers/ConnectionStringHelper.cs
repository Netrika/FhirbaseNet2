using System.Configuration;

namespace Netrika.FhirbaseNet2.Helpers
{
    internal static class ConnectionStringHelper
    {
        public static string GetConnectionString(string nameOrConnectionString)
        {
            var connectionString = "";

            if (nameOrConnectionString.IndexOf('=') >= 0)
            {
                connectionString = nameOrConnectionString;
            }
            else
            {
                connectionString = ConfigurationManager.ConnectionStrings[nameOrConnectionString].ConnectionString;
            }
            return connectionString;
        }
    }
}