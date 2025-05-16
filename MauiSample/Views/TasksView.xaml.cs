using MauiSample.ViewModels;

namespace MauiSample.Views;

public partial class TasksView : ContentPage
{
    private readonly TasksViewModel _viewModel;

    public TasksView(TasksViewModel viewModel)
    {
        _viewModel = viewModel;
        BindingContext = _viewModel;
        InitializeComponent();
    }
}