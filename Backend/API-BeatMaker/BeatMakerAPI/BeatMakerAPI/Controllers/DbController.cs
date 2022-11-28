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
        [Route("recreateDB/{pass}")]
        public void RecreateDB(string pass)
        {
            if (pass == "DFHIASF93W2qe!Dhif9H8I3I0jhj0fwjh932H9f32wj03rkJ99j023r")
            {
                _dbService.RecreateDb();
            }
        }
    }
}
