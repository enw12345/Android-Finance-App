using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;

namespace Finance_App
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            //Get the UI controls
            Button investButton = FindViewById<Button>(Resource.Id.InvestButton);
            Button borrowButton = FindViewById<Button>(Resource.Id.BorrowButton);

            investButton.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(InvestActivity));
                StartActivity(intent);
            };

            borrowButton.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(InvestActivity));
                StartActivity(intent);
            };
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}