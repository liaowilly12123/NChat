using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace InstallDemo
{
    /*
    class Home : NavigationPage
    {
        
        public Home() : base(new HomePage())
        {
            //Nav bar has no back button and color,text color must be changed

            BarBackgroundColor = Color.FromHex("55004A");
            BarTextColor = Color.White;
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
    */
    public class HomePage : ContentPage
    {
        public HomePage()
        {
            Title = "Home";

            //Groups Button Icon
            Label Groups_Label = new Label
            {
                Text = "Groups",
                TextColor = Color.White
            };
            var Groups_btn = new Image
            {
                Source = "Icon60.png",
                HeightRequest = 100,
                WidthRequest = 100,
            };
            var Groups_Tap = new TapGestureRecognizer();
            Groups_Tap.Tapped += async (sender, args) => await Navigation.PushAsync(new GroupsPage());
            Groups_btn.GestureRecognizers.Add(Groups_Tap);
            //NapTime button icon
            Label Naptime_label = new Label
            {
                Text = "Naptime",
                TextColor = Color.White

            };
            var Naptime_btn = new Image
            {
                Source = "Naptimebtn_Icon.png",
                HeightRequest = 100,
                WidthRequest = 100
            };
            var Naptime_Tap = new TapGestureRecognizer();
            Naptime_Tap.Tapped += async (sender, args) => await Navigation.PushAsync(new Naptime_Page());
            Naptime_btn.GestureRecognizers.Add(Naptime_Tap);
            //sleep facts icon button
            var SleepFacts = new Image
            {
                Source = "Icon-60.png",
                HeightRequest = 100,
                WidthRequest = 100
            };
            Label SleepFacts_label = new Label
            {
                Text = "Sleep Facts",
                TextColor = Color.White
            };
            //sleep facts tapped event handler
            var SleepFacts_Tap = new TapGestureRecognizer();
            SleepFacts_Tap.Tapped += async (sender, args) => await Navigation.PushAsync(new SleepFactsPage());
            SleepFacts.GestureRecognizers.Add(SleepFacts_Tap);


            //Help icon button
            var Helpbtn = new Image
            {
                Source = "Helpbtn_Icon.png",
                HeightRequest = 100,
                WidthRequest = 100

            };
            Label Help_label = new Label
            {
                Text = "Help",
                TextColor = Color.White
            };
            //gesture recognizer event handler
            var Helpbtn_Tap = new TapGestureRecognizer();
            Helpbtn_Tap.Tapped += async (sender, args) => await Navigation.PushAsync(new Help_Page());
            
            Helpbtn.GestureRecognizers.Add(Helpbtn_Tap);
           
            //Relative Layout view coordinates
            RelativeLayout HomePageLayout = new RelativeLayout();
            HomePageLayout.Children.Add(Helpbtn, Constraint.Constant(20), Constraint.Constant(150));
            
            HomePageLayout.Children.Add(SleepFacts, Constraint.Constant(260), Constraint.Constant(15));
            HomePageLayout.Children.Add(Naptime_btn, Constraint.Constant(145), Constraint.Constant(15));
            HomePageLayout.Children.Add(Naptime_label, Constraint.Constant(163), Constraint.RelativeToView(Naptime_btn, (parent, sibling) => { return sibling.Y + sibling.Height; }));
            HomePageLayout.Children.Add(SleepFacts_label, Constraint.Constant(265), Constraint.RelativeToView(SleepFacts, (parent, sibling) => { return sibling.Y + sibling.Height; }));
            HomePageLayout.Children.Add(Help_label, Constraint.Constant(50), Constraint.RelativeToView(Helpbtn, (parent, sibling) => { return sibling.Y + sibling.Height; }));
            HomePageLayout.Children.Add(Groups_btn, Constraint.Constant(20), Constraint.Constant(15));
            HomePageLayout.Children.Add(Groups_Label, Constraint.Constant(40), Constraint.RelativeToView(Groups_btn, (parent, sibling) => { return sibling.Y + sibling.Height; }));
            BackgroundColor = Color.FromHex("dab3ff");
            NavigationPage.SetHasBackButton(this, false);
            //white frame implmentation
            //this.Content = new Frame {
            Content = HomePageLayout;
            //OutlineColor = Color.White
            //};


        }
    }
}
