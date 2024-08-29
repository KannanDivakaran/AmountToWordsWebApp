using System;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace NumberToWords.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult numberToWords()
        {
            return View();
        }

        public class Amount
        {
            // Fields for Amount
            private decimal fullAmount;

            // Create Empty Constuctor
            public Amount(decimal amountValue)
            {
                fullAmount = amountValue;
            }

            // Define  properties of fullAmount 

            public decimal FullAmount
            {
                get { return fullAmount; }
                set { fullAmount = value; }
            }
        }

        public class Denominations
        {
            private string[] ones = {
        "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE","TEN",
            "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN"};

            private static string[] tens = { "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY" };

            private static string[] fromHundreds = { "HUNDRED", "THOUSAND", "MILLION", "BILLION", "TRILLION", "QUADRILLION", "QUINTILLION", "SEXTILLION", "SEPTILLION", "OCTILLION", "NONILLION", "DECILLION" };

            private static string amountIn_dollars_and_cents = "{0} DOLLARS and {1} CENTS";//Case-1 : Display DOLLARS and CENTS
            private static string amountIn_tens_ones = "{0}-{1}"; // Case-2: Two digit numbers with hiphen eg TWENTY-TWO
            private static string amountIn_big_small = "{0} {1}"; // Case-3: Combine numbers like thousands and hundreds
            private static string amountIn_from_thousand = "{0} {1}"; // Case -4: Handle number from 1 THOUSAND
            private static string amountIn_negative = "NEGATIVE {0}"; // If negative append NEGATIVE
            public string ConvertedToWords(decimal inputnNumber)
            {
                if (inputnNumber < 0)
                    // If number is negative then use format NEGATIVE prefix and find the number to words
                    return string.Format(amountIn_negative, ConvertedToWords(Math.Abs(inputnNumber)));

                int intValue = (int)inputnNumber;
                int afterDecimalValue = (int)((inputnNumber - intValue) * (decimal)100);

                // convert to Case-1  format mentioned above
                return string.Format(amountIn_dollars_and_cents, ConvertedToWords(intValue), ConvertedToWords(afterDecimalValue));
            }

            private string ConvertedToWords(int inputNumber, string powersIf = "")
            {
                string numberString = "";
                // Numbers below 100 can be displayed from the predefined string arrays of ones and tens
                if (inputNumber < 100)
                {
                    if (inputNumber < 20)
                        numberString = ones[inputNumber];
                    else
                    {
                        numberString = tens[inputNumber / 10];
                        if ((inputNumber % 10) > 0)
                            // Use Case-2 format to display number between 20-99
                            numberString = string.Format(amountIn_tens_ones, numberString, ones[inputNumber % 10]);
                    }
                }
                else
                {
                    // Numbers over 100 find the power and assign powerString from array fromHundreds
                    int power = 0;
                    string powerString = "";

                    if (inputNumber < 1000)
                    { // Numbers below 1000 and over 100 (100 inclusive)
                      // Divide the number by 100
                        power = 100;

                        // Append "HUNDRED" with output string
                        powerString = fromHundreds[0];
                    }
                    else
                    { // from 1000 onwards find the power
                        int log = (int)Math.Log(inputNumber, 1000);
                        // power will be 1000, 1000000 etc (10 to the power 3, 6, 9 etc)
                        power = (int)Math.Pow(1000, log);
                        // powerString will be "THOUSAND", "MILLION", etc. from array fromHundreds
                        powerString = fromHundreds[log];
                    }

                    // Case-3 format needs to be used for the power numbers. Join the value from below two functions
                    numberString = string.Format(amountIn_big_small, ConvertedToWords(inputNumber / power, powerString), ConvertedToWords(inputNumber % power)).Trim();
                }

                // Case 4 : Append the strings in reslut format
                return string.Format(amountIn_from_thousand, numberString, powersIf).Trim();
            }
        }

        [HttpPost]
        public IActionResult convert()
        {
            decimal num1 = Convert.ToDecimal(HttpContext.Request.Form["txtFirst"].ToString());
            decimal result = num1;
            //Read amount from console
            Amount amount = new Amount(result);
            //objDenominations
            Denominations objDenominations = new Denominations();
            // Convert the amount to words to get final output to display
            string finalText = "Output: " + "\"" + objDenominations.ConvertedToWords(amount.FullAmount) + "\"";
            //string text = finalText.Replace("@", System.Environment.NewLine);
            string inputText = "Input: " + "\"" + num1 + "\"";
            ViewBag.WordInput = inputText.ToString();
            ViewBag.WordResult = finalText.ToString();
            return View("numberToWords");
        }
    }
}