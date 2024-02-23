using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tiquetes.Naviera.Models;
using Tiquetes.Naviera.Services;

namespace Tiquetes.Naviera.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NavieraController : ControllerBase
    {
        private readonly ITiquetesNavieraService _service;

        public NavieraController(ITiquetesNavieraService tiquetesNavieraService)
        {
            _service = tiquetesNavieraService;
        }

        // GET: api/Naviera
        [HttpGet]
        public IActionResult GetAll()
        {
            var tiquetes = _service.GetAllTiquetes();
            return Ok(tiquetes);
        }

        // GET: api/Naviera/5
        [HttpGet("{id}", Name = "GetTiquete")]
        public IActionResult GetById(Guid id)
        {
            var tiquete = _service.GetTiquete(id);
            if (tiquete == null)
            {
                return NotFound();
            }
            return Ok(tiquete);
        }

        // POST: api/Naviera
        [HttpPost]
        public IActionResult Create(TiqueteDto tiquete)
        {
            _service.CreateTiquetes(tiquete);
            return CreatedAtAction(nameof(GetById), new { id = tiquete.Id }, tiquete);
        }

        // PUT: api/Naviera/5
        [HttpPut("{id}")]
        public IActionResult Update(TiqueteDto tiquete)
        {

            _service.UpdateTiquetes(tiquete);
            return NoContent();
        }

        // DELETE: api/Naviera/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var tiquete = _service.GetTiquete(id);
            if (tiquete == null)
            {
                return NotFound();
            }

            _service.DeleteTiquetes(id);
            return NoContent();
        }
    }
}
