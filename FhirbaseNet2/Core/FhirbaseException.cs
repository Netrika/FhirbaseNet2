using System;

namespace Netrika.FhirbaseNet2
{
    [Serializable]
    public class FhirbaseException : Exception
    {
        public FhirbaseException(string message) : base(message)
        {
        }

        public FhirbaseException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
