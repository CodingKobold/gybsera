using System;

namespace Gybsera.Core.Extensions.Models
{
    [Serializable]
    public class Grypser
    {
        public string Nickname { get; set; }
        public Guid PrisonId { get; set; }
        public DateTime SentenceStartDate { get; set; }
        public DateTime? SentenceEndDate { get; set; }
    }
}
