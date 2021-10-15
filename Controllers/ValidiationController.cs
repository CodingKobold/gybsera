using Gybs;
using Gybs.Logic.Validation;
using Gybsera.Validation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Gybsera.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidiationController : ControllerBase
    {
        private readonly IValidator _validator;

        public ValidiationController(IValidator validator)
        {
            _validator = validator;
        }

        [HttpGet]
        [Route("GypserCheck")]
        public async Task<ActionResult<IResult>> GypserCheck(string name, DateTime? sentenceEndDate)
        {
            IResult result = await _validator
                .Require<GrypserNameValidationRule>().WithData(name)
                .Require<SentenceValidationRule>().WithData(sentenceEndDate)
                .ValidateAsync();

            return Ok(result);
        }

        [HttpGet]
        [Route("GypserCheckWithException")]
        public async Task<ActionResult> GypserCheckWithException(string name, DateTime? sentenceEndDate)
        {
            try
            {
                await _validator
                    .Require<GrypserNameValidationRule>().WithData(name)
                    .Require<SentenceValidationRule>().WithData(sentenceEndDate)
                    .EnsureValidAsync();
            }
            catch (ValidationFailedException e)
            {
                return BadRequest(e.Result.Errors.Values);
            }

            return Ok();
        }
    }
}
