using Gybs;
using Gybs.Logic.Validation;
using Gybs.Results;
using System;
using System.Threading.Tasks;

namespace Gybsera.Validation
{
    public class SentenceValidationRule : IValidationRule<DateTime?>
    {
        public async Task<IResult> ValidateAsync(DateTime? data)
        {
            return data == null
                ? Result.Success()
                : Result.Failure("Sentence", "Too short sentence to be a true Grypser");
        }
    }
}
