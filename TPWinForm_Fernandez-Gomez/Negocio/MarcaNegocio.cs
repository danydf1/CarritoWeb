using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.SqlClient;

namespace Negocio
{
    public class MarcaNegocio
    {
        public List<Marca> Lista()
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader Lector;
            List<Marca> Lista = new List<Marca>();

            conexion.ConnectionString = "data source=DESKTOP-09K26PO\\SQLEXPRESS; initial catalog = CATALOGO_DB; integrated security = sspi";
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "select Id,Descripcion from MARCAS";
            comando.Connection = conexion;
            conexion.Open();
            Lector = comando.ExecuteReader();
            while (Lector.Read())
            {
                Marca aux = new Marca();
                aux.ID = (int)Lector["Id"];
                aux.Descripcion = (string)Lector["Descripcion"];

                Lista.Add(aux);
            }
            Lector.Close();
            conexion.Close();
            return Lista;
        }

    }
}
