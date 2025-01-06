using WRApiNasa.ViewModels;

namespace WRApiNasa.Views;

public partial class ApodPage : ContentPage
{
	public ApodPage()
	{
        InitializeComponent();
        BindingContext = new WRApodViewModel();
    }
}