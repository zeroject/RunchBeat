using Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BeatMakerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        public LoginController()
        {

        }

        public ActionResult Login(UserLoginDTO userLoginDTO_)
        {
            return null;
        }
    }
}
