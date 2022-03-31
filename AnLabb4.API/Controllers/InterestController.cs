using AN_Labb_4;
using AnLabb4.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AnLabb4.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestController : ControllerBase
    {
        private readonly IAnLabb4<Interest> _anlabb4;

        public InterestController(IAnLabb4<Interest> anlabb4)
        {
            _anlabb4 = anlabb4;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInterests()
        {
            try
            {
                return Ok(await _anlabb4.GetAll());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Could not retrieve data from database.");
            }
        }

        [HttpGet("person{id}")]
        public async Task<IActionResult> GetInterestsPerPerson(int id)
        {
            try
            {
                var result = await _anlabb4.InterestsPerPerson(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Could not retrieve data from database.");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Interest>> GetInterest(int id)
        {
            try
            {
                var result = await _anlabb4.GetSingle(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Could not retrieve data from database.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Interest>> CreateNewInterest(Interest newInterest)
        {
            try
            {
                if (newInterest == null)
                {
                    BadRequest();
                }
                var createdInterest = await _anlabb4.Add(newInterest);
                return CreatedAtAction(nameof(GetInterest), new { id = newInterest.InterestId }, createdInterest);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Could not retrieve data from database.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Interest>> Delete(int id)
        {
            try
            {
                var interestToDelete = await _anlabb4.GetSingle(id);
                if (interestToDelete == null)
                {
                    return NotFound($"Interest with id {id} not found");
                }
                return await _anlabb4.Delete(id);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Could not retrieve data from database.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Interest>> UpdateInterest(int id, Interest interest)
        {
            try
            {
                if (id != interest.InterestId)
                {
                    return BadRequest("Interest id doesn't match");
                }
                var interestToUpdate = await _anlabb4.GetSingle(id);
                if (interestToUpdate == null)
                {
                    return NotFound($"Interest with id {id} not found");
                }
                return await _anlabb4.Update(interest);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Could not retrieve data from database.");
            }
        }

        [HttpPost("person{id}")]
        public async Task<ActionResult<Interest>> NewPersonInterest(Interest newInterest, int id)
        {
            try
            {
                if (newInterest == null)
                {
                    BadRequest();
                }
                var createdPersonInterest = await _anlabb4.AddPersonInterest(newInterest, id);
                return CreatedAtAction(nameof(GetInterest), new { id = createdPersonInterest.InterestId }, createdPersonInterest);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Could not retrieve data from database.");
            }
        }
    }
}
