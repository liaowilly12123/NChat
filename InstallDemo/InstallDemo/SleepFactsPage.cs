using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace InstallDemo
{
   
        class SleepFactsPage : CarouselPage
        {
            public SleepFactsPage()
            {
                this.Children.Add(new FactPage1());
                this.Children.Add(new FactPage2());
            }
        }


    //page for Sleep fact page
    public class FactPage1 : ContentPage
    {
        public FactPage1()
        {
            BoxView image = new BoxView
            {
                Color = Color.Black,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,

            };
            Label Fact_info = new Label
            {
                Text = "This displays the fact \n" + "and the appropriate citation",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            StackLayout FactLayout = new StackLayout
            {
                Children = { image, Fact_info }

            };
            Content = FactLayout;
            BackgroundColor = Color.FromHex("dab3ff");
        }
    }

    //
    public class FactPage2 : ContentPage
    {
        public FactPage2()
        {
            BoxView image = new BoxView
            {
                Color = Color.Black,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,

            };
            Label Fact_info = new Label
            {
                Text = "This displays the fact \n" + "and the appropriate citation",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            StackLayout FactLayout = new StackLayout
            {
                Children = { image, Fact_info }
            };
            BackgroundColor = Color.FromHex("dab3ff");
            Content = FactLayout;
        }
    }


}

