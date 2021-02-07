using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using System;

namespace Finance_App
{
    [Activity(Label = "InvestHowMuchSave")]
    public class InvestHowMuchSaveActivity : Activity
    {
        Invest invest;
        double desiredAmount;
        double presentValue;
        double rate;
        int time;
        bool changeRateToMonths;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_invest_how_much_to_save);

            EditText desiredAmountText = FindViewById<EditText>(Resource.Id.desired_amount_editText);
            EditText currentSavingsText = FindViewById<EditText>(Resource.Id.present_value_desired_amount_editText);
            EditText annualRateText = FindViewById<EditText>(Resource.Id.rate_desired_amount_editText);
            EditText timeText = FindViewById<EditText>(Resource.Id.time_desired_amount_editText);

            RadioButton yearButton = FindViewById<RadioButton>(Resource.Id.year_desired_amount_radioButton);
            RadioButton monthButton = FindViewById<RadioButton>(Resource.Id.month_desired_amount_radioButton);
            Button calculateButton = FindViewById<Button>(Resource.Id.invest_desired_amount_calculate_Button);
            TextView resultTextView = FindViewById<TextView>(Resource.Id.result_desired_amount_textView);

            yearButton.Click += (sender, e) =>
            {
                annualRateText.Hint = Resources.GetString(Resource.String.timeYears);
                changeRateToMonths = false;
            };

            monthButton.Click += (sender, e) =>
            {
                changeRateToMonths = true;
                annualRateText.Hint = Resources.GetString(Resource.String.timeMonths);
            };

            calculateButton.Click += (sender, e) =>
            {
                double.TryParse(desiredAmountText.Text, out desiredAmount);
                double.TryParse(currentSavingsText.Text, out presentValue);
                double.TryParse(annualRateText.Text, out rate);
                int.TryParse(timeText.Text, out time);

                invest = new Invest(0, 0, 0, 0, changeRateToMonths, false);
                
                resultTextView.Text = invest.HowMuchToSave(desiredAmount, presentValue, rate, time).ToString("c2");
            };
        }
    }
}