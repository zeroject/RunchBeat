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
        public ActionResult<User> CreateNewUser(UserDTO userDTO_)
        {
            try
            {
                var createdUser = _userService.CreateNewUser(userDTO_);
                return Created("User/" + createdUser.Id, createdUser);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch (ArgumentException e)
            {
                return StatusCode(233, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.ToString());
            }
        }

        [HttpPut]
        [Authorize]
        [Route("updateUser")]
        public ActionResult<User> UpdateUser(UserDTO userDTO_)
        {
            try
            {
                var updatedUser = _userService.UpdateUser(userDTO_);
                return Ok(updatedUser);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.ToString());
            }
        }
        
        [HttpDelete]
        [Authorize]
        [Route("deleteUser")]
        public void DeleteUser(string email_)
        {
            _userService.DeleteUser(email_);
        }

        [HttpPut]
        [Authorize]
        [Route("updatePassword")]
        public ActionResult<User> UpdatePassword(UserDTO userDTO_)
        {
            try
            {
                return Ok(_userService.UpdateUserPassword(userDTO_));
            }
            catch( Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
