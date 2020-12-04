using Android.App;
using Android.Widget;
using AndroidTP1.Services;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidTP1.Droid.Services.ToastService))]
namespace AndroidTP1.Droid.Services
{
    public class ToastService : IToast
    {
        public void Show(string message)
        {
            Android.Widget.Toast.MakeText(Application.Context, message, ToastLength.Long)?.Show();
        }
    }
}
