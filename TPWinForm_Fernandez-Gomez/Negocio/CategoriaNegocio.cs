using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.SqlClient;

namespace Negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> Lista()
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader Lector;
            List<Categoria> Lista = new List<Categoria>();

            conexion.ConnectionString = "data source=DESKTOP-09K26PO\\SQLEXPRESS; initial catalog = CATALOGO_DB; integrated security = sspi";
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "select Id,Descripcion from CATEGORIAS";
            comando.Connection = conexion;
            conexion.Open();
            Lector = comando.ExecuteReader();
            while (Lector.Read())
            {
                Categoria aux = new Categoria();
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
 

