using System;

namespace _1stAPI_10_word_strings
{
    public class EngNames : IWords
    {
      
       
        public string[] GetWords()
        {
            Item item = new Item();

            string[] Enames = item.Ejson.Split(',');
            for (int i = 0; i < Enames.Length; i++)
            {
                Enames[i] = Enames[i].Trim(new Char[] { '"', '[', ']' });
            }
            return Enames;
        }
 

    }
}
