using CoreItAirplanes.Models.Enums;

namespace CoreItAirplanes.Models.Persons
{
    public class Official : Person
    {
        public Official(string name, bool isDriver = false , GroupPerson groupPerson = GroupPerson.Technical) 
            : base(name, isDriver, groupPerson)
        {
        }
    }
}
