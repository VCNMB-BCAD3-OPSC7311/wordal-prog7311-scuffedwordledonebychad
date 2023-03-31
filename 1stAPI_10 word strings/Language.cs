namespace _1stAPI_10_word_strings
{
    public class Language
    {
        private static Language instance;
        private Language()
        {

        }
        public static Language getInstance()
        {

            if (instance == null)
            {
                instance = new Language();
            }
            return instance;
        }

        public String[] All(String[] Words)
        {
            return Words;
        }

        public String[] Sorted(String[] Words)
        {
            return Words.OrderBy(x => x).ToArray();
        }

        public String Single(String[] Words)
        {
            Random random = new Random();
            int ran = random.Next(0, Words.Length);

            return Words[ran];
        }



    }
}
