using PassManager.Models;
using System;
using System.Diagnostics;
using Xamarin.Forms;
using SQLite;
using Password_Manager;
using System.Threading.Tasks;

namespace PassManager.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private int PKey;
        private string itemId;
        private string text;
        private string description;
        private string infoNumber;
        private string password;
        private string infoAdress;
        public string Id { get; set; }

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

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId)
        {
            await Task.FromResult(true);
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                PKey = item.PKey;
                Id = item.Id;
                Text = item.Text;
                Description = item.Description;
                InfoNumber = item.InfoNumber;
                Password = item.Password;
                InfoAdress = item.InfoAdress;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }


        internal void DeleteItemCommand()
        {
            using(SQLiteConnection dell = new SQLiteConnection(Constants.DatabasePath))
            {
                dell.Delete<Item>(PKey);
            }
            DataStore.DeleteItemAsync(ItemId);

            Shell.Current.GoToAsync("..");
        }

        public void Updateİnfo()
        {
            Item updateItem = new Item()
            {
                PKey = PKey,
                Id = Id,
                Text = Text,
                Description = Description,
                InfoNumber = InfoNumber,
                Password = Password,
                InfoAdress = InfoAdress
            };

            using (SQLiteConnection update = new SQLiteConnection(Constants.DatabasePath))
            {
                update.Update(updateItem);
            }

            DataStore.UpdateItemAsync(updateItem);
        }

    }
}
