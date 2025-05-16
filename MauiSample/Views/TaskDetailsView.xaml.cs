using MauiSample.ViewModels;

namespace MauiSample.Views;

public partial class TaskDetailsView : ContentPage
{
    private readonly TaskDetailsViewModel _viewModel;

    public TaskDetailsView(TaskDetailsViewModel viewModel)
    {
        _viewModel = viewModel;
        BindingContext = _viewModel;
        InitializeComponent();
    }
}