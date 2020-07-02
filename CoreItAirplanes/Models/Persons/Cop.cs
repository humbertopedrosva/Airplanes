using CoreItAirplanes.Models.Enums;

namespace CoreItAirplanes.Models.Persons
{
    public class Cop : Person
    {
        public Cop(string name, bool isDriver = true, GroupPerson groupPerson = GroupPerson.Passenger) : base(name, isDriver, groupPerson)
        {
        }
        public Cop() : base()
        {
        }
    }
}
