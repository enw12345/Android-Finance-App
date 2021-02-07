using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Finance_App
{
    [Activity(Label = "InvestOptions")]
    public class InvestOptionsACtivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_options_invest);

            //Buttons
            Button howMuchNeedButton = FindViewById<Button>( Resource.Id.how_much_need_button);
            Button howMuchSaveButton = FindViewById<Button>(Resource.Id.how_much_have_button);

            howMuchNeedButton.Click += (sender, e) => {
                var intent = new Intent(this, typeof(InvestHowMuchSaveActivity));
                StartActivity(intent);
            };

            howMuchSaveButton.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(InvestActivity));
                StartActivity(intent);
            };
        }
    }
}