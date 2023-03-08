using System;

namespace _1stAPI_10_word_strings
{
    public class Strings
    {
        private static readonly string[] Words = new[]
       {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private static Strings instance;
        private Strings()
        {
        }

        public static Strings getInstance()
        {

            if (instance == null)
            {
                instance = new Strings();
            }
            return instance;
        }

        public String[] All()
        {
            return Words;
        }

        public String[] Sorted()
        {
            return Words.OrderBy(x=>x).ToArray();
        }

        public String Single()
        {
            Random random = new Random();
            int ran = random.Next(0, Words.Length);

            return Words[ran];
        }

    }
}
