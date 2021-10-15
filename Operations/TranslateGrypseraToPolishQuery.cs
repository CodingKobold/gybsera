using Gybs;
using Gybs.Logic.Cqrs;
using Gybs.Results;
using Gybsera.Core.DI;
using System.Threading.Tasks;

namespace Gybsera.Operations
{
    public class TranslateGrypseraToPolishQuery : IQuery<string>
    {
        public string Word { get; set; }
    }

    public class TranslateGrypseraToPolishQueryHandler : IQueryHandler<TranslateGrypseraToPolishQuery, string>
    {
        private readonly IGrypseraService _grypseraService;

        public TranslateGrypseraToPolishQueryHandler(IGrypseraService grypseraService)
        {
            _grypseraService = grypseraService;
        }

        public async Task<IResult<string>> HandleAsync(TranslateGrypseraToPolishQuery query)
        {
            return _grypseraService
                .TranslateToPolish(query.Word)
                .ToSuccessfulResult();
        }
    }
}
