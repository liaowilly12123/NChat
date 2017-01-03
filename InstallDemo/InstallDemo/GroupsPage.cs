using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLitePCL;
using SQLite;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace InstallDemo
{
   
        //Groups Page
        public class GroupsPage : ContentPage

        {
        //local database connection
        private readonly SQLiteConnection database;

        //object populating the listview
        public class GroupItem
        {
            public string Title { get; set; }
        }


        public GroupsPage()
            {

            //Add group button, make at top of page
            ToolbarItems.Add(new ToolbarItem("Add", "icon.png", async () => await Navigation.PushAsync(new ContactList())));
           

            //Groups need to be an Observableitem so rows can be edited and deleted
            var GroupsList = new ListView();
             
            GroupsList.RowHeight = 65;
           
            GroupsList.ItemsSource = new GroupItem[]
            {
                /*
                for (i in Groups){
                  var addedItem = new GroupItem;
                  addedItem.Title = i.groupName;
                  }
                 */
                new GroupItem  { Title = "Group1"},
                new GroupItem  { Title = "Group2"},
                new GroupItem {Title ="Group3" }
            };

            GroupsList.IsPullToRefreshEnabled = true;

           
            GroupsList.SeparatorColor = Color.Purple;
            GroupsList.BackgroundColor = Color.White;
            GroupsList.ItemTemplate = new DataTemplate(typeof(Grouping));
            GroupsList.ItemTemplate.SetBinding(Grouping.BindingContextProperty, "Title");

            GroupsList.ItemTapped += async (sender, e) =>
            {
                //opens up list page listing all contacts in the group
                await DisplayAlert("Tapped", e.Item.ToString() + " was selected.", "OK");

                ((ListView)sender).SelectedItem = null;
            };
            this.Content = GroupsList;
            BindingContext = GroupsList.ItemsSource; 
                
                

            }
        }

    class Grouping : ViewCell
    {
        public Grouping()
        {
            Label GroupLabel = new Label
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontSize = 25,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.Purple,

            };

            GroupLabel.SetBinding(Label.TextProperty, "Title");
            //Add more and delete buttons here

            //layout for each group button panel
            StackLayout GroupPanel = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.White,
                //add option buttons as well
                Children = { GroupLabel }
            };
            //layout for all the panels
            StackLayout GroupLayout = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Orientation = StackOrientation.Horizontal,
                Padding = new Thickness(25, 10, 55, 15),
                Children = { GroupPanel }
            };

            //edit and delete options
           
            var editAction = new MenuItem { Text = "Edit" };
            editAction.SetBinding(MenuItem.CommandParameterProperty, new Binding("."));
            //edit button should open page listing contacts in the group with delete option beside their name, and an add button at the top which opens contacts page to add contacts to that group
            editAction.Clicked += (sender, e) =>
            {
               var mi = ((MenuItem)sender);
               var item = (GroupsPage.GroupItem)mi.CommandParameter;
                Debug.WriteLine("Edit clicked on row" + item.Title.ToString());
              
            };
            
            ContextActions.Add(editAction);
           
            var deleteAction = new MenuItem { Text = "Delete", IsDestructive = true };
            deleteAction.SetBinding(MenuItem.CommandParameterProperty, new Binding("."));
            deleteAction.Clicked += (sender, e) =>
            {
                var di = ((MenuItem)sender);
                var Ditem = (GroupsPage.GroupItem)di.CommandParameter;
                Debug.WriteLine("Delete clicked on row" + Ditem.Title.ToString());
                // needs to remove group from saved database

                
            };
            ContextActions.Add(deleteAction);
            

            View = GroupLayout;

        }


    }


}

