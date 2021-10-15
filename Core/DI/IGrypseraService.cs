using Gybs.DependencyInjection.Services;

namespace Gybsera.Core.DI
{
    public interface IGrypseraService : IScopedService
    {
        public string TranslateToPolish(string word);
    }
}
