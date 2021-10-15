using Gybs;
using Gybs.Results;
using Gybsera.Core.Extensions.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gybsera.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultsController : ControllerBase
    {
        // Uses IResultFactory internally, which can be replaced with our own implementation
        // Result.Factory = new UserImplementedFactory();

        // Result.Map can map result into a new one -> potential use: when you return Result<T> since Failure returns simple IResult abstraction
        // Result.Copy copies result to a new object

        [HttpGet]
        [Route("Success")]
        public ActionResult<IResult> Success()
        {
            IResult result = Result.Success();
            return Ok(result);
        }

        [HttpPost]
        [Route("SuccessWithData")]
        public ActionResult<IResult> SuccessWithData(Grypser model)
        {
            // Optional way to do it:
            // IResult<GrypseraUserModel> result = Result.Success(model);
            return Ok(model.ToSuccessfulResult());
        }

        [HttpGet]
        [Route("Failure")]
        public ActionResult<IResult> Failure()
        {
            IResult simpleResult = Result.Failure("CheckGrypser", "Jaca isn't a grypser");
            return Ok(simpleResult);
        }

        [HttpGet]
        [Route("FailureWithPropertyError")]
        public ActionResult<IResult> FailureWithPropertyError()
        {
            IResult propertyResult = Result.Failure<Grypser>(m => m.Nickname, "Jaca isn't a grypser");
            return Ok(propertyResult);
        }

        [HttpGet]
        [Route("FailureWithDictionary")]
        public ActionResult<IResult> FailureWithDictionary()
        {
            var dictionary = new ResultErrorsDictionary();
            dictionary.Add("CheckGrypser", "Jaca isn't a grypser", "Placa isn't a grypser");
            dictionary.Add("CheckPrisoner", "Jaca was never in pensjonat");

            IResult dictionaryResult = Result.Failure(dictionary);
            return Ok(dictionaryResult);
        }
    }
}
