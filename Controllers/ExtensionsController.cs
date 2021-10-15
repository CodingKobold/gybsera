using Gybs.Extensions;
using Gybsera.Core.Extensions.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gybsera.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExtensionsController : ControllerBase
    {
        private readonly ILogger<ExtensionsController> _logger;

        public ExtensionsController(ILogger<ExtensionsController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("Serialize")]
        // Needs EnableUnsafeBinaryFormatterSerialization to be set as true due to
        // https://docs.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/5.0/binaryformatter-serialization-obsolete
        public ActionResult<Grypser> BinarySerialization(Grypser model)
        {
            byte[] serializedModel = model.SerializeToBinary();
            Grypser deserializedModel = serializedModel.DeserializeFromBinary<Grypser>();
            return Ok(deserializedModel);
        }

        [HttpPost]
        [Route("Collections")]
        public ActionResult<IReadOnlyCollection<string>> Collections(IEnumerable<IEnumerable<string>> offenses)
        {
            IEnumerable<string> flattenedOffenses = offenses
                .Flatten()
                .Where(o => o.IsPresent())
                .Select(o => o.CompactWhitespaces().Trim());

            // Synchronous/asynchronous versions available
            flattenedOffenses.ForEach(async offense =>
            {
                var updatedOffense = await AddExclamationAsync(offense);
                _logger.LogDebug(updatedOffense);
            });

            IReadOnlyCollection<string> readonlyOffenses = flattenedOffenses
                .ToList()
                .CastToReadOnly();

            return Ok(readonlyOffenses);
        }

        // Not really async
        private static Task<string> AddExclamationAsync(string offense)
        {
            offense += "!";
            return offense.ToCompletedTask();
        }
    }
}
