using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLitePCL;
using Xamarin.Forms;
using System.IO;
using System.Xml.Linq;

namespace InstallDemo
{

    

    class LogInPage : ContentPage
    {
        //Controls for Log in Page with logo, log in button, forgot pasword button, and sign up button

        Button LogInbtn;
        Button FrgtPass;
        Button SignUpbtn;
        Entry EmailEntry;
        public LogInPage()
        {

            var NCLogo = new Image
            {
                Source = "NapChat_Logo.png",
                Aspect = Aspect.AspectFit,
                HorizontalOptions = LayoutOptions.Center,

            };

           var EmailEntry = new Entry
            {
                Placeholder = "email",
                PlaceholderColor = Color.FromHex("cccccc"),
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                WidthRequest = 300,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Keyboard =Keyboard.Email,
            };

            var PassEntry = new Entry
            {
                Placeholder = "Password",
                PlaceholderColor = Color.FromHex("cccccc"),
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                WidthRequest = 300,
                Keyboard = Keyboard.Text,
            };
            PassEntry.IsPassword = true;
            Label NapChat_Label = new Label
            {
                Text = "Napchat",
                TextColor = Color.White,
                FontSize = 25,
                HorizontalTextAlignment = TextAlignment.Center

            };
            LogInbtn = new Button
            {
                Text = "Log In",

                HorizontalOptions = LayoutOptions.CenterAndExpand


            };

            //log in button event handler
            LogInbtn.Clicked += async (sender, args) => await Navigation.PushAsync(new HomePage());
            //Forgot Password button
            FrgtPass = new Button
            {
                Text = "Forgot Password?",
                TextColor = Color.White,
            };
            //forgot password button tapped handler
            FrgtPass.Clicked += (sender, args) =>
            {
                FrgtPass.Text = "Oops!";
                FrgtPass.TextColor = Color.Blue;
            };
            //Sign up button
            SignUpbtn = new Button
            {
                Text = "Sign Up",
                TextColor = Color.White
            };
            //clicked event handler sending to sign up page
            SignUpbtn.Clicked += async (sender, args) => await Navigation.PushAsync(new SignUpPage());

            //Layout for Sign In
            StackLayout SignInLayout = new StackLayout
            {
                Children = { NapChat_Label, NCLogo, EmailEntry, PassEntry, LogInbtn, FrgtPass, SignUpbtn }
            };

            //background RGB hex is 55004A
            BackgroundColor = Color.FromHex("55004A");
            this.Content = SignInLayout;
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}

