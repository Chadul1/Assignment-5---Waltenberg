using CelestialObjectViewer.Models;
using CelestialObjectViewer.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CelestialObjectViewer.ViewModels
{
    public class MainPageViewModel : BasePageViewModel
    {
        private readonly IPlanetService _planetService;

        private readonly IStarService _starService;

        private ObservableCollection<CelestialObjectViewModel> _planetsAndStars;
        public ObservableCollection<CelestialObjectViewModel> PlanetsAndStars
        {
            get => _planetsAndStars;
            set => SetProperty(ref _planetsAndStars, value);
        }

        public ICommand LoadDataCommand { get; }

        // Default constructor for design-time support
        public MainPageViewModel() : this(null, null) { }

        public MainPageViewModel(IPlanetService planetService, IStarService starService)
        {
            _planetService = planetService ?? new MockPlanetService();
            _starService = starService ?? new MockStarService();
            PlanetsAndStars = new ObservableCollection<CelestialObjectViewModel>();

            LoadDataCommand = CreateCommand(async () => await LoadDataAsync());
        }

        /// <summary>
        /// Loads the data found.
        /// </summary>
        /// <returns></returns>
        private async Task LoadDataAsync()
        {
            IsBusy = true;

            try
            {
                PlanetsAndStars.Clear();
                await this.LoadPlanetData();
                await this.LoadStarData();
            }
            finally
            {
                IsBusy = false;
            }
        }

        /// <summary>
        /// Loads the planet data from the Json.
        /// </summary>
        /// <returns></returns>
        public async Task LoadPlanetData()
        {
            var planets = await _planetService.GetThePlanetsAsync();
            
            foreach (var planet in planets)
            {
                PlanetsAndStars.Add(new CelestialObjectViewModel(planet));
            }
        }

        /// <summary>
        /// Loads the Star data from the Json.
        /// </summary>
        /// <returns></returns>
        public async Task LoadStarData()
        {
            var stars = await _starService.GetTheStarsAsync();
            foreach (var star in stars)
            {
                PlanetsAndStars.Add(new CelestialObjectViewModel(star));
            }
        }

    }

    

    // Mock service for design-time support
    public class MockPlanetService : IPlanetService
    {
        public Task<List<Planet>> GetThePlanetsAsync()
        {
            // Return some dummy data for design-time purposes
            return Task.FromResult(new List<Planet>
            {
                new Planet { Name = "Mercury", ImageURL = "mercury.png", Source = "Solar System", Year = 2022 },
                new Planet { Name = "Venus", ImageURL = "venus.png", Source = "Solar System", Year = 2022 },
                new Planet { Name = "Earth", ImageURL = "earth.png", Source = "Solar System", Year = 2022 }
            });
        }
    }
    //Mock service for design time.
    public class MockStarService : IStarService
    {
        public Task<List<Star>> GetTheStarsAsync()
        {
            // Return some dummy data for design-time purposes
            return Task.FromResult(new List<Star>
            {
                new Star { Name = "Sun", ImageURL = "mercury.png", Source = "Stars", Year = 2022 },
                new Star { Name = "Vera", ImageURL = "venus.png", Source = "Solar System", Year = 2022 },
                new Star { Name = "Sirius", ImageURL = "earth.png", Source = "Solar System", Year = 2022 }
            });
        }
    }
}
