using CoreItAirplanes.Models.Persons;
using System.Collections.Generic;
using System.Linq;

namespace CoreItAirplanes.Models.Locations
{
    public abstract class LocationStarter : ILocationStarter
    {
        private List<Person> Passengers;

        protected LocationStarter()
        {
            Passengers = new List<Person>();
        }

        public List<Person> GetPassengers() => Passengers;

        public bool HavePassengers() => Passengers.Any();
        public void AddPassenger(Person person)
        {
            if (person != null)
                this.Passengers.Add(person);
        }

        public void AddPassengers(params Person[] persons)
        {
            foreach (var person in persons)
            {
                if (person != null)
                    this.Passengers.Add(person);
            }
        }

        public void AddPassengers(List<Person> persons) => this.Passengers.AddRange(persons);

        public void RemovePassenger(Person person) => this.Passengers.Remove(person);

        public void RemovePassengers(params Person[] persons)
        {
            foreach (var person in persons)
            {
                if (person != null)
                    this.Passengers.Remove(person);
            }
        }
    }
}
