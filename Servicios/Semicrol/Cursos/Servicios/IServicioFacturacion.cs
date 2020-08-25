using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADO.NET3.Dominio.Semicrol.Cursos.Dominio;

namespace ADO.NET3.Servicios.Semicrol.Cursos.Servicios
{
    interface IServicioFacturacion
    {
        void InsertarFactura(Factura f);
        List<Factura> BuscarTodasLasFacturas();

        List<Factura> BuscarTodosConLineas();
        void Borrar(Factura factura);
        void Actualizar(Factura factura);
        void Insertar(LineaFactura lf);
        Factura Buscar(int numero);
    }
}
