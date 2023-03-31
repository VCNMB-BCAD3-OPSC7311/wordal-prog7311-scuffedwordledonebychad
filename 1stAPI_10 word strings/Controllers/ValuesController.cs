using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _1stAPI_10_word_strings.Controllers //all, single rand and sorted alph
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

       

        WordFactory wordFactory = new WordFactory();
        IWords iwords;

        

        private readonly ILogger<ValuesController> _logger;

        public ValuesController(ILogger<ValuesController> logger)
        {
            _logger = logger;
        }

        [HttpPost("SendData")]
        public string SendData()
        {
            //_logger.Log(LogLevel.Trace , Select);
            //_logger.LogInformation(Select);

            Item i = new Item();
            

            return i.PostNames(); 

        }

        [HttpGet("Get5CharNames")]
        public string[] Get5CharNames()
        {
            //_logger.Log(LogLevel.Trace , Select);
            //_logger.LogInformation(Select);

            Item i = new Item();

         return i.Get5();
           

        }

        [HttpGet("AllNames")]
        public IEnumerable<string> All(String Select)
        {
            //_logger.Log(LogLevel.Trace , Select);
            //_logger.LogInformation(Select);

            iwords = wordFactory.getWords(Select);
           
            return Language.getInstance().All(iwords.GetWords());

        }


        [HttpGet("SingleRandomName")]
        public string Single(String Select)
        {

            iwords = wordFactory.getWords(Select);
            return Language.getInstance().Single(iwords.GetWords()); 

        }


        [HttpGet("AlphabeticalOrder")]
        public IEnumerable<string> Aplha(String Select)
        {

            iwords = wordFactory.getWords(Select);
            return Language.getInstance().Sorted(iwords.GetWords());

        }

       
    }
}
