using System;
using System.Collections.Generic;
using System.Text;
using CBLPOS.Helpers;
using Xamarin.Forms;

namespace CBLPOS.Views
{
    public partial class LoginPage : ContentPage
    {


        public LoginPage()
        {
            InitializeComponent();



            RandomGenerator generator = new RandomGenerator();
            GlobalClass.myGlobalIsession = "session_" + generator.RandomString(10, false);


          
            loginButton.Clicked += LoginButton_Clicked;

            //    MessagingCenter.Subscribe<object, string>(this, "PushMessage", PushMessage);



            //}


            //void PushMessage(object sender, string message)
            //{
            //    Device.BeginInvokeOnMainThread(() =>
            //    {
            //        titleLabel.Text = message;
            //    });
            //}

          

            async void LoginButton_Clicked(object sender, EventArgs e)
            {



                var employee = await Helpers.Service.AuthenUser(usernameEntry.Text, passwordEntry.Text);

                indicator.IsVisible = false;

                if (employee != null)
                {


                    GlobalClass.myGlobalEmployee = employee.emp_code;
                    GlobalClass.myGlobalEmployeename = employee.emp_name;

                    //var mp = new MasterDetailPage();
                    //mp.Master = new MasterPage();
                    //mp.Detail = new NavigationPage(new MainPage());

                    //var app = Parent as App;
                    //app.MainPage = mp;
                    //  await App.Current.MainPage.Navigation.PushModalAsync(new MainPage());

                    await Navigation.PushModalAsync(new MainPage());
                }
                else await DisplayAlert("Warning", "Username or Password incorrect!!", "OK");


            }
        }


        public class RandomGenerator
        {



            // Generate a random string with a given size  
            public string RandomString(int size, bool lowerCase)
            {
                StringBuilder builder = new StringBuilder();
                Random random = new Random();
                char ch;
                for (int i = 0; i < size; i++)
                {
                    ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                    builder.Append(ch);
                }
                if (lowerCase)
                    return builder.ToString().ToLower();
                return builder.ToString();
            }



        }
    }
}