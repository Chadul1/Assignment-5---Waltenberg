using System.Diagnostics;
using System.Reflection;
using CelestialObjectViewer.Models;
using Newtonsoft.Json;

namespace CelestialObjectViewer.Services
{
    public class StarService : IStarService
    {
        /// <summary>
        /// Gets the information for the Stars from the JSON files and returns it.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<List<Star>> GetTheStarsAsync()
        {
            var assembly = typeof(StarService).GetTypeInfo().Assembly;
            string resourceName = "CelestialObjectViewer.stars.json";

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
                        var data = JsonConvert.DeserializeObject<StarRoot>(json);
                        return data.Stars;
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
