using CoreItAirplanes.Models.Persons;

namespace CoreItAirplanes.Test.Fakes
{
    public static class PrisonerFake
    {
        private static string Name = "Jhon";
        public static Prisoner Default() => new Prisoner(Name);
    }
}
