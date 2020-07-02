using CoreItAirplanes.Models.Persons;
using System.Collections.Generic;

namespace CoreItAirplanes.Models.Locations
{
    public interface ILocationStarter
    {
        void AddPassenger(Person person);
        void AddPassengers(List<Person> persons);
        void AddPassengers(params Person[] persons);
        List<Person> GetPassengers();
        void RemovePassenger(Person person);
        void RemovePassengers(params Person[] persons);
        bool HavePassengers();
    }
}