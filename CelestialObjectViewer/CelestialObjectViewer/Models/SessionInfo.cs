using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelestialObjectViewer.Models
{
    public class SessionInfo
    {
        // Lazy<T> ensures thread-safe, lazy initialization of the singleton instance
        private static readonly Lazy<SessionInfo> _instance =
            new Lazy<SessionInfo>(() => new SessionInfo());

        // Private constructor prevents external instantiation
        private SessionInfo()
        {
            _planetsAndStars = new ObservableCollection<CelestialObject>();
        }

        // Public property to access the singleton instance
        public static SessionInfo Instance => _instance.Value;

        // ObservableCollection to notify UI of changes automatically
        private ObservableCollection<CelestialObject> _planetsAndStars;
        public ObservableCollection<CelestialObject> PlanetsAndStars => _planetsAndStars;

        // Convenience property to get only the planets
        public List<Planet> Planets => _planetsAndStars.OfType<Planet>().ToList();
        public List<Star> Stars => _planetsAndStars.OfType<Star>().ToList();
    }
}
