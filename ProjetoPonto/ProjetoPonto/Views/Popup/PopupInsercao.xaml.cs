using ProjetoPonto.ViewModels;
using ProjetoPontoBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetoPonto.Views.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupInsercao
    {
        PopupInsercaoViewModel _popupInsercaoViewModel = new PopupInsercaoViewModel();
        public PopupInsercao(bool isDetalhe, Ponto ponto)
        {
            InitializeComponent();
            try
            {
                _popupInsercaoViewModel = BindingContext as PopupInsercaoViewModel;
                _popupInsercaoViewModel.PontoFinal = ponto;
                if (isDetalhe == true)
                {
                    txtTitulo.Text = ponto.Titulo;
                    txtDescricao.Text = ponto.Descricao;
                    txtHoraInicial.Text = ponto.PontoInicial;

                    txtTitulo.IsEnabled = false;
                    txtDescricao.IsEnabled = false;
                    txtHoraInicial.IsEnabled = false;

                    ButtonInsercao.IsEnabled = false;
                    ButtonInsercao.IsVisible = false;

                    txtHoraFinal.IsEnabled = true;
                    txtHoraFinal.IsVisible = true;

                    ButtonEncerrar.IsEnabled = true;
                    ButtonEncerrar.IsVisible = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}