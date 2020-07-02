using CoreItAirplanes.Interfaces;
using CoreItAirplanes.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CoreItAirplanes
{
    class Program
    {
        static void Main(string[] args)
        {

            var service = new ServiceCollection();

            Bootstrapper.Initialize(service);

            var provider = service.BuildServiceProvider();

            var airplaneService = provider.GetRequiredService<IAirplaneService>();

            var crewInitialize = provider.GetRequiredService<ICrewInitialize>();

            crewInitialize.CreateCrew();

            var output = airplaneService.AllPassengersOnThePlane();

            Console.WriteLine(output);
        }
    }
}
