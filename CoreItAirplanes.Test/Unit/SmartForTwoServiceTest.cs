using CoreItAirplanes.Models.Locations;
using CoreItAirplanes.Models.Persons;
using CoreItAirplanes.Models.Vehicles;
using CoreItAirplanes.Services;
using CoreItAirplanes.Services.Interfaces;
using CoreItAirplanes.Test.Fakes;
using FluentAssertions;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CoreItAirplanes.Test.Unit
{
    public class SmartForTwoServiceTest
    {
        private readonly ISmartForTwo _smartForTwo;
        private readonly IAirplane _airplane;
        private readonly ITerminalService _terminalService;
        private readonly ITerminal _terminal;
        private ISmartForTwoService _smartForTwoService;

        public SmartForTwoServiceTest()
        {
            _terminal = new Terminal();
            _airplane = new Airplane();
            _smartForTwo = new SmartForTwo();
            _terminalService = Substitute.For<ITerminalService>();
            _smartForTwoService = new SmartForTwoService(_smartForTwo, _airplane, _terminalService, _terminal);
        }

        [Fact]
        public void Should_take_a_passenger_to_plane_with_one_driver()
        {
            var boss = BossFake.Default();
            var stewardess = StewardessFake.Default();

            var passengers = new List<Person> { boss, stewardess };

            _terminalService.MoveFromTerminal().Returns(passengers);

            _smartForTwoService.TakeToThePlane();

            var airplanePassenger = _airplane.GetPassengers();

            airplanePassenger.FirstOrDefault(x => x.GetType() == typeof(Stewardess)).Should().NotBeNull();

            _airplane.HavePassengers().Should().BeTrue();

            _smartForTwo.GetPassengers().Count().Should().Be(1);
        }

        [Fact]
        public void Should_take_a_passenger_to_plane_with_two_driver()
        {
            var boss = BossFake.Default();
            var pillot = PilotFake.Default();

            var officialOne = OfficialFake.Default();
            var officialTwo = OfficialFake.Default();

            var stewardessOne = StewardessFake.Default();
            var stewardessTwo = StewardessFake.Default();

            var cop = CopFake.Default();
            var prisoner = PrisonerFake.Default();

            _terminal.AddPassengers(stewardessOne, stewardessTwo, cop, prisoner);

            _airplane.AddPassengers(officialOne, officialTwo);

            var passengers = new List<Person> { boss, pillot };

            _terminalService.MoveFromTerminal().Returns(passengers);

            _smartForTwoService.TakeToThePlane();

            var airplanePassenger = _airplane.GetPassengers();

            airplanePassenger.FirstOrDefault(x => x.GetType() == typeof(Pilot)).Should().NotBeNull();

            _airplane.HavePassengers().Should().BeTrue();

            _smartForTwo.GetPassengers().Count().Should().Be(1);
        }
    }
}
