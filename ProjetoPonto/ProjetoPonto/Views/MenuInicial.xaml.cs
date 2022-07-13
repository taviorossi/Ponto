using ProjetoPonto.ViewModels;
using ProjetoPontoBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.Extensions;
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

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Ponto;

            if (item == null)
                return;
            (sender as Xamarin.Forms.ListView).SelectedItem = null;

            _menuInicialViewModel.EntrarDetalhe(item);
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
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
