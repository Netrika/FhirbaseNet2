using System;
using System.Collections.Generic;
using Netrika.FhirbaseNet2.Helpers;
using Npgsql;

namespace Netrika.FhirbaseNet2
{
    internal class FhirbaseContext
    {
        private readonly string _connectionString;

        public FhirbaseContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public FhirbaseFunction Call(string schema, string function)
        {
            var name = String.Concat(schema, ".", function);

            return new FhirbaseFunction(name)
            {
                ConnectionString = _connectionString
            };
        }

        public class FhirbaseFunction
        {
            private readonly List<NpgsqlParameter> _parameters;

            private readonly string _name;

            public FhirbaseFunction(string name)
            {
                _name = name;
                _parameters = new List<NpgsqlParameter>();
            }
            
            public String ConnectionString { get; set; }

            public FhirbaseFunction WithString(string value)
            {
                this._parameters.Add(PostgresHelper.TextParam(value));

                return this;
            }

            public  FhirbaseFunction WithJson(string jsonValue)
            {
                this._parameters.Add(PostgresHelper.Json(jsonValue));
                return this;
            }

            public  FhirbaseFunction WithStringArray(string[] stringArray)
            {
                this._parameters.Add(PostgresHelper.StringArray(stringArray));
                return this;
            }

            public FhirbaseFunction WithInt32(int value)
            {
                this._parameters.Add(PostgresHelper.Int(value));
                return this;
            }

            /// <summary>
            /// Call FHIRbase function and cast value
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="func"></param>
            /// <returns></returns>
            public T Cast<T>()
            {
                return (T) PostgresHelper.Function(this.ConnectionString, this._name, this._parameters.ToArray());
            }
        }
    }
}