using System.Diagnostics;
using System.Reflection;
using Newtonsoft.Json;
using CelestialObjectViewer.Models;

namespace CelestialObjectViewer.Services
{
    public class PlanetService : IPlanetService
    {
        /// <summary>
        /// Gets the information for the planets from the JSON files and returns it.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<List<Planet>> GetThePlanetsAsync()
        {
            var assembly = typeof(PlanetService).GetTypeInfo().Assembly;
            string resourceName = "CelestialObjectViewer.planets.json";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                {
                    throw new ArgumentNullException(nameof(stream), $"Resource {resourceName} not found.");
                }

                using (var reader = new StreamReader(stream))
                {
                    var json = await reader.ReadToEndAsync();
                    try
                    {
                        var data = JsonConvert.DeserializeObject<Root>(json);
                        return data.Planets;
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.StackTrace);
                        return null;
                    }
                }
            }
        }
    }
}
