using Libreria.Entidades.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Libreria.Repositorio
{
    public class LibroRepositorio : CRUD
    {
        private readonly MapeoCore db;
        public LibroRepositorio()
        {
            db = new MapeoCore();
        }
        public List<Libro> GetLibros()
        {
            return db.TablaLibros.Include(x => x.Autor).ToList();
        }

        public Libro GetLibro(int id)
        {
            return db.TablaLibros.Find(id);
        }

        public bool ValidarISBN(string iSBN, int id = 0)
        {
            if (id == 0)
            {
                return db.TablaLibros.Any(x => x.ISBN.Equals(iSBN));
            }
            else
            {
                return db.TablaLibros.Any(x => x.ISBN.Equals(iSBN) && x.Id != id);
            }

        }
        public List<Libro> GetLibrosByAutor(int idAutor)
        {
            return db.TablaLibros.Where(x => x.AutorId == idAutor).ToList();
        }
        public bool ExisteAutor(int autorId)
        {
            return db.TablaAutores.Any(x => x.Id == autorId);
        }
    }
}
