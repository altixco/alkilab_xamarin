﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace alkilab
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            PushLoginPage();
        }

        async void PushLoginPage() {
            await Navigation.PushModalAsync(new LoginPage());
        }
    }
}
