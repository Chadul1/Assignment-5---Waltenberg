namespace CelestialObjectViewer
{ 
    
using CelestialObjectViewer.Views;

    public partial class App : Application
    {
        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            MainPage = new NavigationPage(serviceProvider.GetRequiredService<CelestialObjectPage>());
        }
    }
}
