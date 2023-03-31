using System.Xml.Linq;

namespace _1stAPI_10_word_strings
{
    public class AfrNames : IWords
    {
      
      
        public string[] GetWords()
        {
            Item item = new Item();

            string[] Anames = item.Ajson.Split(',');
            for (int i = 0; i < Anames.Length; i++)
            {
                Anames[i] = Anames[i].Trim(new Char[] { '"', '[', ']' });
            }
            return Anames;
        }
    }
}
