using CoreItAirplanes.Models.Locations;
using CoreItAirplanes.Models.Vehicles;
using CoreItAirplanes.Services;
using CoreItAirplanes.Services.Interfaces;
using CoreItAirplanes.Test.Fakes;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace CoreItAirplanes.Test.Unit
{
    public class AirplaneServiceTest
    {
        private readonly ITerminal _terminal;
        private readonly IAirplane _airplane;
        private readonly ISmartForTwoService _smartForTwoService;
        private readonly ISmartForTwo _smartForTwo;
        private readonly IAirplaneService _airplaneService;

        public AirplaneServiceTest()
        {
            _terminal = new Terminal();
            _airplane = new Airplane();
            _smartForTwo = new SmartForTwo();
            _smartForTwoService = Substitute.For<ISmartForTwoService>();
            _airplaneService = new AirplaneService(_terminal, _airplane, _smartForTwoService, _smartForTwo);

        }

        [Fact]
        public void Should_finished_when_terminal_is_empty()
        {
            var boss = BossFake.Default();
            var pillot = PilotFake.Default();

            var officialOne = OfficialFake.Default();
            var officialTwo = OfficialFake.Default();

            var stewardessOne = StewardessFake.Default();
            var stewardessTwo = StewardessFake.Default();

            var cop = CopFake.Default();
            var prisoner = PrisonerFake.Default();

            _smartForTwo.AddPassenger(cop);
            _airplane.AddPassengers(boss, pillot, officialTwo, officialOne, stewardessOne, stewardessTwo, prisoner);

           var result = _airplaneService.AllPassengersOnThePlane();

            result.Should().NotBeNullOrEmpty();
            result.Should().Be("Ready to take flight!");
            
        }
    }
}
