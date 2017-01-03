using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;

namespace InstallDemo
{
     class Help_Page : ContentPage   
    {
        public Help_Page()
        {
            Label ContactLabel = new Label
            {
                Text = "Have suggestions or a problem to report?\n"+ "Contact us here:",
                TextColor = Color.Purple,
                HorizontalTextAlignment = TextAlignment.Start,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            Button ContactButton = new Button {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Text = "Contact Us",
            };

            ContactButton.Clicked += (sender, e) =>
            {
                Device.OpenUri(new Uri("mailto:brandonbest94@live.ca"));//change to a support email like napchat_support@gmail.com
            };

            Label AboutLabel = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Text = "About",
                TextColor = Color.Purple,
                FontAttributes = FontAttributes.Italic,
            };
            //Ads
            //Privacy Policy
            //Change Password
            //Logout
            //Log out button
            Button LogOutbtn;
            LogOutbtn = new Button
            {
                Text = "Log Out",
            };
            LogOutbtn.Clicked += async (sender, args) => await Navigation.PopAsync();

            StackLayout HelpLayout = new StackLayout
            {
                Children = {ContactLabel,ContactButton, AboutLabel, LogOutbtn}
            };
            //OutlineColor = Color.White;
            BackgroundColor = Color.White;
            Content = HelpLayout;
        }
       
    }
}
