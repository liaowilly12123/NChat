using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;


namespace InstallDemo
{
    class SignUpPage : ContentPage
    {
        Entry FirstName;
        Entry LastName;
        Entry EmailSU;
        Entry PasswordSU;
        Entry VerifyPassword;
        Button SignUp;
        public SignUpPage()
        {
            Title = "Sign Up";

            FirstName = new Entry
            {
                Placeholder = "First Name"

            };
            LastName = new Entry
            {
                Placeholder = "Last Name"
            };
            EmailSU = new Entry
            {
                Placeholder = "Email"
            };
            PasswordSU = new Entry
            {
                Placeholder = "Password"
            };
            VerifyPassword = new Entry
            {
                Placeholder = "Verify"
            };
            SignUp = new Button
            {
                Text = "Register",
                BorderColor = Color.Blue,
                HorizontalOptions = LayoutOptions.Center
            };
            StackLayout RegisterLayout = new StackLayout
            {
                Children = { FirstName, LastName, EmailSU, PasswordSU, VerifyPassword, SignUp }
            };
            this.Content = RegisterLayout;
        }
    }
}
