namespace CelestialObjectViewer.Views;
using CelestialObjectViewer.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using CelestialObjectViewer.Services;

public partial class CelestialObjectPage : ContentPage
{
    private MainPageViewModel MainPageViewModel { get; set; }

    public CelestialObjectPage(MainPageViewModel viewModel)
    {
        InitializeComponent();
        MainPageViewModel = viewModel;
        BindingContext = viewModel;
    }

    /// <summary>
    /// Is set up so the picker shows the information available for each option.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void OnPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        Picker picker = sender as Picker;
        string selectedItem = picker.SelectedItem as string;

        if (selectedItem == "Everything") 
        {
            MainPageViewModel.PlanetsAndStars.Clear();
            await MainPageViewModel.LoadPlanetData();
            await MainPageViewModel.LoadStarData();
        }

        if (selectedItem == "Planets")
        {
            MainPageViewModel.PlanetsAndStars.Clear();
            await MainPageViewModel.LoadPlanetData();
        }

        if (selectedItem == "Stars")
        {
            MainPageViewModel.PlanetsAndStars.Clear();
            await MainPageViewModel.LoadStarData();
        }
    }
}