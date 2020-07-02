using CoreItAirplanes.Models.Enums;

namespace CoreItAirplanes.Models.Persons
{
    public class Stewardess : Person
    {
        public Stewardess(string name, bool isDriver = false, GroupPerson groupPerson = GroupPerson.Cabin)
            : base(name, isDriver, groupPerson)
        {
        }
    }
}
