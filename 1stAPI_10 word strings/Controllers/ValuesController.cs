using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _1stAPI_10_word_strings.Controllers //all, single rand and sorted alph
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        string lang = "";

       WordFactory wordFactory = new WordFactory();
        IWords iwords;

        Language language = new Language();

        private readonly ILogger<ValuesController> _logger;

        public ValuesController(ILogger<ValuesController> logger)
        {
            _logger = logger;
        }

        [HttpPost("SelectLanguage")]

        public string Input(string Language)
        {
            language.Lang = Language;
            return language.;
        }


        [HttpGet("AllWords")]
        public IEnumerable<string> All()
        {
            iwords = wordFactory.getWords("English");
            return iwords.All();

        }


        [HttpGet("SingleRandomWord")]
        public string Single()
        {

            iwords = wordFactory.getWords("Afrikaans");
            return iwords.Single();

        }


        [HttpGet("AlphabeticalOrder")]
        public IEnumerable<string> Aplha()
        {

            iwords = wordFactory.getWords("Xhosa");
            return iwords.Sorted();

        }

       
    }
}
