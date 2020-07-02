using CoreItAirplanes.Models.Locations;
using CoreItAirplanes.Models.Persons;
using CoreItAirplanes.Models.Vehicles;
using CoreItAirplanes.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CoreItAirplanes.Services
{
    public class SmartForTwoService : ISmartForTwoService
    {
        private ISmartForTwo _smartForTwo;
        private IAirplane _airplane;
        private ITerminalService _terminalService;
        private ITerminal _terminal;
        private const int NUMBER_OF_DRIVERS = 1;
        public SmartForTwoService(ISmartForTwo smartForTwo, IAirplane airplane, ITerminalService terminalService, ITerminal terminal)
        {
            _smartForTwo = smartForTwo;
            _terminalService = terminalService;
            _airplane = airplane;
            _terminal = terminal;

        }
        public void TakeToThePlane()
        {
            var passengers = _terminalService.MoveFromTerminal();

            _smartForTwo.AddPassengers(passengers);

            Transport(passengers);

        }

        private void Transport(List<Person> persons)
        {
            var oneDriverInCar = _smartForTwo.GetPassengers().Where(x => x.IsDriver).Count() == NUMBER_OF_DRIVERS;

            if (oneDriverInCar)
            {
                var passenger = persons.FirstOrDefault(x => x.IsDriver == false);
                _airplane.AddPassenger(passenger);
                _smartForTwo.RemovePassenger(passenger);
            }

            else
            {
                var passengersInTerminal = _terminal.GetPassengers();
                var driver = GetDriverWhoIsDriving();

                _airplane.AddPassenger(driver);
                _smartForTwo.RemovePassenger(driver);

            }

        }
        private Person GetDriverWhoIsDriving()
        {
            var personsInTerminal = _terminal.GetPassengers();
            var driver = _smartForTwo.GetPassengers().FirstOrDefault();


            Person driverFinal = _terminal.GetPassengers().FirstOrDefault(x => x.GetType() == typeof(Cop));

            var driverWithoutCrew = !personsInTerminal.Any(x => x.GroupPerson == driver.GroupPerson);

            if (driverWithoutCrew)
                return driver;

            else
            {
                foreach (var person in _smartForTwo.GetPassengers())
                {
                    if (!person.Equals(driver))
                        driverFinal = person;
                }
                return driverFinal;
            }

        }
    }
}

