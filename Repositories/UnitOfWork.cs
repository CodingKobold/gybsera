using Gybs.Data.Repositories;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Gybsera.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ILogger<UnitOfWork> _logger;

        public UnitOfWork(ILogger<UnitOfWork> logger)
        {
            _logger = logger;
        }

        public async Task SaveChangesAsync()
        {
            _logger.LogDebug($"Unit of work saved changes");
        }
    }
}
