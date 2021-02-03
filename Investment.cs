using System;

namespace Finance_App
{
    public class Invest : Formulas
    {
        private double desiredAmount;

        public Invest(double pv, double p, double r, int t, bool ctmr, bool ctmt)
        {
            presentValue = pv;
            period = p;
            rate = r;
            time = t;

            convertToMonthsRate = ctmr;
            convertToMonthsTime = ctmt;
        }

        public Invest(double da, double pv, double p, double r, int t, bool ctmr, bool ctmt)
        {
            desiredAmount = da;
            presentValue = pv;
            period = p;
            rate = r;
            time = t;

            convertToMonthsRate = ctmr;
            convertToMonthsTime = ctmt;
        }

        /// <summary>
        /// Interest accrued over a period of time
        /// </summary>
        /// <param name="p">period</param>
        /// <param name="r">rate</param>
        /// <param name="t">time</param>
        /// <returns>Simple Interest</returns>
        public double SimpleInterest(double p, double r, int t)
        {
            CheckTimePeriod(ref r);
            double rateDecimal = MathLib.ConvertToDecimal(r);
            return p * rateDecimal * t;
        }

        /// <summary>
        /// Future Value with simple interest is the ending balance after plus the simple intrest
        /// </summary>
        /// <param name="p">principal</param>
        /// <param name="r">rate</param>
        /// <param name="t">time period</param>
        /// <returns>Future value with Simple Interest</returns>
        public double FutureValueWithSimpleInterest(double p, double r, int t)
        {
            CheckTimePeriod(ref r);
            double rateDecimal = MathLib.ConvertToDecimal(r);
            return p * (1 + rateDecimal * t);
        }

        /// <summary>
        /// Interest accrued over a period of time where the amount earned is reinvested 
        /// </summary>
        /// <param name="p">period</param>
        /// <param name="r">rate</param>
        /// <param name="time">time</param>
        /// <returns>compound interes</returns>
        public double CompoundInterest(double p, double r, int t)
        {
            CheckTimePeriod(ref r);
            double rateDecimal = MathLib.ConvertToDecimal(r);
            double a = Math.Pow((1 + rateDecimal), t);
            return p * (a - 1);
        }

        /// <summary>
        /// Future Value with compound interest is the ending balance plus the compound intrest
        /// </summary>
        /// <param name="p">period</param>
        /// <param name="r">rate</param>
        /// <param name="time">time</param>
        /// <returns>compound interets</returns>
        public double FutureValueWithCompoundInterest(double p, double r, int t)
        {
            CheckTimePeriod(ref r);
            double rateDecimal = MathLib.ConvertToDecimal(r);
            return p * Math.Pow((1 + rateDecimal), t);
        }

        /// <summary>
        /// Calculates the ending balance for a periodic series of payments
        /// </summary>
        /// <param name="p">principal</param>
        /// <param name="r">rate</param>
        /// <param name="t">time period</param>
        /// <returns></returns>
        public double FutureValueOfAnnuity(double p, double r, int t)
        {
            CheckTimePeriod(ref r);
            double rateDecimal = MathLib.ConvertToDecimal(r);
            double num = (Math.Pow(1 + rateDecimal, t)) - 1;
            return p * (num / rateDecimal);
        }

        public double FutureValue(double presentValue, double p, double r, int t)
        {
            return FutureValueOfAnnuity(p, r, t) + FutureValueWithCompoundInterest(presentValue, r, t);
        }

        public double HowMuchToSave(double desiredAmount, double presentValue, double r, int t)
        {
            CheckTimePeriod(ref r);
            double rateDecimal = MathLib.ConvertToDecimal(r);
            double a = Math.Pow(1 + rateDecimal, t);
            return rateDecimal * (desiredAmount - presentValue * a) / (a - 1);
        }
    }
}