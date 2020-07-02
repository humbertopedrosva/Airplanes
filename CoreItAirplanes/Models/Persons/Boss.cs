using CoreItAirplanes.Models.Enums;

namespace CoreItAirplanes.Models.Persons
{
    public class Boss : Person
    {
        public Boss(string name, bool isDriver = true, GroupPerson groupPerson = GroupPerson.Cabin) 
            : base(name, isDriver, groupPerson)
        {
        }
    }
}
