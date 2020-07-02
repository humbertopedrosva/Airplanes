using CoreItAirplanes.Models.Persons;

namespace CoreItAirplanes.Test.Fakes
{
    public static class PilotFake
    {
        private static string Name = "Tom";
        public static Pilot Default() => new Pilot(Name);
    }
}
