using System;

namespace Library
{
    public class Verify
    {
        public static int StringToInt(string input)
        {
            bool Check = int.TryParse(input, out int result);
            while (!Check)
            {
                Check = int.TryParse(input, out result);
            }
            return result;
        }
    }
}
