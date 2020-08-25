using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ADO.NET3.Dominio.Semicrol.Cursos.Dominio;
using ADO.NET3.Persistencia.Semicrol.Cursos.Persistencia;
using ADO.NET3.PersistenciaADO.Semicrol.Cursos.PersistenciaADO;
using ADO.NET3.Servicios.Semicrol.Cursos.Servicios;

namespace ADO.NET3
{
    class Program
    {
        static void Main(string[] args)
        {
            Factura f1 = new Factura(6, "ostras");
            List<Factura> lista = new List<Factura>();

            IFacturaRepository repo = new FacturaRepository();
            ILineaFacturaRepository repoLineas = new LineaFacturaRepository();
            IServicioFacturacion servicio = new ServicioFacturacion(repo, repoLineas);
            //servicio.InsertarFactura(f1);
            lista=servicio.BuscarTodasLasFacturas();
            foreach(Factura f in lista)
            {
                Console.WriteLine(f.Concepto);
            }

            //servicio.Borrar(f1);
            Factura f0 =servicio.Buscar(1);
            servicio.Actualizar(f0);
            Console.WriteLine(f0.Concepto);
            Console.ReadLine();



        }
    }
}
