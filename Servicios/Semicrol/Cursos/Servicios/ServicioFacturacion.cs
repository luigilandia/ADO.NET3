using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADO.NET3.Dominio.Semicrol.Cursos.Dominio;
using ADO.NET3.Persistencia.Semicrol.Cursos.Persistencia;

namespace ADO.NET3.Servicios.Semicrol.Cursos.Servicios
{
    public class ServicioFacturacion:IServicioFacturacion
    {
        private IFacturaRepository repo;
        private ILineaFacturaRepository repoLineas;

        public ServicioFacturacion(IFacturaRepository repo, ILineaFacturaRepository repoLineas)
        {
            this.repo = repo;
            this.repoLineas = repoLineas;
        }

        public void Actualizar(Factura factura)
        {
            repo.Actualizar(factura);
        }

        public void Borrar(Factura factura)
        {
            repo.Borrar(factura);
        }

        public Factura Buscar(int numero)
        {
            return repo.BuscarUno(numero);
        }

        public List<Factura> BuscarTodasLasFacturas()
        {
            return repo.BuscarTodos();
        }

        public List<Factura> BuscarTodosConLineas()
        {
            throw new NotImplementedException();
        }

        public void Insertar(LineaFactura lf)
        {
            throw new NotImplementedException();
        }

        public void InsertarFactura(Factura f)
        {
            repo.Insertar(f);
        }
    }
}
