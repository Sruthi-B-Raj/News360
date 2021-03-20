using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Favourite_API.Exceptions;
using Favourite_API.Models;
using Favourite_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Favourite_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FavouriteController : ControllerBase
    {
        public readonly IFavouriteService service;
        public FavouriteController(IFavouriteService _service)
        {
            service = _service;
        }

        
        [HttpGet]
        public IActionResult Get()
        {
           
            try
            {
                return Ok(service.GetFavourites());
            }
            catch (FavouriteNotFoundException ex)
            {
                return Conflict(ex.Message);
            }

        }

       //[Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] Favourite favourite)
        {
            try
            {
                service.AddFavourite(favourite);
                return Created("api/Favourite", 201);

            }
            catch (FavouriteAlreadyExistsException ex)
            {

                return Conflict(ex.Message);
            }
          
        }
       // [Authorize]
        [HttpDelete("{id}/{title}")]
        public IActionResult Delete(string id, string title)
        {
            try
            {
                return Ok(service.DeleteFavourite(id, title));
            }
            catch (FavouriteNotFoundException ex)
            {
                return Conflict(ex.Message);
            }
        }
       // [Authorize]
        [HttpGet("{userName}")]
         public IActionResult Get(string userName)
        {
            try
            {
                return Ok(service.GetFavouriteById(userName));

            }
            catch (FavouriteNotFoundException ex)
            {
                return Conflict(ex.Message);

            }
        }
    }
}
