using Libreria.Entidades.Models;
using Libreria.LogicaNegocio.Helpers;
using Libreria.Repositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Net;

namespace Libreria.LogicaNegocio
{
    public class LibroLN : ICRUD<Libro, int>
    {
        private readonly LibroRepositorio _repo;
        private Response _respuesta;
        public LibroLN()
        {
            _repo = new LibroRepositorio();
            _respuesta = new Response();
        }


        public Response Crear(Libro objeto)
        {
            try
            {
                if (!Validaciones(objeto))
                {
                    _repo.Insert(objeto);
                    _respuesta.StatusCode = ((int)HttpStatusCode.Created);
                    _respuesta.Mensaje = "se ha creado el libro satisfactoriamente.";
                }

            }
            catch (Exception ex)
            {
                errorServer(ex);
            }
            return _respuesta;
        }

        private bool Validaciones(Libro objeto)
        {
            if (_repo.ValidarISBN(objeto.ISBN, objeto.Id))
            {
                _respuesta.Mensaje = "ISBN repetido.";
                _respuesta.StatusCode = ((int)HttpStatusCode.Conflict);
                return true;
            }
            else if (!_repo.ExisteAutor(objeto.AutorId))
            {
                _respuesta.Mensaje = $"No existe el autor con el Id: {objeto.AutorId}";
                _respuesta.StatusCode = ((int)HttpStatusCode.NotFound);
                return true;
            }
            return false;
        }

        private void errorServer(Exception ex)
        {
            _respuesta.StatusCode = ((int)HttpStatusCode.InternalServerError);
            var SQLiteException = GetInnerException<DbUpdateException>(ex);
            if (SQLiteException != null)
            {
                Debug.WriteLine($"Error: {SQLiteException.Message},  {SQLiteException.InnerException.Message}");
                _respuesta.Mensaje = SQLiteException.InnerException.Message;
            }
            else
            {
                _respuesta.Mensaje = ex.Message;
            }

        }

        private static TException GetInnerException<TException>(Exception exception)
        where TException : Exception
        {
            Exception innerException = exception;
            while (innerException != null)
            {
                if (innerException is TException result)
                {
                    return result;
                }
                innerException = innerException.InnerException;
            }
            return null;
        }

        public Response Editar(Libro objeto)
        {
            try
            {
                var obj = _repo.GetLibro(objeto.Id);
                if (obj == null)
                {
                    _respuesta.Mensaje = "No se encuentra el libro.";
                }
                else if (!Validaciones(objeto))
                {
                    obj.FechaSalida = objeto.FechaSalida;
                    obj.AutorId = objeto.AutorId;
                    obj.Nombre = objeto.Nombre;
                    obj.ISBN = objeto.ISBN;
                    obj.Descripcion = objeto.Descripcion;
                    obj.NumeroDePaginas = objeto.NumeroDePaginas;
                    _repo.Update(obj);
                    _respuesta.Mensaje = "se ha editado el libro satisfactoriamente.";
                    _respuesta.StatusCode = ((int)HttpStatusCode.OK);
                }

            }
            catch (Exception ex)
            {
                errorServer(ex);
            }
            return _respuesta;
        }

        public Response Eliminar(int id)
        {
            try
            {
                var obj = _repo.GetLibro(id);
                if (obj == null)
                {
                    _respuesta.Mensaje = "No se encuentra el libro.";
                }
                else
                {
                    _repo.Delete(obj);
                    _respuesta.Mensaje = "se ha eliminado el libro satisfactoriamente.";
                }
            }
            catch (Exception ex)
            {
                errorServer(ex);
            }
            return _respuesta;
        }

        public List<Libro> Listado()
        {
            return _repo.GetLibros();
        }
        public List<Libro> ListadoLibrosByAutor(int idAutor)
        {
            return _repo.GetLibrosByAutor(idAutor);
        }
        public Libro Get(int id)
        {
            return _repo.GetLibro(id);
        }
    }
}
