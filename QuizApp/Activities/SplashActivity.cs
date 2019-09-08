using Android.App;
using Android.OS;
using Android.Support.V7.App;

namespace QuizApp.Activities
{
    [Activity(Label = "@string/app_name", Theme = "@style/splashTheme", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        protected override void OnResume()
        {
            base.OnResume();

            StartActivity(typeof(MainActivity));
        }
    }
}