using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _1stAPI_10_word_strings.Controllers //all, single rand and sorted alph
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
    

        Strings str = Strings.getInstance();

        private readonly ILogger<ValuesController> _logger;

        public ValuesController(ILogger<ValuesController> logger)
        {
            _logger = logger;
        }

     
        [HttpGet("AllWords")]
        public IEnumerable<string> All()
        {

            return str.All();
           
        }

       
        [HttpGet("SingleRandomWord")]
        public string Single()
        {
        
            return str.Single();

        }


        [HttpGet("AlphabeticalOrder")]
        public IEnumerable<string> Aplha()
        {

            return str.Sorted();

        }

    }
}
