using PassManager.Models;
using System;
using Xamarin.Forms;
using SQLite;
using Password_Manager;

namespace PassManager.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string text;
        private string description;
        private string infoNumber;
        private string password;
        private string infoAdress;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(text)
                && !String.IsNullOrWhiteSpace(description)
                && !String.IsNullOrWhiteSpace(infoNumber)
                && !String.IsNullOrWhiteSpace(password) 
                && Text.Length > 1 ;
        }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public string InfoNumber
        {
            get => infoNumber;
            set => SetProperty(ref infoNumber, value);
        }

        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        public string InfoAdress
        {
            get => infoAdress;
            set => SetProperty(ref infoAdress, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Text = Text,
                Description = Description,
                InfoNumber = InfoNumber,
                Password = Password,
                InfoAdress = InfoAdress
            };

            using (SQLiteConnection connect = new SQLiteConnection(Constants.DatabasePath))
            {
                connect.CreateTable<Item>();
                connect.Insert(newItem);
            }

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
