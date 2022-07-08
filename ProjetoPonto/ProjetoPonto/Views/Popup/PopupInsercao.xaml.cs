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
    public partial class PopupInsercao : Popup
    {
        public PopupInsercao()
        {
            InitializeComponent();
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {

        }
    }
}