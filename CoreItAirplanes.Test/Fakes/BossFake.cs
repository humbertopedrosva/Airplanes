using CoreItAirplanes.Models.Persons;

namespace CoreItAirplanes.Test.Fakes
{
    public static class BossFake
    {
        private static string Name = "Jhon";
        public static Boss Default() => new Boss(Name);
    }
}
