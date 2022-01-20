using Libreria.Entidades.Models;
using Libreria.LogicaNegocio.Helpers;
using Libreria.Repositorio;
using System;
using System.Collections.Generic;
using System.Net;

namespace Libreria.LogicaNegocio
{
    public class AutorLN : ICRUD<Autor, int>
    {
        private readonly AutorRepositorio _repo;
        private Response _respuesta;
        public AutorLN()
        {
            _repo = new AutorRepositorio();
            _respuesta = new Response();
        }

        public Response Crear(Autor objeto)
        {
            try
            {
                _repo.Insert(objeto);
                _respuesta.StatusCode = ((int)HttpStatusCode.Created);
                _respuesta.Mensaje = "se ha creado el autor satisfactoriamente.";
            }
            catch (Exception ex)
            {
                errorServer(ex);
            }
            return _respuesta;
        }



        public Response Editar(Autor objeto)
        {
            try
            {
                var obj = _repo.GetAutor(objeto.Id);
                if (obj == null)
                {
                    _respuesta.Mensaje = "No se encuentra ese autor.";
                    _respuesta.StatusCode = (int)HttpStatusCode.NotFound;
                }
                else
                {
                    obj.Nombre = objeto.Nombre;
                    obj.Apellido = objeto.Apellido;
                    obj.Edad = objeto.Edad;
                    _repo.Update(obj);
                    _respuesta.StatusCode = ((int)HttpStatusCode.OK);
                    _respuesta.Mensaje = "se ha editado el autor satisfactoriamente.";
                }
            }
            catch (Exception ex)
            {
                errorServer(ex);
            }
            return _respuesta;
        }

        public int ConteoLibrosByAutor(int id)
        {
            int conteo = 0;
            var obj = _repo.GetAutor(id);
            if (obj == null)
            {
                throw new Exception("No existe el autor.");
            }
            else
            {
                conteo = _repo.ConteoLibrosByAutor(id);

                return conteo;
            }
        }
        public Response Eliminar(int id)
        {
            try
            {
                var objeto = _repo.GetAutor(id);
                if (objeto == null)
                {
                    _respuesta.Mensaje = "No se encuentra ese autor.";
                    _respuesta.StatusCode = (int)HttpStatusCode.NotFound;
                }
                else
                {
                    _repo.Delete(id);
                    _respuesta.Mensaje = "Eliminado.";
                    _respuesta.StatusCode = (int)HttpStatusCode.NoContent;
                }
            }
            catch (Exception ex)
            {
                errorServer(ex);
            }
            return _respuesta;
        }

        public Autor Get(int id)
        {
            return _repo.GetAutor(id);
        }

        public List<Autor> Listado()
        {
            return _repo.GetAutores();
        }

        private void errorServer(Exception ex)
        {
            _respuesta.StatusCode = ((int)HttpStatusCode.InternalServerError);
            _respuesta.Mensaje = ex.Message;
        }
    }
}
