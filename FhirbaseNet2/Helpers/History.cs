using System;

namespace Netrika.FhirbaseNet2.Helpers
{
    public static class History
    {
        public static HistoryParameters Since(int since)
        {
            return new HistoryParameters(Int32.MinValue, since);
        }

        public static HistoryParameters Count(int count)
        {
            return new HistoryParameters(count);
        }

        public static HistoryParameters Since(this HistoryParameters parameters, int since)
        {
            parameters.Since = since;

            return parameters;
        }

        public static HistoryParameters Count(this HistoryParameters parameters, int count)
        {
            parameters.Count = count;

            return parameters;
        }
    }
}