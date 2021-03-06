﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleCalculator.ViewModels;
using Xamarin.Forms;

namespace SimpleCalculator
{
    public partial class App : Application
    {
        public App() {
            InitializeComponent();

            MainPage = new MainPage();
            var vm = new MainPageVm(DependencyService.Get<IExpressionCalculator>());
            MainPage.BindingContext = vm;
        }

        protected override void OnStart() {
            // Handle when your app starts
        }

        protected override void OnSleep() {
            // Handle when your app sleeps
        }

        protected override void OnResume() {
            // Handle when your app resumes
        }
    }
}
