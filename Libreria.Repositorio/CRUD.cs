using Microsoft.EntityFrameworkCore;
using System;

namespace Libreria.Repositorio
{
    public class CRUD
    {

        #region Metodo Insertar
        public void Insert(Object entidad)
        {

            using (var _db = new MapeoCore())
            {
                _db.Entry(entidad).State = EntityState.Added;
                GuardarCambios(_db);
            }
        }
        #endregion

        #region Metodo Actualizar

        public void Update(Object entidad)
        {

            using (var _db = new MapeoCore())
            {
                _db.Entry(entidad).State = EntityState.Modified;
                GuardarCambios(_db);
            }
        }
        #endregion

        #region Metodo Delete
        public void Delete(Object entidad)
        {
            using (var _db = new MapeoCore())
            {
                _db.Entry(entidad).State = EntityState.Deleted;
                GuardarCambios(_db);
            }
        }

        private void GuardarCambios(MapeoCore db)
        {
            db.SaveChanges();
        }
        #endregion
    }
}
