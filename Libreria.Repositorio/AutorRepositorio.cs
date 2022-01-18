using Dapper;
using Libreria.Entidades.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Libreria.Repositorio
{
    public class AutorRepositorio
    {
        public static string connectionString = "Server=.\\SQLEXPRESS; Database=libreria; Integrated Security=True";
        public List<Autor> GetAutores()
        {
            List<Autor> list = new List<Autor>();
            var query = "select * from libreria.autor";
            using (var connection = new SqlConnection(connectionString))
            {
                list = connection.Query<Autor>(query).ToList();
            }
            return list;
        }

        public Autor GetAutor(int id)
        {
            Autor autor = new Autor();
            var query = "select * from libreria.autor WHERE id = @id";
            using (var connection = new SqlConnection(connectionString))
            {
                autor = connection.Query<Autor>(query, new { id }).SingleOrDefault();
            }
            return autor;
        }

        public void Insert(Autor autor)
        {
            var query = "INSERT INTO libreria.autor (nombre, apellido, edad) VALUES (@nombre, @apellido, @edad)";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, new
                {
                    autor.Nombre,
                    autor.Apellido,
                    autor.Edad
                });
            }
        }

        public void Update(Autor autor)
        {
            var query = @"UPDATE libreria.autor set nombre = @nombre,
                                           apellido = @apellido,
                                           edad = @edad
                                           where id = @id";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, new
                {
                    autor.Nombre,
                    autor.Apellido,
                    autor.Edad,
                    autor.Id,
                });
            }
        }
        public void Delete(int id)
        {
            var query = @"DELETE FROM libreria.autor
                          where id = @id";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, new { id });
            }
        }
    }
}
