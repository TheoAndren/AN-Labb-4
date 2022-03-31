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
    public class WebsiteController : ControllerBase
    {
        private readonly IAnLabb4<Website> _anlabb4;

        public WebsiteController(IAnLabb4<Website> anlabb4)
        {
            _anlabb4 = anlabb4;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWebsites()
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

        [HttpGet("{id}")]
        public async Task<ActionResult<Website>> GetWebsite(int id)
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

        [HttpPost("{id}")]
        public async Task<ActionResult<Website>> CreateNewWebsite(Website newWebsite)
        {
            try
            {
                if (newWebsite == null)
                {
                    return BadRequest();
                }
                var createdWebsite = await _anlabb4.Add(newWebsite);
                return CreatedAtAction(nameof(GetWebsite), new { id = createdWebsite.WebsiteId }, createdWebsite);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Could not retrieve data from database.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Website>> UpdateWebsite(int id, Website web)
        {
            try
            {
                if (id != web.WebsiteId)
                {
                    return BadRequest("Website id doesn't match");
                }
                var websiteToUpdate = await _anlabb4.GetSingle(id);
                if (websiteToUpdate == null)
                {
                    return NotFound($"Website with id {id} not found");
                }
                return await _anlabb4.Update(web);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Could not retrieve data from database.");
            }
        }

        [HttpGet("person{id}")]
        public async Task<IActionResult> GetWebsitesPerPerson(int id)
        {
            try
            {
                var result = await _anlabb4.WebsitesPerPerson(id);
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

        [HttpPost("person{personId}interest{interestId}")]
        public async Task<ActionResult<Website>> NewPersonWebsite(Website newWebsite, int personId, int interestId)
        {
            try
            {
                if (newWebsite == null)
                {
                    BadRequest();
                }
                var createdPersonWebsite = await _anlabb4.AddPersonWebsite(newWebsite, personId, interestId);
                return CreatedAtAction(nameof(GetWebsite), new { id = createdPersonWebsite.WebsiteId }, createdPersonWebsite);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Could not retrieve data from database.");
            }
        }
    }
}
