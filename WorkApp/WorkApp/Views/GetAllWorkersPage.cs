using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WorkApp.Models;
using Xamarin.Forms;

namespace WorkApp.Views
{
    public class GetAllWorkersPage : ContentPage
    {
        private ListView _listView;
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");
        public GetAllWorkersPage()
        {
            this.Title = "Workers";

            var db = new SQLiteConnection(_dbPath);

            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<Worker>().OrderBy(x => x.Name).ToList();

            stackLayout.Children.Add(_listView);

            Content = stackLayout;
        }
    }
}


