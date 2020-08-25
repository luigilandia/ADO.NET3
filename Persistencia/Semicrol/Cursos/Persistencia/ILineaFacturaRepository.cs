using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADO.NET3.Dominio.Semicrol.Cursos.Dominio;

namespace ADO.NET3.Persistencia.Semicrol.Cursos.Persistencia
{
    public interface ILineaFacturaRepository
    {
        void Insertar(LineaFactura lf);
    }
}
