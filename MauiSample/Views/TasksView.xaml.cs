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

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.LoadTasksCommand.Execute(null);
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        _viewModel.UnLoadTasksCommand.Execute(null);
    }
}