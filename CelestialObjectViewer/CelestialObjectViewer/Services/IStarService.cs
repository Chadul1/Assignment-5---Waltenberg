using CelestialObjectViewer.Models;

namespace CelestialObjectViewer.Services
{
    public interface IStarService
    {
        Task<List<Star>> GetTheStarsAsync();
    }
}
