using CoreItAirplanes.Interfaces;
using CoreItAirplanes.Models.Locations;
using CoreItAirplanes.Models.Vehicles;
using CoreItAirplanes.Services;
using CoreItAirplanes.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CoreItAirplanes
{
    public static class Bootstrapper
    {
        public static void Initialize(this IServiceCollection services)
        {
            RegisterModels(services);
            RegisterServices(services);
            RegisterSeed(services);
        }

        private static void RegisterSeed(IServiceCollection services)
        {
            services.AddScoped<ICrewInitialize, CrewInitialize>();
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IAirplaneService, AirplaneService>();
            services.AddScoped<ISmartForTwoService, SmartForTwoService>();
            services.AddScoped<ITerminalService, TerminalService>();
        }

        private static void RegisterModels(IServiceCollection services)
        {
            services.AddSingleton<ITerminal, Terminal>();
            services.AddSingleton<ISmartForTwo, SmartForTwo>();
            services.AddSingleton<IAirplane, Airplane>();

        }
    }
}
