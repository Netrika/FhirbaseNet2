using System;

namespace Netrika.FhirbaseNet2.Helpers
{
    public class HistoryParameters
    {
        public Int32 Count { get; set; }
        public Int32 Since { get; set; }

        public static readonly HistoryParameters Empty = new HistoryParameters();

        public HistoryParameters(int count, int since = Int32.MinValue)
        {
            Count = count;
            Since = since;
        }

        public HistoryParameters() : this(Int32.MinValue, Int32.MinValue) { }

        public override String ToString()
        {
            var result = System.Web.HttpUtility.ParseQueryString(String.Empty);

            if (Count != Int32.MinValue)
            {
                result.Add("count", Count.ToString());
            }

            if (Since != Int32.MinValue)
            {
                result.Add("since", Since.ToString());
            }

            return result.ToString();
        }
    }
}
