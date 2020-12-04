using Xamarin.Forms;

namespace AndroidTP1.Services
{
    public interface IToast
    {
        void Show(string message);
    }

    public static class Toast
    {
        public static void Show(string message) => DependencyService.Get<IToast>().Show(message);
    }
}
