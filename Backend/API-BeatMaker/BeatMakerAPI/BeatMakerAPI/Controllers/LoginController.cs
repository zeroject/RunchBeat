using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BeatMakerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IAuthenticationService _auth;
        public LoginController(IAuthenticationService auth_)
        {
            _auth = auth_;
        }

        [HttpPost]
        [Route("login")]
        public ActionResult Login(UserLoginDTO userLoginDTO_)
        {
            try
            {
                return Ok(_auth.Login(userLoginDTO_));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
