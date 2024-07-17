using CelestialObjectViewer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelestialObjectViewer.ViewModels
{
    public class CelestialObjectViewModel : BasePageViewModel
    {
        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _imageURL;
        public string ImageURL
        {
            get => _imageURL;
            set => SetProperty(ref _imageURL, value);
        }

        private string _source;
        public string Source
        {
            get => _source;
            set => SetProperty(ref _source, value);
        }

        private int _year;
        public int Year
        {
            get => _year;
            set => SetProperty(ref _year, value);
        }

        private string _distance;
        public string Distance
        {
            get => _distance;
            set => SetProperty(ref _distance, value);
        }

        private string _magnitude;
        public string Magnitude
        {
            get => _magnitude;
            set => SetProperty(ref _magnitude, value);
        }

        private bool _isPlanet;
        public bool IsPlanet
        {
            get => _isPlanet;
            set => SetProperty(ref _isPlanet, value);
        }
        private bool _isStar;
        public bool IsStar
        {
            get => _isStar;
            set => SetProperty(ref _isStar, value);
        }

        public CelestialObjectViewModel(CelestialObject celestialObject)
        {
            Name = celestialObject.Name;
            ImageURL = celestialObject.ImageURL;
            Source = celestialObject.Source;
            Year = celestialObject.Year;
            Distance = celestialObject.Distance;
            Magnitude = celestialObject.Magnitude;
            IsPlanet = celestialObject is Planet;
            IsStar = celestialObject is Star;
        }
    }
}
