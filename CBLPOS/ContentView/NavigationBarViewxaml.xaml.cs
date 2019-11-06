using System;
using System.Collections.Generic;
using CBLPOS.Views;
using Xamarin.Forms;

namespace CBLPOS.ContentView
{
    public partial class NavigationBarViewxaml : Xamarin.Forms.ContentView
    {
        public NavigationBarViewxaml()
        {
            InitializeComponent();
        }
        public Label FirstNameLabel
        {
            get
            {
                return labelText;
            }
        }
        private void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
        public static readonly BindableProperty TitleProperty =
        BindableProperty.Create(
        "Title",
        typeof(string),
        typeof(NavigationBarViewxaml),
        "this is Title",
        propertyChanged: OnTitlePropertyChanged
        );
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        static void OnTitlePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var thisView = bindable as NavigationBarViewxaml;
            var title = newValue.ToString();
            thisView.lblTitle.Text = title;
        }
        private void Tapcart_OnTapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}