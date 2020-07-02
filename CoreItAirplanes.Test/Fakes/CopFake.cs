using CoreItAirplanes.Models.Persons;

namespace CoreItAirplanes.Test.Fakes
{
    public static class CopFake
    {
        private static string Name = "James";
        public static Cop Default() => new Cop(Name);
    }
}
