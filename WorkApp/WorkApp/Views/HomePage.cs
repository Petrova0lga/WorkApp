using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace WorkApp.Views
{
    public class HomePage : ContentPage
    {
        public HomePage()
        {
            this.Title = "Select Option";

            StackLayout stackLayout = new StackLayout();
            Button button = new Button();
            button.Text = "Add Worker";
            button.Clicked += Button_Clicked;      
            stackLayout.Children.Add(button);

            button =new Button();
            button.Text = "Get";
            button.Clicked += Button_Get_Clicked;
            stackLayout.Children.Add(button);

            button = new Button();
            button.Text = "Update";
            button.Clicked += Button_Update_Clicked;
            stackLayout.Children.Add(button);

            button = new Button();
            button.Text = "Delete";
            button.Clicked += Button_Delete_Clicked;
            stackLayout.Children.Add(button);

            Content = stackLayout;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddWorkerPage());
        }

        private async void Button_Get_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GetAllWorkersPage());
        }

        private async void Button_Update_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UpdateWorkerPage());
        }

        private async void Button_Delete_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeleteWorkerPage());
        }
    }
}