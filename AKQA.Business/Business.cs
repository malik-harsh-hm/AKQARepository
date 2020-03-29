using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKQA.Business
{
    public class Business : IBusiness
    {
        private static string[] arrayNumber = { "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN" };
        private static string[] arrayNumberTens = { "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY" };

        private static string strThousand = "THOUSAND";
        private static string strHundred = "HUNDRED";
        private static string strMillion = "MILLION";
        private static string strBillion = "BILLION";
        private static string strTrillion = "TRILLION";

        public string Convert(decimal amount)
        {
            if (amount == 0)
            {
                return "ZERO";
            }

            //Rounding two decimal places
            amount = Math.Truncate(100 * amount) / 100;

            int centAmount = CheckIfFractionValue(amount) ? GetFractionValue(amount) : 0;
            bool isNegative = amount < 0;

            //Get absolute vallue of whole number part
            decimal absoluteAmount = Math.Abs(Math.Truncate(amount));

            string amountInWord = absoluteAmount > 0 ? string.Format("{0} {1}", NumberToWords(absoluteAmount), absoluteAmount == 1 ? "DOLLAR" : "DOLLARS") : string.Empty;
            if (centAmount > 0)
            {
                amountInWord = string.Format("{0} {1} {2} {3}", amountInWord, string.IsNullOrEmpty(amountInWord) ? string.Empty : "AND", NumberToWords(centAmount), centAmount == 1 ? "CENT" : "CENTS");
            }

            amountInWord = isNegative ? string.Format("- {0}", amountInWord) : amountInWord;

            return amountInWord.Trim();
        }

        private static bool CheckIfFractionValue(decimal amount)
        {
            return amount % 1 != 0;
        }
        private static int GetFractionValue(decimal amount)
        {
            return System.Convert.ToInt16(Math.Abs((amount - Math.Truncate(amount)) * 100));
        }
        private static string NumberToWords(decimal amount)
        {
            decimal hundered = 100;
            decimal thousand = 1000;
            decimal million = thousand * 1000;
            decimal billion = million * 1000;
            decimal trillion = billion * 1000;

            StringBuilder strAmount = new StringBuilder();

            decimal remaining = amount;

            if (amount >= trillion)
            {
                //Handle trillion
                decimal trillionNumber = amount / trillion;
                strAmount.AppendFormat("{0} {1}", NumberToWords(Math.Truncate(trillionNumber)), strTrillion);

                // Handle remaning amount
                remaining = amount % trillion;
            }

            if (remaining >= billion)
            {
                decimal billionNumber = remaining / billion;
                strAmount.AppendFormat(" {0} {1}", NumberToWords(Math.Truncate(billionNumber)), strBillion);
                remaining = remaining % billion;
            }

            if (remaining >= million)
            {
                decimal millionNumber = remaining / million;
                strAmount.AppendFormat(" {0} {1}", NumberToWords(Math.Truncate(millionNumber)), strMillion);
                remaining = remaining % million;
            }

            if (remaining >= thousand)
            {
                decimal thousandNumber = remaining / thousand;
                strAmount.AppendFormat(" {0} {1}", NumberToWords(Math.Truncate(thousandNumber)), strThousand);
                remaining = remaining % thousand;
            }

            if (remaining >= hundered)
            {
                decimal hundredNumber = remaining / hundered;
                strAmount.AppendFormat(" {0} {1}", NumberToWords(Math.Truncate(hundredNumber)), strHundred);
                remaining = remaining % hundered;
            }

            if (remaining > 0)
            {
                if (strAmount.Length > 0)
                {
                    strAmount.Append(" AND ");
                }
                if (remaining < 20)
                {
                    strAmount.Append(arrayNumber[System.Convert.ToInt16(remaining)]);
                }
                else
                {
                    strAmount.Append(arrayNumberTens[(int)remaining / 10]);
                    if (((int)remaining / 10) > 0)
                        strAmount.AppendFormat(" {0}", (int)remaining % 10 != 0 ? arrayNumber[(int)remaining % 10] : string.Empty);
                }
            }
            return strAmount.ToString();
        }
    }
}
