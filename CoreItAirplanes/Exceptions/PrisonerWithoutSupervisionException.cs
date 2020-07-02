using System;

namespace CoreItAirplanes.Exceptions
{
    public class PrisonerWithoutSupervisionException : Exception
    {
        public PrisonerWithoutSupervisionException(string message) : base(message)
        {
        }
    }
}
