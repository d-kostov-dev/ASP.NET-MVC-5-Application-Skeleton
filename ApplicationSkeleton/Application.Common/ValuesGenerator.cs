namespace Application.Common
{
    using System;
    using System.Collections.Generic;

    public static class ValuesGenerator
    {
        // I know i know the names of the constats suck, but it's easyer to read this way in the code. Try it!
        private const int DefaultMinStrLength = 6;
        private const int DefaultMaxStrLength = 20;
        private const string BaseStrChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        private static readonly Random SystemRandom = new Random();

        /// <summary>
        /// Generates random integer number.
        /// </summary>
        public static int GetRandomInt(int minValue = 0, int maxValue = int.MaxValue)
        {
            int generatedNumber = SystemRandom.Next(minValue, maxValue + 1);

            return generatedNumber;
        }

        /// <summary>
        /// Generates random double number in given range. Default ranges are 0.00 to double.MaxValue.
        /// </summary>
        public static double GetRandomDouble(double minValue = 0.00, double maxValue = double.MaxValue)
        {
            // Returns a random floating-point number between 0.0 and 1.0.
            var randomDoubleValue = SystemRandom.NextDouble();
            var generatedNumber = minValue + (randomDoubleValue * (maxValue - minValue));

            return generatedNumber;
        }

        /// <summary>
        /// Generates random string with given lengh..
        /// </summary>
        public static string GetRandomString(int length = DefaultMaxStrLength)
        {
            char[] charsSelected = new char[length];

            for (int i = 0; i < length; i++)
            {
                charsSelected[i] = BaseStrChars[SystemRandom.Next(BaseStrChars.Length)];
            }

            return new string(charsSelected);
        }

        /// <summary>
        /// Generates random string with random lenght between 6 and 20 symbols.
        /// </summary>
        public static string GetRandomLengthString()
        {
            int randomLength = GetRandomInt(DefaultMinStrLength, DefaultMaxStrLength);
            string generatedString = GetRandomString(randomLength);

            return generatedString;
        }

        /// <summary>
        /// Generates a set (with given length) of random strings (optional lenght). 
        /// Default strings length is between 6 and 20 symbols.
        /// </summary>
        public static ISet<string> GetUniqueRandomStringsSet(int listLength)
        {
            var generatedStrings = new HashSet<string>();

            while (generatedStrings.Count < listLength)
            {
                generatedStrings.Add(GetRandomLengthString());
            }

            return generatedStrings;
        }

        /// <summary>
        /// Generates a set (with given length) of random integers.
        /// </summary>
        public static ISet<int> GetUniqueRandomIntegersSet(int listLength, int minValue = 0, int maxValue = int.MaxValue)
        {
            var generatedIntegers = new HashSet<int>();

            while (generatedIntegers.Count < listLength)
            {
                int currentInteger = GetRandomInt(minValue, maxValue);
                generatedIntegers.Add(currentInteger);
            }

            return generatedIntegers;
        }

        /// <summary>
        /// Generates random date from minimal year to today. Default minimal date is 1990.1.1
        /// </summary>
        public static DateTime GetRandomDate(int minimalYear = 1990)
        {
            DateTime startDate = new DateTime(minimalYear, 1, 1);
            int range = (DateTime.Today - startDate).Days;
            var generatedDate = startDate.AddDays(SystemRandom.Next(range));

            return generatedDate;
        }
    }
}
