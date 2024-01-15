using System;
using System.IO;
using WorkApp.Models;
using Xamarin.Forms;
using SQLite;

namespace WorkApp.Views
{
    public class AddWorkerPage : ContentPage
    {
        private Entry _nameEntry;
        private DatePicker _birthdayDatePicker;
        private Entry _idEntry;
        private Entry _phoneEntry;
        private Entry _emailEntry;
        private Entry _addressEntry;
        private Button _saveButton;

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");

        public AddWorkerPage()
        {
            this.Title = "Add Worker";

            StackLayout stackLayout = new StackLayout();

            _nameEntry = new Entry();
            _nameEntry.Keyboard = Keyboard.Text;
            _nameEntry.Placeholder = "Name";
            stackLayout.Children.Add(_nameEntry);

            _birthdayDatePicker = new DatePicker();
            _birthdayDatePicker.DateSelected += (sender, e) => { };
            stackLayout.Children.Add(_birthdayDatePicker);

            _idEntry = new Entry();
            _idEntry.Keyboard = Keyboard.Text;
            _idEntry.Placeholder = "Identity Code";
            stackLayout.Children.Add(_idEntry);

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

            _saveButton = new Button();
            _saveButton.Text = "Add";
            _saveButton.Clicked += _saveButton_Clicked;
            stackLayout.Children.Add(_saveButton);

            Content = stackLayout;
        }

        private async void _saveButton_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_nameEntry.Text) || _birthdayDatePicker.Date == null || string.IsNullOrEmpty(_idEntry.Text) || string.IsNullOrEmpty(_phoneEntry.Text) || string.IsNullOrEmpty(_emailEntry.Text) || string.IsNullOrEmpty(_addressEntry.Text))
            {
                await DisplayAlert("Error", "All fields must be filled", "OK");
                return;
            }

            var db = new SQLiteConnection(_dbPath);
            db.CreateTable<Worker>();

            var maxPk = db.Table<Worker>().OrderByDescending(c => c.Id).FirstOrDefault();

            Worker worker = new Worker()
            {
                Id = (maxPk == null ? 1 : maxPk.Id + 1),
                Birthday = _birthdayDatePicker.Date,
                Name = _nameEntry.Text,
                Phone = _phoneEntry.Text,
                Email = _emailEntry.Text,
                Address = _addressEntry.Text,
            };
            db.Insert(worker);
            await DisplayAlert(null, worker.Name + " Added", "Ok");
            await Navigation.PopAsync();
        }
    }
}
