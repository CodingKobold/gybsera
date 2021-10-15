using Gybs;
using Gybs.Logic.Cqrs;
using Gybs.Results;
using Gybsera.Core.Extensions.Models;
using Gybsera.Repositories;
using System;
using System.Threading.Tasks;

namespace Gybsera.Operations
{
    public class AddGrypserCommand : ICommand
    {
        public string Nickname { get; set; }
        public Guid PrisonId { get; set; }
        public DateTime SentenceStartDate { get; set; }
        public DateTime? SentenceEndDate { get; set; }
    }

    public class AddGrypserCommandHandler : ICommandHandler<AddGrypserCommand>
    {
        private readonly GrypserRepository _grypserRepository;

        public AddGrypserCommandHandler(GrypserRepository grypserRepository)
        {
            _grypserRepository = grypserRepository;
        }

        public async Task<IResult> HandleAsync(AddGrypserCommand command)
        {
            var grypser = new Grypser
            {
                Nickname = command.Nickname,
                PrisonId = command.PrisonId,
                SentenceStartDate = command.SentenceStartDate,
                SentenceEndDate = command.SentenceEndDate
            };

            await _grypserRepository.AddAsync(grypser);

            return Result.Success();
        }
    }
}
