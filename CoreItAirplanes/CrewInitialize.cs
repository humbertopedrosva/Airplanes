using CoreItAirplanes.Interfaces;
using CoreItAirplanes.Models.Locations;
using CoreItAirplanes.Models.Persons;

namespace CoreItAirplanes
{
    public class CrewInitialize : ICrewInitialize
    {
        private readonly ITerminal _terminal;

        public CrewInitialize(ITerminal terminal)
        {
            _terminal = terminal;
        }
        public void CreateCrew()
        {
            var boss = new Boss("Bob");
            var sterwardessOne = new Stewardess("Jenna");
            var sterwardessTwo = new Stewardess("Jessie");

            var pilot = new Pilot("James");
            var officialOne = new Official("Jhony");
            var officialTwo = new Official("Jin");

            var cop = new Cop("Dean");
            var prisoner = new Prisoner("Sean");

            _terminal.AddPassengers(boss, sterwardessOne, sterwardessTwo, pilot, officialOne, officialTwo, cop, prisoner);
        }
    }
}
