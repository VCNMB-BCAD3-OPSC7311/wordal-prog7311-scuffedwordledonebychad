using _1stAPI_10_word_strings;
namespace Test1stApi
 
{

    [TestClass]
    public class WordTest
    {
        private static readonly string[] Words = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        Strings str = Strings.getInstance();
        [TestMethod]
        public void TestAll ()
        {
            CollectionAssert.AreEqual(Words, str.All());  
        }

        [TestMethod]

        public void TestOne()
        {
            Assert.IsNotNull(str.Single()); 
        }

        [TestMethod]
        public void Sorted()
        {
            CollectionAssert.AreEqual(Words.OrderBy(x=>x).ToArray(), str.Sorted());
        }
    }
}