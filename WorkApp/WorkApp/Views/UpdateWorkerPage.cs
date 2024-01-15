using SQLite;
using System;
using System.IO;
using System.Linq;
using WorkApp.Models;
using Xamarin.Forms;

namespace WorkApp.Views
{
    public class UpdateWorkerPage : ContentPage
    {
        private ListView _listView;
        private Entry _idEntry;
        private Entry _nameEntry;
        private DatePicker _birthdayDatePicker; 
        private Entry _phoneEntry;
        private Entry _emailEntry;
        private Entry _addressEntry;
        private Button _button;

        Worker _worker = new Worker();

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");

        public UpdateWorkerPage()
        {
            this.Title = "Update Worker";

            var db = new SQLiteConnection(_dbPath);

            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<Worker>().OrderBy(x => x.Name).ToList();
            _listView.ItemSelected += _listView_ItemSelected;
            stackLayout.Children.Add(_listView);

            _idEntry = new Entry();
            _idEntry.Placeholder = "ID";
            _idEntry.IsVisible = false;
            stackLayout.Children.Add(_idEntry);

            _nameEntry = new Entry();
            _nameEntry.Keyboard = Keyboard.Text;
            _nameEntry.Placeholder = "Worker Name";
            stackLayout.Children.Add(_nameEntry);

            _birthdayDatePicker = new DatePicker(); 
            stackLayout.Children.Add(_birthdayDatePicker); 

            _phoneEntry = new Entry();
            _phoneEntry.Keyboard = Keyboard.Text;
            _phoneEntry.Placeholder = "Phone Number";
            stackLayout.Children.Add(_phoneEntry);

            _emailEntry = new Entry();
            _emailEntry.Keyboard = Keyboard.Text;
            _emailEntry.Placeholder = "Email";
            stackLayout.Children.Add(_emailEntry);

            _addressEntry = new Entry();
            _addressEntry.Keyboard = Keyboard.Text;
            _addressEntry.Placeholder = "Address";
            stackLayout.Children.Add(_addressEntry);

            _button = new Button();
            _button.Text = "Update";
            _button.Clicked += _button_Clicked;
            stackLayout.Children.Add(_button);

            Content = stackLayout;
        }

        private async void _button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_idEntry.Text) || string.IsNullOrEmpty(_nameEntry.Text) || string.IsNullOrEmpty(_phoneEntry.Text) || string.IsNullOrEmpty(_emailEntry.Text) || string.IsNullOrEmpty(_addressEntry.Text) || _birthdayDatePicker.Date == null)
            {
                await DisplayAlert("Error", "All fields must be filled", "OK");
                return;
            }
            var db = new SQLiteConnection(_dbPath);
            Worker worker = new Worker()
            {
                Id = Convert.ToInt32(_idEntry.Text),
                Name = _nameEntry.Text,
                Phone = _phoneEntry.Text,
                Email = _emailEntry.Text,
                Address = _addressEntry.Text,
                Birthday = _birthdayDatePicker.Date 
            };
            db.Update(worker);
            await Navigation.PopAsync();
        }

        private void _listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _worker = (Worker)e.SelectedItem;
            _idEntry.Text = _worker.Id.ToString();
            _nameEntry.Text = _worker.Name;
            _phoneEntry.Text = _worker.Phone;
            _emailEntry.Text = _worker.Email;
            _button.Text = _worker.Email;
            _addressEntry.Text = _worker.Address;
            _birthdayDatePicker.Date = _worker.Birthday;
        }
    }
}
