using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Netrika.FhirbaseNet2.Helpers
{

    public class SearchParameters
    {
        public static readonly SearchParameters Empty = new SearchParameters();
        
        private readonly List<KeyValuePair<String,String>> _parameters = new List<KeyValuePair<string, string>>();

        public SearchParameters()
        {
        }

        public void Add(string key, string value)
        {
            _parameters.Add(new KeyValuePair<string, string>(key, value));
        }
        
        /// <summary>
        /// Возвращает форматированную строку параметров
        /// </summary>
        public override string ToString()
        {
            var query = new StringBuilder();

            foreach (var parameter in _parameters)
            {
                query.Append($"{parameter.Key}={parameter.Value}&");
            }

            var result = query.ToString().Trim('&');

            return result;
        }
    }
}
