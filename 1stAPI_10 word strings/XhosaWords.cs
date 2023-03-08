namespace _1stAPI_10_word_strings
{
    public class XhosaWords : IWords
    {
        public static readonly string[] Words = new[]
     {
            "ngomso", "namhlanje", "izolo", "ebsuku", "emvakwemini", "ngokuhlwa", "emini", "kusasa", "unothi", "enye"
        };
        private static XhosaWords instance;
       

        public static XhosaWords getInstance()
        {

            if (instance == null)
            {
                instance = new XhosaWords();
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
