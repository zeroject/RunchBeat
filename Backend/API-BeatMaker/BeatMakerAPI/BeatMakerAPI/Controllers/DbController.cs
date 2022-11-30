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
        [Route("recreateDB/{pass_}")]
        public ActionResult RecreateDB(string pass_)
        {
            if (pass_ == "DFHIASF93W2qe!Dhif9H8I3I0jhj0fwjh932H9f32wj03rkJ99j023r")
            {
                try
                {
                    _dbService.RecreateDb();
                     return Ok();
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }
            return StatusCode(422, "Wrong password");
        }
    }
}
