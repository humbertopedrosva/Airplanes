using CoreItAirplanes.Models.Persons;

namespace CoreItAirplanes.Test.Fakes
{
    public static class OfficialFake
    {
        private static string Name = "Ian";
        public static Official Default() => new Official(Name);
    }
}
