using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance_App
{
    class MathLib
    {
        public static double ConvertToDecimal(double num)
        {
            return (double)(.01 * num);
        }

        public static double ConvertToMonthlyRate(double num)
        {
            return num / 12;
        }

        public static int ConvertToMonths(int years)
        {
            return years * 12;
        }
    }
}
