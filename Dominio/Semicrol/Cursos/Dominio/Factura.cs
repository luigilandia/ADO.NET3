using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET3.Dominio.Semicrol.Cursos.Dominio
{
    public class Factura
    {
        public Factura(int numero, string concepto)
        {
            Numero = numero;
            Concepto = concepto;
        }

        public Factura()
        {

        }

        public Factura(int numero)
        {
            Numero = numero;
        }

        public int Numero { get; set; }
        public string Concepto { get; set; }
    }
}
