namespace _1stAPI_10_word_strings
{
    public class WordFactory
    {
        public IWords returnInstance;

        public IWords getWords(string Language)
        {
            if (Language.ToLower().Equals("english"))
            {
                returnInstance = new EngWords();


            }
            else if (Language.ToLower().Equals("afrikaans"))
            {
                returnInstance = new AfrWords();
            }
            else if (Language.ToLower().Equals("xhosa"))
            {
                returnInstance = new XhosaWords();
            }

            return returnInstance;
        }
    }
}
