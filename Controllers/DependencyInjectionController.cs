using Gybsera.Core.DI;
using Microsoft.AspNetCore.Mvc;

namespace Gybsera.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DependencyInjectionController : ControllerBase
    {
        private readonly IGrypseraService _grypseraService;

        public DependencyInjectionController(IGrypseraService grypseraService)
        {
            _grypseraService = grypseraService;
        }

        [HttpGet]
        [Route("Translate")]
        public ActionResult<string> Translate(string word)
        {
            string translatedWord = _grypseraService.TranslateToPolish(word);
            return Ok(translatedWord);
        }
    }
}
