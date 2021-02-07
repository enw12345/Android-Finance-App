using System;

namespace Finance_App
{
    public class Loan : Formulas
    {
        private double a;
        private int n;

        public Loan(double a, float r, int n)
        {
            this.a = a;
            rate = r;
            this.n = n;
        }

        public double AmortizedLoanPayment(double a, double rate, int t)
        {
            CheckTimePeriod(ref rate);
            double r = MathLib.ConvertToMonthlyRate(rate);
            int nTotal = 12 * t;
            double b2 = Math.Pow(1 + r, nTotal);
            Console.WriteLine(a.ToString() + " " + nTotal.ToString() + " " + b2.ToString());
            Console.WriteLine(((b2 - 1) / (r * b2)).ToString());
            return a / ((b2 - 1) / (r * b2));
        }

        public double IntresOnlyLoanPayment(double a, float rate, int n)
        {
            return 0;
        }
    }
}