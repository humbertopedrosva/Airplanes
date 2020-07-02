using CoreItAirplanes.Models.Persons;

namespace CoreItAirplanes.Test.Fakes
{
    public static class StewardessFake 
    {
        private static string Name = "Jhon";
        public static Stewardess Default() => new Stewardess(Name);
    }
}
