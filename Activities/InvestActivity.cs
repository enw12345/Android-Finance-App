using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using System;

namespace Finance_App
{
    [Activity(Label = "InvestActivity")]
    public class InvestActivity : Activity
    {
        Invest invest;
        double presentValue;
        double period;
        double rate;
        int time;
        bool changeRateToMonths = false;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //Set our view from the invest layout resource
            SetContentView(Resource.Layout.activity_invest);

            // Create your application here
            Button calculationButton = FindViewById<Button>(Resource.Id.invest_calculate_Button);
            EditText presentValueInput = FindViewById<EditText>(Resource.Id.present_value_editText);
            EditText periodInput = FindViewById<EditText>(Resource.Id.period_editText);
            EditText rateInput = FindViewById<EditText>(Resource.Id.rate_editText);
            EditText timeInput = FindViewById<EditText>(Resource.Id.time_editText);
            TextView resultTextView = FindViewById<TextView>(Resource.Id.result_textView);

            RadioButton yearButton = FindViewById<RadioButton>(Resource.Id.year_radioButton);
            RadioButton monthButton = FindViewById<RadioButton>(Resource.Id.month_radioButton);

            yearButton.Click += (sender, e) =>
            {
                timeInput.Hint = Resources.GetString(Resource.String.timeYears);
                changeRateToMonths = false;
            };

            monthButton.Click += (sender, e) =>
            {
                changeRateToMonths = true;
                timeInput.Hint = Resources.GetString(Resource.String.timeMonths);
            };

            //presentValueInput.OnFocusChangeListener = FormatTextMoney(presentValueInput, presentValue);

            //presentValueInput.FocusChange += (sender, e) =>
            //{
            //    double temp;

            //    if (Double.TryParse(presentValueInput.Text, out temp))
            //        presentValue = temp;
            //    //presentValueInput.Text = temp.ToString("c2");
            //};
            //periodInput.FocusChange += (sender, e) =>
            //{
            //    double temp;

            //    if (Double.TryParse(periodInput.Text, out temp))
            //        period = temp;
            //    //periodInput.Text = temp.ToString("c2");
            //};
            //rateInput.FocusChange += (sender, e) =>
            //{
            //    double temp = 0;
            //    if (Double.TryParse(rateInput.Text, out temp))
            //        rate = temp;
            //    //rateInput.Text = temp + "%";
            //};
            //timeInput.FocusChange += (sender, e) =>
            //{
            //    int.TryParse(timeInput.Text, out time);
            //};

            calculationButton.Click += (sender, e) =>
            {
                Double.TryParse(presentValueInput.Text, out presentValue);
                Double.TryParse(periodInput.Text, out period);
                Double.TryParse(rateInput.Text, out rate);
                int.TryParse(timeInput.Text, out time);

                if (presentValueInput.Text == null || periodInput.Text == null || rateInput.Text == null || timeInput.Text == null)
                {
                    resultTextView.SetTextColor(Android.Graphics.Color.Red);
                    resultTextView.Text = "Please Input proper values.";
                }
                else
                {
                    invest = new Invest(presentValue, period, rate, time, changeRateToMonths, false);

                    resultTextView.SetTextColor(Android.Graphics.Color.Green);
                    resultTextView.Text = invest.FutureValue(presentValue, period, rate, time).ToString("c2");
                }
            };
        }
    }
}