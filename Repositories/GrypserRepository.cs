using Gybs.Data.Repositories;
using Gybsera.Core.Extensions.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gybsera.Repositories
{
    public class GrypserRepository : IRepository<Grypser>
    {
        private readonly ILogger<GrypserRepository> _logger;

        public GrypserRepository(ILogger<GrypserRepository> logger)
        {
            _logger = logger;
        }

        public async Task AddAsync(Grypser entity)
        {
            _logger.LogDebug($"Welcome {entity.Nickname}!");
        }

        public Task<Grypser> FindAsync(params object[] keys)
        {
            throw new System.NotImplementedException();
        }
        
        public async Task<IReadOnlyList<Grypser>> GetAllAsync()
        {
            var grypsers = new List<Grypser>
            {
                new Grypser
                {
                    Nickname = "Łysy",
                    PrisonId = Guid.NewGuid(),
                    SentenceStartDate = DateTime.Now,
                    SentenceEndDate = DateTime.Now.AddYears(2)
                },
                new Grypser
                {
                    Nickname = "Siwy",
                    PrisonId = Guid.NewGuid(),
                    SentenceStartDate = DateTime.Now
                }
            };

            return grypsers;
        }

        public Task RemoveAsync(Grypser entity)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(Grypser entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
