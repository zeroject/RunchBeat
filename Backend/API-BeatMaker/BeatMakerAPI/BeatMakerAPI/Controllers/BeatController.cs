using Application.DTOs;
using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;

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
        [Route("getBeats")]
        public ActionResult<List<Beat>> GetAllBeatsFromUser(string userEmail_)
        {
            return _beatService.GetAllBeatsFromUser(userEmail_);
        }

        [HttpPost]
        [Route("createBeat")]
        public ActionResult<Beat> CreateNewBeat(BeatDTO beatDTO_, string userEmail_)
        {
            try
            {
                var createdBeat = _beatService.CreateNewBeat(beatDTO_, userEmail_);
                return Created("Beat/" + createdBeat.Id, createdBeat);
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
        [Route("updateBeat")]
        public ActionResult<Beat> Updatebeat(BeatDTO beatDTO_, string userEmail_)
        {
            try
            {
                var updatedBeat = _beatService.UpdateBeat(beatDTO_, userEmail_);
                return Created("Beat/Updated ", updatedBeat);
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
        [Route("deleteBeat")]
        public void DeleteBeat(BeatDTO beatDTO_, string userEmail_)
        {
            _beatService.DeleteBeat(beatDTO_, userEmail_);
        }
    }
}
