using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using alkilab.validators;

namespace alkilab
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterPage : ContentPage
	{
        private BasicValidator _validator;
        private Dictionary<string, bool> _errors;

        public RegisterPage ()
		{
			InitializeComponent ();
            _validator = new BasicValidator();

		}

        public void HandleUserNameChanged(object sender, TextChangedEventArgs e) {
            CheckEntryImage(sender, () => {
                return _validator.ValidateAlphaNumeric(e.NewTextValue);
            });
        }

        public void HandleTextChanged(object sender, TextChangedEventArgs e) {
            CheckEntryImage(sender, () => {
                return _validator.ValidateText(e.NewTextValue);
            });
        }

        public void HandleEmailChanged(object sender, TextChangedEventArgs e)
        {
            CheckEntryImage(sender, () => {
                return _validator.ValidateEmail(e.NewTextValue);
            });
        }

        public void CheckEntryImage(object sender, Func<bool> method) {
            var item = (Entry)sender;
            var check = (Image)this.FindByName<Image>(item.StyleId + "_check");
            check.IsVisible = true;

            if (method())
                check.Source = "ok.png";
            else
                check.Source = "error.png";
        }

        public void HandlerRegisterClick(object sender, EventArgs e)
        {
            //Regex.Replace(XML, @"\s+", "")
            
        }
    }
}