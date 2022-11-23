﻿using Application;
using Application.DTOs;
using Application.Interfaces;
using Domain;
using FluentValidation;
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

        [HttpGet]
        public ActionResult<User> GetUser(string username_, string password_)
        {
            return _userService.GetUser(username_, password_);
        }

        [HttpPost]
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
            catch (Exception e)
            {
                return StatusCode(500, e.ToString());
            }
        }

        [HttpPut]
        public ActionResult<User> UpdateUser(UserDTO userDTO_)
        {
            try
            {
                var updatedUser = _userService.UpdateUser(userDTO_);
                return Created("User/Updated ", updatedUser);
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
        public void DeleteUser(int userId_)
        {
            _userService.DeleteUser(userId_);
        }
    }
}
