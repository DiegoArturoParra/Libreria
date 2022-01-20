using Libreria.Entidades.Models;
using Libreria.LogicaNegocio;
using Libreria.LogicaNegocio.Helpers;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Libreria.AutoresApi.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/autores")]
    public class AutorController : ApiController
    {
        private readonly AutorLN _autorService;
        public AutorController()
        {
            _autorService = new AutorLN();
        }

        public IHttpActionResult ResultadoStatus(Response response)
        {
            HttpStatusCode httpStatusCode = (HttpStatusCode)response.StatusCode;
            return Content(httpStatusCode, response);
        }
        [HttpGet]
        [Route("listado")]
        public IHttpActionResult GetAutores()
        {
            try
            {
                var lista = _autorService.Listado();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                var error = $"Error al manejar la solicitud. Error: {ex.Message}";
                var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(error, System.Text.Encoding.UTF8, "text/plain")
                };
                return ResponseMessage(httpResponseMessage);
            }
        }

        [HttpGet]
        [Route("conteo-libros/{id}")]
        public IHttpActionResult ConteoLibrosByAutor(int id)
        {
            try
            {
                var numero = _autorService.ConteoLibrosByAutor(id);
                return Ok(numero);
            }
            catch (Exception ex)
            {
                var error = $"Error al manejar la solicitud. Error: {ex.Message}";
                var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(error, System.Text.Encoding.UTF8, "text/plain")
                };
                return ResponseMessage(httpResponseMessage);
            }
        }


        [HttpGet]
        [Route("{id}")]

        public IHttpActionResult GetAutor(int id)
        {
            try
            {
                var autor = _autorService.Get(id);
                return Ok(autor);
            }
            catch (Exception ex)
            {
                var error = $"Error al manejar la solicitud. Error: {ex.Message}";
                var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(error, System.Text.Encoding.UTF8, "text/plain")
                };
                return ResponseMessage(httpResponseMessage);
            }
        }

        [HttpPost]
        [Route("crear")]

        public IHttpActionResult Post(Autor autor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Nombre y apellido requeridos.");
            }
            var response = _autorService.Crear(autor);
            return ResultadoStatus(response);
        }

        [HttpPut]
        [Route("editar")]

        public IHttpActionResult Put(Autor autor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Nombre y apellido requeridos.");
            }
            var response = _autorService.Editar(autor);
            return ResultadoStatus(response);
        }

        [HttpDelete]
        [Route("{id}")]

        public IHttpActionResult Delete(int id)
        {
            var response = _autorService.Eliminar(id);
            if (response.StatusCode != (int)HttpStatusCode.NoContent)
            {
                return ResultadoStatus(response);
            }
            return StatusCode((HttpStatusCode)response.StatusCode);
        }
    }
}
