using CoreItAirplanes.Models.Enums;

namespace CoreItAirplanes.Models.Persons
{
    public class Prisoner : Person
    {
        public Prisoner(string name, bool isDriver = false, GroupPerson groupPerson = GroupPerson.Passenger) 
            : base(name, isDriver, groupPerson)
        {
        }
    }
}
