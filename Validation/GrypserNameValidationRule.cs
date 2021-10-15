using Gybs;
using Gybs.Logic.Validation;
using Gybs.Results;
using System.Threading.Tasks;

namespace Gybsera.Validation
{
    public class GrypserNameValidationRule : IValidationRule<string>
    {
        public async Task<IResult> ValidateAsync(string data)
        {
            return data == "Łysy" || data == "Siwy"
                ? Result.Success()
                : Result.Failure("Sentence", "Not a name of a true Grypser");
        }
    }
}
