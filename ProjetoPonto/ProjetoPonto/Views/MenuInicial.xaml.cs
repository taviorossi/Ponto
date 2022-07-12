using ProjetoPonto.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetoPonto.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuInicial : ContentPage
    {
        MenuInicialViewModel _menuInicialViewModel;
        public MenuInicial(string nome)
        {
            InitializeComponent();
            TxtNomeUsuario.Text = nome;
            _menuInicialViewModel = BindingContext as MenuInicialViewModel;
            _menuInicialViewModel.Navigation = Navigation;
        }

        protected override void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                _menuInicialViewModel.BuscaDados();
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Atenção", ex.Message, "OK");
            }
        }
    }
}
