using Android.App;
using System;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Xamarin.Essentials;
using Android.Content;
using System.Linq;

namespace CheckInternet
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            var profiles = Connectivity.ConnectionProfiles;
            if (profiles.Contains(ConnectionProfile.WiFi))
            {
                // Active Wi-Fi connection.
            }

            // Check internet connection
            var current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
            {
                var Intent = new Intent(this, typeof(Activity1));
                StartActivity(Intent);
                // Connection to internet is available
            }
            else if(current != NetworkAccess.Internet)
            {
                var Intent = new Intent(this, typeof(Activity2));
                StartActivity(Intent);
                // Connection to internet is not available
            }
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
        }

        void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs args)
        {
            var acces = args.NetworkAccess;
            var profiles = args.ConnectionProfiles;
        }
    }
}