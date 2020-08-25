using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADO.NET3.Dominio.Semicrol.Cursos.Dominio;
using ADO.NET3.Persistencia.Semicrol.Cursos.Persistencia;

namespace ADO.NET3.PersistenciaADO.Semicrol.Cursos.PersistenciaADO
{
    public class FacturaRepository : IFacturaRepository
    {
        private static string CadenaConexion()
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["miconexion"];
            String cadena = settings.ConnectionString;
            return cadena;
        }

        public void Actualizar(Factura factura)
        {
            using (
            SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "update facturas set Concepto=@Concepto where Numero=@Numero";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Numero", factura.Numero);
                comando.Parameters.AddWithValue("@Concepto", factura.Concepto);
                comando.ExecuteNonQuery();
            }
        }

        public void Borrar(Factura factura)
        {
            using (
            SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "delete from facturas where Numero=@Numero";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Numero", factura.Numero);
                comando.ExecuteNonQuery();
            }
        }

        public List<Factura> BuscarTodos()
        {
            List<Factura> lista = new List<Factura>();
            using (
            SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "select * from facturas";
                SqlCommand comando = new SqlCommand(sql, conexion);
                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    lista.Add(new Factura(Convert.ToInt32(lector["Numero"]), lector["Concepto"].ToString()));
                }
                return lista;
            }
        }

        public List<Factura> BuscarTodosConLineas()
        {
            using (
            SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "select facturas.Numero as 'NumeroFactura', " +
                    "Facturas.Concepto, LineaFacturas.numero as 'NumeroLinea', " +
                    "unidades, producto_id from facturas inner join lineafacturas " +
                    "on facturas.numero = lineafacturas.factura_numero";
                SqlCommand comando = new SqlCommand(sql, conexion);
                SqlDataReader lector = comando.ExecuteReader();
                List<Factura> listaFacturas = new List<Factura>();
                while (lector.Read())
                {
                    Factura f = new Factura(Convert.ToInt32(lector["NumeroFactura"]));
                    if (!listaFacturas.Contains(f))
                    {
                        f.Concepto = lector["Concepto"].ToString();
                        listaFacturas.Add(f);
                    }
                    else
                    {
                        f = listaFacturas.
                            Find((facturita) => facturita.Numero == Convert.ToInt32(lector["NumeroFactura"]));

                    }
                    LineaFactura linea = new LineaFactura(Convert.ToInt32(lector["NumeroLinea"]), f);

                    linea.Unidades = Convert.ToInt32(lector["unidades"]);
                    linea.Id = lector["producto_id"].ToString();

                    f.AddLinea(linea);

                    /*lista.Add(new Factura(Convert.ToInt32(lector["numero"]), 
                        lector["concepto"].ToString()));*/

                }
                return listaFacturas;
            }
        }

        public Factura BuscarUno(int numero)
        {
            using (
            SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "select * from facturas where Numero=@Numero";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Numero", numero);
                SqlDataReader lector = comando.ExecuteReader();
                if (lector.Read())
                {
                    Factura f= new Factura(Convert.ToInt32(lector["numero"]), lector["concepto"].ToString());
                    return f;
                }
                else
                {
                    return null;
                }
            }
        }

        public void Insertar(Factura factura)
        {
            using (
            SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "insert into facturas (numero, concepto) " +
                    "values (@Numero, @Concepto)";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Numero", factura.Numero);
                comando.Parameters.AddWithValue("@Concepto", factura.Concepto);
                comando.ExecuteNonQuery();
            }
        }

    }
}
