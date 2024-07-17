using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelestialObjectViewer.Models
{
    public class Planet : CelestialObject
    {
        public Planet()
        {
            IsPlanet = true;
        }
    }

    public class Root
    {
        public List<Planet> Planets { get; set; }
    }
}
