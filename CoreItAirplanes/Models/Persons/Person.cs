using CoreItAirplanes.Models.Enums;

namespace CoreItAirplanes.Models.Persons
{
    public abstract class Person
    {
        public string Name { get; set; }
        public bool IsDriver { get; set; }
        public GroupPerson GroupPerson { get; set; }

        protected Person()
        {

        }
        protected Person(string name, bool isDriver, GroupPerson groupPerson)
        {
            Name = name;
            IsDriver = isDriver;
            GroupPerson = groupPerson;
        }

    }
}
