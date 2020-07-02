using CoreItAirplanes.Models.Enums;

namespace CoreItAirplanes.Models.Persons
{
    public class Pilot : Person
    {
        public Pilot(string name, bool isDriver = true, GroupPerson groupPerson = GroupPerson.Technical) 
            : base(name, isDriver, groupPerson)
        {
        }
    }
}
