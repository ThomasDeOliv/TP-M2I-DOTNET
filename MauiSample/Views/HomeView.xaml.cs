using MauiSample.ViewModels;

namespace MauiSample.Views
{
    public partial class HomeView : ContentPage
    {
        private readonly HomeViewModel _viewModel;

        public HomeView(HomeViewModel viewModel)
        {
            _viewModel = viewModel;
            BindingContext = _viewModel;
            InitializeComponent();
        }
    }
}
