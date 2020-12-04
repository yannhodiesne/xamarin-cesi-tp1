using System.Threading.Tasks;
using Xamarin.Forms;

namespace AndroidTP1.Utils
{
    public static class Navigation
    {
        private static INavigation Instance => Application.Current.MainPage.Navigation;

        public static async Task Push(Page page)
        {
            await Instance.PushAsync(page);
        }

        public static async Task Pop(bool animated = true)
        {
            await Instance.PopAsync(animated);
        }

        public static async Task PopToRoot(bool animated = true)
        {
            await Instance.PopToRootAsync(animated);
        }
    }
}
