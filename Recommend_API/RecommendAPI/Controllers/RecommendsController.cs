using Microsoft.AspNetCore.Mvc;
using RecommendAPI.Exception;
using RecommendAPI.Models;
using RecommendAPI.Services;

namespace RecommendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommendsController : ControllerBase
    {
        private readonly IRecommendService _service;
        public RecommendsController(IRecommendService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_service.GetRecommends());
            }
            catch (RecommendNotFound ex)
            {
                return Conflict(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] Recommend recommends)
        {
            try
            {
                _service.AddRecommends(recommends);
                return Created("api/Recommend", 201);
            }
            catch (RecommendAlreadyExist ex)
            {
                return Conflict(ex.Message);
            }
        }
        [HttpDelete("{id}/{title}")]
        public IActionResult Delete(string id, string title)
        {
            try
            {
                return Ok(_service.DeleteRecommend(id, title));
            }
            catch (RecommendNotFound ex)
            {
                return Conflict(ex.Message);
            }
        }
        [HttpGet("{title}")]
        public IActionResult GetById(string title)
        {
            try
            {
                return Ok(_service.GetRecommendsTitle(title));
            }
            catch(RecommendNotFound ex)
            {
                return Conflict(ex.Message);

            }
        }
    }
}
