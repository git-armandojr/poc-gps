using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Gps
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Gps();
        }

        async void Gps()
        {
            try
            {
                var localizacao = await Geolocation.GetLastKnownLocationAsync();
                if (localizacao != null)
                {
                    lblLatitude.Text += localizacao.Latitude.ToString();
                    lblLongitude.Text += localizacao.Longitude.ToString();
                    lblAltitude.Text += localizacao.Altitude.ToString();
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                await DisplayAlert("Erro ", fnsEx.Message, "Ok");
            }
            catch (PermissionException pEx)
            {                
                await DisplayAlert("Erro: ", pEx.Message, "Ok");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro : ", ex.Message, "Ok");
            }
        }
    }
}
