using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BeatMakerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DbController : ControllerBase
    {
        private IDbService _dbService;
        public DbController(IDbService dbService_)
        {
            _dbService = dbService_;
        }

        [HttpPost]
        [Route("recreateDB")]
        public void RecreateDB()
        {
            _dbService.RecreateDb();
        }
    }
}
