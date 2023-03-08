using System;

namespace _1stAPI_10_word_strings
{
    public class EngWords : IWords
    {
        public static readonly string[] Words = new[]
       {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private static EngWords instance;
       

        public static EngWords getInstance()
        {

            if (instance == null)
            {
                instance = new EngWords();
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
