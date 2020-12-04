using System.Collections.Generic;
using System.Threading.Tasks;
using AndroidTP1.Models;
using AndroidTP1.Services;
using AndroidTP1.Utils;
using Xamarin.Forms;

namespace AndroidTP1.ViewModels
{
    public class AccountsViewModel : BaseViewModel
    {
        public List<Account> AccountsList => Accounts.AllAccounts;

        public Command LogoutCommand { get; }
        public Command<string> RemoveCommand { get; }

        public AccountsViewModel()
        {
            LogoutCommand = new Command(async () => await LogoutExecute());
            RemoveCommand = new Command<string>(async login => await RemoveExecute(login));
        }

        private async Task LogoutExecute()
        {
            Session.User = null;
            await Navigation.PopToRoot();
        }

        private async Task RemoveExecute(string login)
        {
            Accounts.Remove(login);
            OnPropertyChanged(nameof(AccountsList));

            if (login == Session.User.Login)
            {
                Toast.Show("Vous avez supprimé votre propre compte !");
                await LogoutExecute();
            }
        }
    }
}
