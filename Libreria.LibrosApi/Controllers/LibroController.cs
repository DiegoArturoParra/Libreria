using Libreria.Entidades.Models;
using Libreria.LogicaNegocio;
using Libreria.LogicaNegocio.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.LibrosApi.Controllers
{
    [Route("api/libros")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly LibroLN _libroService;
        public LibroController()
        {
            _libroService = new LibroLN();
        }

        public IActionResult ResultadoStatus(Response response)
        {
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("listado")]
        public IActionResult GetLibros()
        {
            var query = _libroService.Listado();
            return Ok(query);
        }
        [HttpGet("listado-libros-by-autor/{id}")]
        public IActionResult GetLibrosByAutor(int id)
        {
            var query = _libroService.ListadoLibrosByAutor(id);
            return Ok(query);
        }

        [HttpGet("{id}")]
        public IActionResult GetLibro(int id)
        {
            var query = _libroService.Get(id);
            if (query == null)
            {
                return NotFound("No existe el libro.");
            }
            return Ok(query);
        }

        [HttpPost("crear")]
        public IActionResult Post(Libro libro)
        {
            var response = _libroService.Crear(libro);
            return ResultadoStatus(response);
        }

        [HttpPut("editar")]
        public IActionResult Put(Libro libro)
        {
            var response = _libroService.Editar(libro);
            return ResultadoStatus(response);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var response = _libroService.Eliminar(id);
            return ResultadoStatus(response);
        }
    }
}
