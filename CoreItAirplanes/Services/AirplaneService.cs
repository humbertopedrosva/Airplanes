using CoreItAirplanes.Models.Locations;
using CoreItAirplanes.Models.Vehicles;
using CoreItAirplanes.Services.Interfaces;
using System.Linq;

namespace CoreItAirplanes.Services
{
    public class AirplaneService : IAirplaneService
    {
        private ITerminal _terminal;
        private IAirplane _airplane;
        private ISmartForTwoService _smartForTwoService;
        private ISmartForTwo _smartForTwo;
        public AirplaneService
            (
            ITerminal terminal, 
            IAirplane airplane,
            ISmartForTwoService smartForTwoService, 
            ISmartForTwo smartForTwo)
        {
            _terminal = terminal;
            _airplane = airplane;
            _smartForTwoService = smartForTwoService;
            _smartForTwo = smartForTwo;
        }

        public string AllPassengersOnThePlane()
        {
            while (_terminal.HavePassengers())
            {
                _smartForTwoService.TakeToThePlane();
            }

            var lastDriver = _smartForTwo.GetPassengers().FirstOrDefault();
            _airplane.AddPassengers(_smartForTwo.GetPassengers());
            _smartForTwo.RemovePassenger(lastDriver);

            return "Ready to take flight!";
        }
    }
}
