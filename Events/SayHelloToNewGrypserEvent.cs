using Gybs.Logic.Events;

namespace Gybsera.Events
{
    public class SayHelloToNewGrypserEvent : IEvent
    {
        public string Nickname { get; set; }
    }
}
