using Gybs.Data.Repositories;
using Gybsera.Core.Extensions.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gybsera.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepositoriesController : ControllerBase
    {
        private readonly IRepository<Grypser> _grypserRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RepositoriesController(
            IRepository<Grypser> grypserRepository,
            IUnitOfWork unitOfWork)
        {
            _grypserRepository = grypserRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("GetGrypsers")]
        public async Task<ActionResult<IReadOnlyCollection<Grypser>>> GetGrypsers()
        {
            var grypsers = await _grypserRepository.GetAllAsync();
            return Ok(grypsers);
        }

        [HttpGet]
        [Route("AddGrypser")]
        public async Task<ActionResult<IReadOnlyCollection<Grypser>>> AddGrypser()
        {
            var grypser = new Grypser
            {
                Nickname = "Jaca",
                PrisonId = Guid.NewGuid(),
                SentenceStartDate = DateTime.Now,
                SentenceEndDate = null
            };

            await _grypserRepository.AddAsync(grypser);
            await _unitOfWork.SaveChangesAsync();

            return Ok();
        }
    }
}
