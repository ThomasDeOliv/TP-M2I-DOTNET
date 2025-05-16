using MauiSample.ViewModels;

namespace MauiSample.Views;

public partial class NewTaskView : ContentPage
{
    private readonly NewTaskViewModel _viewModel;

    public NewTaskView(NewTaskViewModel viewModel)
    {
        _viewModel = viewModel;
        BindingContext = _viewModel;
        InitializeComponent();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        _viewModel.CleanCommand.Execute(null);
    }
}