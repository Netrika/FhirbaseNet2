using System;
using System.Collections.Generic;
using System.Linq;

namespace Netrika.FhirbaseNet2.Helpers
{
    public static class Search
    {
        public static SearchParameters By(string key, string value)
        {
            var searchParameters = new SearchParameters();

            searchParameters.Add(key, value);

            return searchParameters;
        }

        public static SearchParameters By(string key, IEnumerable<String> values)
        {
            var searchParameters = new SearchParameters();

            foreach (var value in values)
            {
                searchParameters.Add(key, value);
            }

            return searchParameters;
        }

        public static SearchParameters By(this SearchParameters parameters, string key, string value)
        {
            parameters.Add(key, value);

            return parameters;
        }

        public static SearchParameters By(this SearchParameters parameters, string key, IEnumerable<String> values)
        {
            foreach (var value in values)
            {
                parameters.Add(key, value);
            }

            return parameters;
        }

        public static SearchParameters Or(this SearchParameters parameters, string key, IEnumerable<String> values)
        {
            var valuesArray = values as string[] ?? values.ToArray();

            if (valuesArray.Any())
            {
                parameters.Add(key, valuesArray.Aggregate((accum, next) => accum + ("," + next)).Trim(','));
            }

            return parameters;
        }
    }
}