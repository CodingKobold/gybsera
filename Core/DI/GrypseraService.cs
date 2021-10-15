using System.Collections.Generic;

namespace Gybsera.Core.DI
{
    //[ScopedService]
    internal class GrypseraService : IGrypseraService
    {
        private readonly IReadOnlyDictionary<string, string> _dictionary = new Dictionary<string, string>()
        {
            { "zarzucać", "jeść" },
            { "pojarunek", "papieros" },
            { "chart", "policjant" },
            { "garkownia", "kuchnia" },
            { "grawerka", "tatuaż" },
            { "jemioła", "herbata" },
            { "lejwoda", "psycholog" },
            { "model", "spryciarz" },
            { "oporek", "koniec" }
        };

        public string TranslateToPolish(string word)
        {
            if (_dictionary.ContainsKey(word))
            {
                return _dictionary[word];
            }

            return null;
        }
    }
}
