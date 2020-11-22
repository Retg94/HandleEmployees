using System;
using System.Text.RegularExpressions;

namespace Library
{
    public class Verify
    {
        public static int StringToInt(string input)
        {
            bool isOkay = int.TryParse(input, out int result);
            while(!isOkay)
            {
                Console.WriteLine("Invalid input, try again: ");
                isOkay = int.TryParse(Console.ReadLine(), out result);
            }
            return result;
        }
        public static bool VerifyStringWithSpaces(string input)
        {
            bool isOkay = true;
            if (input.Length < 5 || input.Length > 20)
                isOkay = false;
            if (!Regex.IsMatch(input, @"^[a-zA-Z0-9 ]+$")) // Only accepts letters, numbers and spaces.
                isOkay = false;
            if (String.IsNullOrWhiteSpace(input))
                isOkay = false;

            return isOkay;

        }
     
        public static bool VerifyStringNoSpaces(string input)
        {
            bool isOkay = true;
            if (input.Length < 5 || input.Length > 20)
                isOkay = false;
            if (!Regex.IsMatch(input, @"^[a-zA-Z0-9]+$")) // Only accepts letters and numbers.
                isOkay = false;
            if (String.IsNullOrWhiteSpace(input))
                isOkay = false;

            return isOkay;
        }


    }
}
