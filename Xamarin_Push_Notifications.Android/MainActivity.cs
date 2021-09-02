using System;
using WindowsAzure.Messaging.NotificationHubs;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Xamarin_Push_Notifications.Droid.Listeners;

namespace Xamarin_Push_Notifications.Droid
{
    [Activity(Label = "Xamarin_Push_Notifications", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        internal static readonly string CHANNEL_ID = "my_notification_channel";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            // Listen for push notifications
            NotificationHub.SetListener(new AzureListener());

            // Start the SDK
            NotificationHub.Start(this.Application, Constants.NotificationHubName, Constants.ListenConnectionString);

            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}