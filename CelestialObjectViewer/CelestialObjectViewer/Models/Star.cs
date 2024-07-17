using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelestialObjectViewer.Models
{
    public class Star : CelestialObject
    {
        public Star() 
        {
            IsPlanet = false;
        }
    }

    public class StarRoot
    {
        public List<Star> Stars { get; set; }
    }
}
