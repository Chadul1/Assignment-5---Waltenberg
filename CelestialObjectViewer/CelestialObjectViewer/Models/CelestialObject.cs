using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelestialObjectViewer.Models
{

    public class CelestialObject
    {
        public string Name { get; set; }
        public string Source { get; set; }
        public string ImageURL { get; set; }
        public int Year { get; set; }
        public string Distance { get; set; }
        public string Magnitude { get; set; }
        public bool IsPlanet { get; set; }
        public bool IsStar => !IsPlanet;

    }
}
