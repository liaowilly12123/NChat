﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;

namespace InstallDemo
{
    public class App : Application
    {
        public App()
        {
            MainPage = new NavigationPage(new LogInPage());
           // MainPage.BarBackgroundColor = Color.FromHex("55004A");
            //MainPage.BarTextColor = Color.White;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
   
   
}
