using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Negocio
{
    class AccesoDatos
    {
        public SqlDataReader Lector { get; set; }
        public SqlConnection Conexion { get; set; }
        public SqlCommand Comando { get; set; }

        public AccesoDatos()
        {
            Conexion = new SqlConnection("data source=.\\SQLEXPRESS; initial catalog = CATALOGO_DB; integrated security = sspi");
            Comando = new SqlCommand();
            Comando.Connection = Conexion;
        }

        public void SetarQuery (string Consulta)
        {
            Comando.CommandType = System.Data.CommandType.Text;
            Comando.CommandText = Consulta;
        }

        public void SetearSP(string SP)
        {
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.CommandText = SP;
        }

        public void agregarParametro (string Nombre,object Valor )
        {
            Comando.Parameters.AddWithValue(Nombre, Valor);
        }


        public void ejecutarLector ()
        {
            try
            {
                Conexion.Open();
                Lector = Comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void CerrarConexion ()
        {
            Conexion.Close();
        }

        internal void ejecutarAccion ()
        {
            try
            {
                Conexion.Open();
                Comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                Conexion.Close();
            }
        }


    }
}
