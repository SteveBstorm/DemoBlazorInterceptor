using DemoBlazorInterceptor.Server.Services;
using DemoBlazorInterceptor.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoBlazorInterceptor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MovieService _movieService;
        public MovieController(MovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_movieService.GetAll());
        }
        [Authorize("AdminPolicy")]
        [HttpPost]
        public IActionResult Create([FromBody]Movie m)
        {
            _movieService.Add(m);
            return StatusCode(201);
        }

        [HttpGet]
        [Route("500Error")]
        //[Authorize("AdminPolicy")]

        public IActionResult ReturnInternalServerError()
        {
            return StatusCode(500, "Erreur interne du serveur");
        }

        [HttpGet]
        [Route("404Error")]
        
        public IActionResult ReturnNotFound() 
        {
            return NotFound("Ressource introuvable");
        }
    }
}
