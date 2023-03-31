using System.Xml.Linq;

namespace _1stAPI_10_word_strings
{
    public class XhosaNames : IWords
    {
      
       
        public string[] GetWords()
        {
            Item item = new Item();

            string[] Xnames = item.Xjson.Split(',');
            for (int i = 0; i < Xnames.Length; i++)
            {
                Xnames[i] = Xnames[i].Trim(new Char[] { '"', '[', ']' });
            }

            return Xnames;
        }
    }
}
