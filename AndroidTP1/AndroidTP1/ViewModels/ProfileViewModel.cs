using System;
using System.Threading.Tasks;
using AndroidTP1.Utils;
using AndroidTP1.Views;
using Xamarin.Forms;

namespace AndroidTP1.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        public string Username => Session.User.Name;

        public ImageSource ProfilePicture { get; } = ImageSource.FromUri(new Uri("https://source.unsplash.com/random"));

        public Command AccountsCommand { get; }
        public Command LogoutCommand { get; }

        public ProfileViewModel()
        {
            AccountsCommand = new Command(async () => await AccountsExecute());
            LogoutCommand = new Command(async () => await LogoutExecute());
        }

        private async Task AccountsExecute()
        {
            await Navigation.Push(new AccountsPage());
        }

        private async Task LogoutExecute()
        {
            Session.User = null;
            await Navigation.PopToRoot();
        }
    }
}
