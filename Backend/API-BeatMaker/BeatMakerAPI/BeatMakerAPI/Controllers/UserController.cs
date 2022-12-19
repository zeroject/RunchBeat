using Application.DTOs;
using Application.Interfaces;
using Domain;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeatMakerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService_)
        {
            _userService = userService_;
        }

        [HttpPost]
        [Route("createUser")]
        public ActionResult CreateNewUser(UserDTO userDTO_)
        {
            try
            {
                return Created("User Created", _userService.CreateNewUser(userDTO_));
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch (ArgumentException e)
            {
                return StatusCode(422, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.ToString());
            }
        }

        [HttpPut]
        [Authorize]
        [Route("updatePassword")]
        public ActionResult<User> UpdatePassword(UserDTO userDTO_)
        {
            try
            {
                _userService.UpdateUserPassword(userDTO_);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch (ArgumentException e)
            {
                return StatusCode(422, e.ToString());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.ToString());
            }
            return Ok();
        }

        [HttpDelete]
        [Authorize]
        [Route("deleteUser/{username_}")]
        public ActionResult DeleteUser(string username_)
        {
            try
            {
                _userService.DeleteUser(username_);
            }
            catch (ArgumentException e)
            {
                return StatusCode(422, e.ToString());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.ToString());
            }
            return Ok();
        }
    }
}
