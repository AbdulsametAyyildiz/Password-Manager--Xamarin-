using PassManager.ViewModels;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PassManager.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public string Text { get; set; }
        private string oldCat;
        private string oldInfoN;
        private string oldInfoNum;
        private string oldPass;
        private string oldAdress;

        readonly ItemDetailViewModel _viewModel;

        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ItemDetailViewModel();
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (_viewModel.InfoAdress != null && !Equals("", _viewModel.InfoAdress)) LinkFrame.IsVisible = true;
            else LinkFrame.IsVisible = false;
        }

        [Obsolete]
        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            try 
            {
                Device.OpenUri(new Uri(linkAdress.Text));
            }
            catch (Exception){}

        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            OnAlertYesNoClicked(sender, e);
            
        }

        async void OnAlertYesNoClicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("", "Bu öğeyi silmek istiyor musunuz?", "Sil", "İptal");
            if(answer) _viewModel.DeleteItemCommand();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Clipboard.SetTextAsync(InfoLabel.Text);
            OnClipboardContentChanged("Kullanıcı Adı/No"); 
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Clipboard.SetTextAsync(PassLabel.Text);
            OnClipboardContentChanged( "Şifre");
        }

        void OnClipboardContentChanged( string dataName)
        {
            DisplayAlert("", dataName + " başarıyla kopyalandı", "", "Tamam");
        }

        private void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {
            Cat.IsVisible = false;
            oldCat = Cat.Text;
            CatEditor.IsVisible = true;

            InfoN.IsVisible = false;
            oldInfoN = InfoN.Text;
            InfoNEditor.IsVisible = true;

            InfoLabel.IsVisible = false;
            oldInfoNum = InfoLabel.Text;
            InfoNumEditor.IsVisible = true;

            PassLabel.IsVisible = false;
            oldPass = PassLabel.Text;
            PassEditor.IsVisible = true;

            linkAdress.IsVisible = false;
            oldAdress = linkAdress.Text;
            AdressEditor.IsVisible = true;

            PassCopy.IsVisible = false;
            InfoCopy.IsVisible = false;

            ChangeBtn.IsEnabled = false;
            BtnLayout.IsVisible = true;
            SaveBtn.IsEnabled = false;

            LinkFrame.IsVisible = true;
        }

        private void CancelBtn_Clicked(object sender, EventArgs e)
        {

            Cat.IsVisible = true;
            _viewModel.Text = oldCat;
            CatEditor.IsVisible = false;

            InfoN.IsVisible = true;
            _viewModel.Description = oldInfoN;
            InfoNEditor.IsVisible = false;

            InfoLabel.IsVisible = true;
            _viewModel.InfoNumber = oldInfoNum;
            InfoNumEditor.IsVisible = false;

            PassLabel.IsVisible = true;
            _viewModel.Password = oldPass;
            PassEditor.IsVisible = false;

            linkAdress.IsVisible = true;
            _viewModel.InfoAdress = oldAdress;
            AdressEditor.IsVisible = false;

            PassCopy.IsVisible = true;
            InfoCopy.IsVisible = true;

            ChangeBtn.IsEnabled = true;
            BtnLayout.IsVisible = false;

            if (_viewModel.InfoAdress != null && !Equals("", _viewModel.InfoAdress)) LinkFrame.IsVisible = true;
            else LinkFrame.IsVisible = false;
        }

        private void SaveBtn_Clicked(object sender, EventArgs e)
        {
            _viewModel.Updateİnfo();

            Cat.IsVisible = true;
            CatEditor.IsVisible = false;

            InfoN.IsVisible = true;
            InfoNEditor.IsVisible = false;

            InfoLabel.IsVisible = true;
            InfoNumEditor.IsVisible = false;

            PassLabel.IsVisible = true;
            PassEditor.IsVisible = false;

            linkAdress.IsVisible = true;
            AdressEditor.IsVisible = false;

            PassCopy.IsVisible = true;
            InfoCopy.IsVisible = true;

            ChangeBtn.IsEnabled = true;
            BtnLayout.IsVisible = false;

            if (_viewModel.InfoAdress != null && !Equals("", _viewModel.InfoAdress)) LinkFrame.IsVisible = true;
            else LinkFrame.IsVisible = false;
        }

        private void CatEditor_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            if (e.NewTextValue.Length > 1)
            {
                if(!Equals(_viewModel.Text,oldCat)|| !Equals(_viewModel.Description, oldInfoN)
                    || !Equals(_viewModel.InfoNumber, oldInfoNum) || !Equals(_viewModel.Password, oldPass)
                    || !Equals(_viewModel.InfoAdress, oldAdress)) SaveBtn.IsEnabled = true;
                else SaveBtn.IsEnabled = false;

            } else SaveBtn.IsEnabled = false;
        }

        private void InfoNEditor_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length > 0)
            {
                if (!Equals(_viewModel.Text, oldCat) || !Equals(_viewModel.Description, oldInfoN)
                    || !Equals(_viewModel.InfoNumber, oldInfoNum) || !Equals(_viewModel.Password, oldPass)
                    || !Equals(_viewModel.InfoAdress, oldAdress)) SaveBtn.IsEnabled = true;
                else SaveBtn.IsEnabled = false;

            }
            else SaveBtn.IsEnabled = false;
        }

        private void InfoNumEditor_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length > 0)
            {
                if (!Equals(_viewModel.Text, oldCat) || !Equals(_viewModel.Description, oldInfoN)
                    || !Equals(_viewModel.InfoNumber, oldInfoNum) || !Equals(_viewModel.Password, oldPass)
                    || !Equals(_viewModel.InfoAdress, oldAdress)) SaveBtn.IsEnabled = true;
                else SaveBtn.IsEnabled = false;

            }
            else SaveBtn.IsEnabled = false;
        }

        private void PassEditor_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length > 0)
            {
                if (!Equals(_viewModel.Text, oldCat) || !Equals(_viewModel.Description, oldInfoN)
                    || !Equals(_viewModel.InfoNumber, oldInfoNum) || !Equals(_viewModel.Password, oldPass)
                    || !Equals(_viewModel.InfoAdress, oldAdress)) SaveBtn.IsEnabled = true;
                else SaveBtn.IsEnabled = false;

            }
            else SaveBtn.IsEnabled = false;
        }

        private void AdressEditor_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (!Equals(_viewModel.Text, oldCat) || !Equals(_viewModel.Description, oldInfoN)
                || !Equals(_viewModel.InfoNumber, oldInfoNum) || !Equals(_viewModel.Password, oldPass)
                || !Equals(_viewModel.InfoAdress, oldAdress)) SaveBtn.IsEnabled = true;
            else SaveBtn.IsEnabled = false;

        }
    }
}