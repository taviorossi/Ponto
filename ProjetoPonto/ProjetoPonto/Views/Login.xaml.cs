using ProjetoPonto.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetoPonto.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        LoginViewModel _loginViewModel;
        public Login()
        {
            InitializeComponent();
            _loginViewModel = BindingContext as LoginViewModel;
            _loginViewModel.Navigation = Navigation;
        }

        //protected override void OnAppearing()
        //{
        //    try
        //    {
        //        base.OnAppearing();
        //        _loginViewModel.BuscaDadosUsuario();
        //    }
        //    catch (Exception ex)
        //    {
        //        App.Current.MainPage.DisplayAlert("Atenção", ex.Message, "OK");
        //    }
        //}
    }
}