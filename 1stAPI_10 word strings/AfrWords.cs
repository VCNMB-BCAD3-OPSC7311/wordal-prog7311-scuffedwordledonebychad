namespace _1stAPI_10_word_strings
{
    public class AfrWords : IWords
    {
        public static readonly string[] Words = new[]
     {
            "vader", "aarde", "deel", "neem", "punt", "probeer", "prentjie", "dieselfde", "kom", "studie"
        };
        private static AfrWords instance;
        

        public static AfrWords getInstance()
        {

            if (instance == null)
            {
                instance = new AfrWords();
            }
            return instance;
        }

        public String[] All()
        {
            return Words;
        }

        public String[] Sorted()
        {
            return Words.OrderBy(x => x).ToArray();
        }

        public String Single()
        {
            Random random = new Random();
            int ran = random.Next(0, Words.Length);

            return Words[ran];
        }
    }
}
