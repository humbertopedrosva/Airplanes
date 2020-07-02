using CoreItAirplanes.Models.Persons;
using System.Collections.Generic;

namespace CoreItAirplanes.Services.Interfaces
{
    public interface ITerminalService
    {
        List<Person> MoveFromTerminal();
    }
}
