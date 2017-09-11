using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace alkilab
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        public void onRegisterClick(object sender, EventArgs e) {
            PushRegisterPage();
        }

        async void PushRegisterPage()
        {
            await Navigation.PushModalAsync(new RegisterPage());
        }
    }
}