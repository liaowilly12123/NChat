using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;


namespace InstallDemo
{
    
    //list view of contacts in phone to namek new group or to edit an existing one
    public class ContactList : ContentPage
    {
       
        public ContactList()
        {
            
            var NewGroupName = new Entry
            {
                Placeholder = "New Group Name",
                PlaceholderColor = Color.FromHex("cccccc"),
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.Start,
                Keyboard = Keyboard.Text,
            };
            
            //Okay button to confirm group choices, creates GroupData with GroupName from Entry and the selected contacts into its contact array.
            Button AcceptGroupBtn = new Button
            {
                Text = "Create",
                TextColor = Color.Purple,
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Start,
                
            };

            AcceptGroupBtn.Clicked += (sender, args) =>
            {
                var gname = NewGroupName.Text;
                //make new GroupData with the groupName attribute to gname and then call your add method to the database to add new GroupData model.
                var NewGroup = new GroupData { groupName = gname, };
                //figure out why SaveGroup method is not usable
                //database.Insert(NewGroup);
                //selected contacts are added to NewGroup.contactsarray
                Navigation.PopAsync();
            };
            StackLayout ContactsLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = {NewGroupName, AcceptGroupBtn }
            };
            this.Content = ContactsLayout;
        }
       
    }
    
}
