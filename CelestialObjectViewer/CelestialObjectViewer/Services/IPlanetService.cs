using CelestialObjectViewer.Models;

namespace CelestialObjectViewer.Services
{
    public interface IPlanetService
    {
        Task<List<Planet>> GetThePlanetsAsync();
    }
}
