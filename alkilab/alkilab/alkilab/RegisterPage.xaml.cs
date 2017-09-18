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
        private string[] _entries;
        private Dictionary<string, bool> _validatedEntries;
        private Dictionary<string, string> _messages;

        public RegisterPage ()
		{
			InitializeComponent ();
            _validator = new BasicValidator();

            _entries = new string[]{ "name", "lastname", "email",
                                     "username", "password", "password2" };
       
            _validatedEntries = new Dictionary<string, bool>();
            for (uint i = 0; i < _entries.Length; i++) {
                _validatedEntries.Add(_entries[i], false);
            }
		}

        public void HandleUserNameChanged(object sender, TextChangedEventArgs e) {
            CheckEntryImage(sender, () => {
                //TODO: It should validate if the user already exists
                return _validator.ValidateAlphaNumeric(e.NewTextValue);
            });
        }

        public void HandleTextChanged(object sender, TextChangedEventArgs e) {
            CheckEntryImage(sender, () => {
                return _validator.ValidateText(e.NewTextValue);
            });
        }

        public void HandlePasswordChanged(object sender, TextChangedEventArgs e)
        {
            CheckEntryImage(sender, () => {
                return _validator.ValidatePassword(e.NewTextValue);
            });
        }

        public void HandlePassword2Changed(object sender, TextChangedEventArgs e) {
            CheckEntryImage(sender, () => {
                return password.Text == e.NewTextValue && 
                       _validator.ValidatePassword(e.NewTextValue);
            });
        }

        public void HandleEmailChanged(object sender, TextChangedEventArgs e)
        {
            CheckEntryImage(sender, () => {
                //TODO: It should validate if the email already exists
                return _validator.ValidateEmail(e.NewTextValue);
            });
        }

        public void CheckEntryImage(object sender, Func<bool> validateMethod) {
            var item = (Entry)sender;
            var check = (Image)this.FindByName<Image>(item.StyleId + "_check");
            check.IsVisible = true;

            if (validateMethod()) { 
                _validatedEntries[item.StyleId] = true;
                check.Source = "ok.png";
            }
            else {
                _validatedEntries[item.StyleId] = false;
                check.Source = "error.png";
            }
        } 

        public void HandlerRegisterClick(object sender, EventArgs e)
        {
            var validatedFrom = true;
            messages_box.IsVisible = false;

            for (int i = 0; i < _validatedEntries.Count; i++)
            {
                if (!_validatedEntries[_entries[i]]) { 
                    validatedFrom = false;

                    //shows the error icon
                    var check = (Image)this.FindByName<Image>(_entries[i] + "_check");
                    check.IsVisible = true;
                    check.Source = "error.png";
                }
            }

            if (password.Text != password2.Text) {
                messages_box.IsVisible = true;
                validatedFrom = false;
                messages.Text = "Las contraseñas no coinciden";
            }



            if (validatedFrom) {

            }
            else {

            }
            //Regex.Replace(XML, @"\s+", "")
            
        }
    }
}