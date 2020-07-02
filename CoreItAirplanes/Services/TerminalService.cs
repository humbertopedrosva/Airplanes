using CoreItAirplanes.Exceptions;
using CoreItAirplanes.Models.Locations;
using CoreItAirplanes.Models.Persons;
using CoreItAirplanes.Models.Vehicles;
using CoreItAirplanes.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CoreItAirplanes.Services
{
    public class TerminalService : ITerminalService
    {
        private ITerminal _terminal;
        private ISmartForTwo _smartForTwo;
        private const int NUMBER_OF_SPACES_IN_THE_CAR = 2;
        private const int NUMBER_OF_PERSONS_IN_TERMINAL = 8;

        public TerminalService(ITerminal terminal, ISmartForTwo smartForTwo)
        {
            _terminal = terminal;
            _smartForTwo = smartForTwo;
        }
        public List<Person> MoveFromTerminal()
        {
            var passengers = _terminal.GetPassengers();

            Person driver;
            Person ride;

            if (!_smartForTwo.HavePassengers())
            {
                 driver = GetDriver(passengers);

                _terminal.RemovePassenger(driver);

                ride = GetRide(driver, passengers);

                _terminal.RemovePassenger(ride);

                return new List<Person> { driver, ride };
            }

            driver = _smartForTwo.GetPassengers().FirstOrDefault();
            ride = GetRide(driver, passengers);
            _terminal.RemovePassenger(ride);

            return new List<Person> { ride };
        }

        private Person GetDriver(List<Person> persons)
        {
            var passengers = _terminal.GetPassengers();

            var driver = persons.FirstOrDefault(x => x.IsDriver);

            var driverInvalid = persons.Count() > NUMBER_OF_SPACES_IN_THE_CAR
                && _terminal.GetPassengers().Count != NUMBER_OF_PERSONS_IN_TERMINAL;

            var type = driver.GetType();
            if (type == typeof(Cop) && driverInvalid)
                throw new PrisonerWithoutSupervisionException("Cop cannot leave prisoner with passengers without supervision");

            return driver;
        }

        private Person GetRide(Person driver, List<Person> persons)
        {
            Person ride;

            var personSameGroup = persons.Any(x => x.GroupPerson == driver.GroupPerson);

            if (personSameGroup)
                ride = persons.FirstOrDefault(x => x.GroupPerson == driver.GroupPerson);

            else
                ride = GetDriver(persons);

            return ride;

        }

    }
}
