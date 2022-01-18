using Libreria.LogicaNegocio.Helpers;
using System.Collections.Generic;

namespace Libreria.LogicaNegocio
{
    public interface ICRUD<T, ID>
    {
        List<T> Listado();
        T Get(ID id);
        Response Crear(T objeto);
        Response Editar(T objeto);
        Response Eliminar(ID id);

    }
}
