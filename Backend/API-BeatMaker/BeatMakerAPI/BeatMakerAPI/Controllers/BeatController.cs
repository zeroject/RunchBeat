﻿using Application.DTOs;
using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Application;

namespace BeatMakerAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class BeatController : ControllerBase
    {


        private IBeatService _beatService;

        public BeatController(IBeatService beatService_)
        {
            _beatService = beatService_;
        }

        [HttpGet]
        [Route("getBeats/{userEmail_}")]
        public ActionResult<List<Beat>> GetAllBeatsFromUser(string userEmail_)
        {
            try
            {
                return Ok(_beatService.GetAllBeatsFromUser(userEmail_));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        [Route("createBeat")]
        public ActionResult<Beat> CreateNewBeat(BeatDTO beatDTO_)
        {
            try
            {
                return Created("Beat Created", _beatService.CreateNewBeat(beatDTO_));

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
        [Route("updateBeat")]
        public ActionResult<Beat> Updatebeat(BeatDTO beatDTO_)
        {
            try
            {
                return Ok(_beatService.UpdateBeat(beatDTO_));

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

        [HttpDelete]
        [Route("deleteBeat")]
        public ActionResult DeleteBeat(BeatDTO beatDTO_)
        {
            try
            {
                _beatService.DeleteBeat(beatDTO_);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
