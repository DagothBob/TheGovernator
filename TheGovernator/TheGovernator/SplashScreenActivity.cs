using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading.Tasks;
using Android.Util;

namespace TheGovernator
{
    [Activity(Label = "SplashScreen", MainLauncher = true)]
    public class SplashScreenActivity : Activity
    {
        static readonly string TAG = "X:" + typeof(SplashScreenActivity).Name;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.SplashScreenLayout);

            //OverridePendingTransition(Resource.Anim.left_in, Resource.Anim.left_out);

            // Create your application here
        }

        // Launches the startup task
        protected override void OnResume()
        {
            base.OnResume();
            Task startupWork = new Task(() => { SimulateStartup(); });
            startupWork.Start();
        }

        // Simulates background work that happens behind the splash screen
        async void SimulateStartup()
        {
            await Task.Delay(750); // Simulate a bit of startup work.
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }
    }
}