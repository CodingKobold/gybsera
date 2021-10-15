using Gybs;
using Gybs.Logic.Operations.Factory;
using Gybsera.Operations;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Gybsera.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationsController : ControllerBase
    {
        // Can provide own implementation
        private readonly IOperationFactory _operationFactory;

        public OperationsController(IOperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        [HttpGet]
        [Route("Translate")]
        public async Task<ActionResult<IResult<string>>> Query(string word)
        {
            // Uses existing query
            //
            // var query = new TranslateGrypseraToPolishQuery { Word = word };
            // IResult<string> result = await _operationFactory
            //    .UseExisting(query)
            //    .HandleAsync();

            IResult<string> result = await _operationFactory
                .Create<TranslateGrypseraToPolishQuery>(q => q.Word = word)
                .HandleAsync();

            return Ok(result);
        }

        [HttpPost]
        [Route("AddGrypser")]
        public async Task<ActionResult<IResult<string>>> Command(string nickname)
        {
            IResult result = await _operationFactory
                .Create<AddGrypserCommand>(c =>
                {
                    c.Nickname = nickname;
                    c.PrisonId = Guid.NewGuid();
                    c.SentenceStartDate = DateTime.Now;
                })
                .HandleAsync();

            return Ok(result);
        }
    }
}
