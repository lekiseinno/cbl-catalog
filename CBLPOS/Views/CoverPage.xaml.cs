using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBLPOS.ViewModels;
using Xamarin.Forms;

namespace CBLPOS.Views
{
    public partial class CoverPage : ContentPage
    {
        public CoverPage()
        {
            InitializeComponent();
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new CatalogPage("Animal"));
        }

        private async void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CatalogPage("Dark Fantasy"));
        }

        private async void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new CatalogPage("SX"));

        }


        private async void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CatalogPage("Fantasy"));
        }

        private async void TapGestureRecognizer_Tapped_5(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CatalogPage("4DX"));
        }

        private async void TapGestureRecognizer_Tapped_6(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CatalogPage("Bike Fantasy"));
        }

    }
}
