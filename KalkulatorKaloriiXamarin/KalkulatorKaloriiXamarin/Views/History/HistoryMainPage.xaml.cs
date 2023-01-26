﻿using KalkulatorKaloriiXamarin.ViewModels.History;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KalkulatorKaloriiXamarin.Views.History
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryMainPage : ContentPage
    {
        public HistoryMainPage()
        {
            InitializeComponent();
            this.BindingContext = new HistoryMainViewModel();
        }
    }
}