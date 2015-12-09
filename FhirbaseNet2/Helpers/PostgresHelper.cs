using System;
using System.Data;
using Npgsql;
using NpgsqlTypes;

namespace Netrika.FhirbaseNet2.Helpers
{
    internal static class PostgresHelper
    {
        public static object Function(string connectionString, string functionName, params NpgsqlParameter[] parameters)
        {
            var npgsqlConnection = OpenConnection(connectionString);

            try
            {
                var command = new NpgsqlCommand(functionName, npgsqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                
                command.Parameters.AddRange(parameters);
                
                var result = command.ExecuteScalar();

                return result;
            }
            catch (Exception ex)
            {
                throw new FhirbaseException(
                    $"Call {functionName} FHIRbase function failed. Reason {ex.Message}",
                    ex);
            }
            finally
            {
                npgsqlConnection.Close();
            }
        }

        private static NpgsqlConnection OpenConnection(string connectionString)
        {
            var npgsqlConnection = new NpgsqlConnection(connectionString);

            npgsqlConnection.Open();

            InitConnection(npgsqlConnection);

            return npgsqlConnection;
        }

        private static void InitConnection(NpgsqlConnection npgsqlConnection)
        {
            var cmd = npgsqlConnection.CreateCommand();

            cmd.CommandText = "SET plv8.start_proc = 'plv8_init'";

            cmd.ExecuteNonQuery();
        }

        public static NpgsqlParameter TextParam(string text)
        {
            return new NpgsqlParameter
            {
                NpgsqlDbType = NpgsqlDbType.Text,
                Value = text,
            };
        }

        public static NpgsqlParameter Json(string text)
        {
            return new NpgsqlParameter
            {
                NpgsqlDbType = NpgsqlDbType.Json,
                Value = text,
            };
        }

        public static NpgsqlParameter StringArray(string[] resources)
        {
            return new NpgsqlParameter
            {
                NpgsqlDbType = NpgsqlDbType.Array,
                Value = resources,
            };
        }

        public static NpgsqlParameter Int(int limit)
        {
            return new NpgsqlParameter
            {
                NpgsqlDbType = NpgsqlDbType.Integer,
                Value = limit,
            };
        }
    }
}
