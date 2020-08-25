using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADO.NET3.Dominio.Semicrol.Cursos.Dominio;

namespace ADO.NET3.Persistencia.Semicrol.Cursos.Persistencia
{
    public interface IFacturaRepository
    {
        void Insertar(Factura factura);
        void Borrar(Factura factura);
        void Actualizar(Factura factura);
        List<Factura> BuscarTodos();
        List<Factura> BuscarTodosConLineas();
        //List<Factura> BuscarTodos(FiltroFacturaNuevo filtro);
        Factura BuscarUno(int numero);

    }
}
