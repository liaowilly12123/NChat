using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;

namespace InstallDemo
{
    class Naptime_Page : TabbedPage
    {
        private readonly SQLiteConnection database;
    public Naptime_Page()
        {
            this.Title = "Naptime";
            this.Children.Add(new AlertsTab());
            this.Children.Add(new NaptimeTab());
           // this.Children.Add(new AlarmSetTab());

        }    
    }
    //Alerts tab has a drill down list of notifications of when people went to sleep using custom list view cells
    public class AlertsTab : ContentPage
    {
        public class Alertitem {
            public string Title { get; set; }
            public string Time { get; set; }
            }

        public AlertsTab()
        {
            Title = "Alerts";
            //Clear all button to clear list of alerts
            ListView AlertsList = new ListView();
            AlertsList.RowHeight = 60;
            AlertsList.ItemsSource = new Alertitem[]
            {
                new Alertitem {Title = "Sleeper Name", Time = "Time they slept" }
            };
            AlertsList.SeparatorColor = Color.Purple;
            AlertsList.BackgroundColor = Color.White;
            AlertsList.ItemTemplate = new DataTemplate(typeof(AlertView));
        }
    }

    public class AlertView : TextCell
    {
        public AlertView()
        {
            Label SleepName = new Label
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontSize = 25,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.Purple,
            };
            SleepName.SetBinding(Label.TextProperty, "Title");

            Label TimeSleeping = new Label
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontSize = 12,
                TextColor = Color.Purple,
            };
            TimeSleeping.SetBinding(Label.TextProperty, "Time");

            StackLayout AlertLayout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Orientation = StackOrientation.Vertical,
                Children = {SleepName, TimeSleeping}
            };
        }

    }
    //Naptime tab has groups with switch that invokes a pop up modal with time picker to activate sleep, Group custom view cells to ge taken from GroupsPage.cs

    public class NaptimeTab : ContentPage
    {
        public class NapGroup
        {
            public string Title { get; set; }

        }
        public NaptimeTab()
        {
            Title = "Naptime";
            ListView NapGroupsList = new ListView();
            NapGroupsList.RowHeight = 65;
            NapGroupsList.ItemsSource = new NapGroup[]
            {
                new NapGroup {Title = "Group1" }
            };
            NapGroupsList.SeparatorColor = Color.Purple;
            NapGroupsList.BackgroundColor = Color.White;
            NapGroupsList.ItemTemplate = new DataTemplate(typeof(Grouping));
           // NapGroupsList.ItemTapped += async (sender, e) => await Navigation.PushModalAsync(new NapTimer());
        }
    }

    class NapGroupCell: SwitchCell
    {
        public NapGroupCell()
        {
            Label NapGroupLabel = new Label
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontSize = 25,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.Purple,

            };

            NapGroupLabel.SetBinding(Label.TextProperty, "Title");
          

            

            //layout for each group button panel
            StackLayout NapGroupPanel = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.White,
                //add option buttons as well
                Children = { NapGroupLabel }
            };
            //layout for all the panels
            StackLayout NapGroupLayout = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Orientation = StackOrientation.Horizontal,
                Padding = new Thickness(25, 10, 55, 15),
                Children = { NapGroupPanel }
            };

        }
    }
    /*
    public class NapTimer : ContentPage
    {
        Label tuneValue;
        Label timeValue;
        public NapTimer()
        {
            tuneValue = new Label();
            tuneValue.Text = "tune in page";
            timeValue = new Label();
            timeValue.Text = "time in page";
            Title = "Timer";
            //tune picker
            Picker tunePicker = new Picker
            {
                Title = "Tune",
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };
            //populate tune list with audio files
            var tunes = new List<string> { "Tune1", "Tune2", "Tune3" };

            foreach ( string tunechoice in tunes)
            {
                tunePicker.Items.Add(tunechoice);
            }
            tunePicker.SelectedIndexChanged += (sender, args) =>
            {
                tuneValue.Text = tunePicker.Items[tunePicker.SelectedIndex];
            };
            //time picker
            TimePicker timer = new TimePicker
            {
                Format = "T",
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            timer.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == TimePicker.TimeProperty.PropertyName)
                {
                    timeValue.Text = timer.Time.ToString();
                }
            };

            StackLayout TimerLayout = new StackLayout
            {
                Children = {tunePicker , timer}
            };
            Content = TimerLayout;
        }
        
    }
    */
}
