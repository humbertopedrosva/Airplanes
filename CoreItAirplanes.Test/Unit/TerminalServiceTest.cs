using CoreItAirplanes.Models.Locations;
using CoreItAirplanes.Models.Vehicles;
using CoreItAirplanes.Services;
using CoreItAirplanes.Services.Interfaces;
using CoreItAirplanes.Test.Fakes;
using FluentAssertions;
using System.Linq;
using Xunit;

namespace CoreItAirplanes.Test.Unit
{
    public class TerminalServiceTest
    {
        private readonly ITerminal _terminal;
        private readonly ISmartForTwo _smartForTwo;
        private ITerminalService _terminalService;

        public TerminalServiceTest()
        {
            _terminal = new Terminal();
            _smartForTwo = new SmartForTwo();
            _terminalService = new TerminalService(_terminal, _smartForTwo);
        }

        [Fact]
        public void Should_Returns_One_Driver_and_One_Ride()
        {
            var boss = BossFake.Default();
            var stewardess = StewardessFake.Default();

            _terminal.AddPassengers(boss, stewardess);

            var result = _terminalService.MoveFromTerminal();

            result.Count(x => x.IsDriver).Should().Be(1);
            result.Count.Should().Be(2);
        }
    }
}
