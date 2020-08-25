using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET3.Dominio.Semicrol.Cursos.Dominio
{
    public class LineaFactura
    {
        public LineaFactura(int numero, Factura factura_numero, string id, int unidades)
        {
            Numero = numero;
            this.factura_numero = factura_numero;
            Id = id;
            Unidades = unidades;
        }

        public LineaFactura()
        {

        }

        public LineaFactura(int numero, Factura factura_numero)
        {
            Numero = numero;
            this.factura_numero = factura_numero;
        }

        public int Numero { get; set; }
        public Factura factura_numero {get; set;}
        public string Id { get; set; }
        public int Unidades { get; set; }

    }
}
