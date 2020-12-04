using System.Threading.Tasks;
using AndroidTP1.Models;
using AndroidTP1.Services;
using AndroidTP1.Utils;
using Xamarin.Forms;

namespace AndroidTP1.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public Command RegisterCommand { get; }

        public RegisterViewModel()
        {
            RegisterCommand = new Command(async () => await RegisterExecute());
        }

        private async Task RegisterExecute()
        {
            if (string.IsNullOrEmpty(Login))
            {
                Toast.Show("Veuillez renseigner un identifiant");
                return;
            }

            if (string.IsNullOrEmpty(Name))
            {
                Toast.Show("Veuillez renseigner un mot de passe");
                return;
            }

            if (string.IsNullOrEmpty(Password))
            {
                Toast.Show("Veuillez renseigner un mot de passe");
                return;
            }

            var response = Accounts.Add(new Account(Login, Name, Password));

            if (response.Success)
                await Navigation.Pop();
            else
                Toast.Show(response.Message);
        }
    }
}
