using System.Threading.Tasks;
using AndroidTP1.Services;
using AndroidTP1.Utils;
using AndroidTP1.Views;
using Xamarin.Forms;

namespace AndroidTP1.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public Command LoginCommand { get; }
        public Command RegisterCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await LoginExecute());
            RegisterCommand = new Command(async () => await RegisterExecute());
        }

        private async Task LoginExecute()
        {
            if (string.IsNullOrEmpty(Login))
            {
                Toast.Show("Veuillez renseigner un identifiant");
                return;
            }

            if (string.IsNullOrEmpty(Password))
            {
                Toast.Show("Veuillez renseigner un mot de passe");
                return;
            }

            var response = Accounts.Login(Login, Password);

            if (response.Success)
            {
                Session.User = response.Account;
                await Navigation.Push(new ProfilePage());
            }
            else
                Toast.Show(response.Message);
        }

        private async Task RegisterExecute()
        {
            await Navigation.Push(new RegisterPage());
        }
    }
}
