using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.SqlClient;



namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {

            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader Lector;
            List<Articulo> Lista = new List<Articulo>();

            conexion.ConnectionString = "data source=.\\SQLEXPRESS; initial catalog = CATALOGO_DB; integrated security = sspi";
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select  A.Id,A.Codigo,A.Nombre,A.Descripcion,A.ImagenUrl,A.Precio,M.Descripcion Marca,M.Id IDMarca, C.Descripcion Categoria,C.Id IDCategoria " +
                                   "From ARTICULOS A, MARCAS M, CATEGORIAS C where A.IdMarca = M.Id and A.IdCategoria = C.Id";
            comando.Connection = conexion;
            conexion.Open();
            Lector = comando.ExecuteReader();
            while (Lector.Read())
            {
                Articulo aux = new Articulo();
                aux.ID = (int)Lector["Id"];
                aux.Codigo = (String)Lector["Codigo"];
                aux.Nombre = (String)Lector["Nombre"];
                aux.Descripcion = (String)Lector["Descripcion"];
                aux.Precio = Convert.ToDouble(Lector["Precio"]);
                aux.ImagenUrl = (String)Lector["ImagenUrl"];

                aux.Marca = new Marca();
                aux.Marca.ID = (int)Lector["IDMarca"];
                aux.Marca.Descripcion = (String)Lector["Marca"];

                aux.Categoria = new Categoria();
                aux.Categoria.ID = (int)Lector["IDCategoria"];
                aux.Categoria.Descripcion = (String)Lector["Categoria"];

                Lista.Add(aux);

            }
            Lector.Close();
            conexion.Close();
            return Lista;
        }

        public void modificar(Articulo articulo)
        {
            AccesoDatos conexion = new AccesoDatos();
            try
            {
                conexion.SetarQuery("UPDATE Articulos Set Codigo=@Codigo,Nombre=@Nombre,Descripcion=@Descripcion," +
                                    "IdMarca=@IdMarca,IdCategoria=@IdCategoria,ImagenUrl=@ImagenUrl,Precio=@Precio Where Id=@Id");
                
                
                conexion.agregarParametro("@Codigo", articulo.Codigo);
                conexion.agregarParametro("@Nombre", articulo.Nombre);
                conexion.agregarParametro("@Descripcion", articulo.Descripcion);
                conexion.agregarParametro("@IdMarca", articulo.Marca.ID);
                conexion.agregarParametro("@IdCategoria", articulo.Categoria.ID);
                conexion.agregarParametro("@ImagenUrl", articulo.ImagenUrl);
                conexion.agregarParametro("@Precio", articulo.Precio);
                conexion.agregarParametro("@Id", articulo.ID);
                conexion.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Alta(Articulo nuevo)
        {
            AccesoDatos conexion = new AccesoDatos();
            try
            {
                conexion.SetarQuery("INSERT Into Articulos (Codigo,Nombre,Descripcion,Precio,ImagenUrl,IdMarca,IdCategoria) " +
                                  "values (@Codigo,@Nombre,@Descripcion,@Precio,@ImagenUrl,@IdMarca,@IdCategoria)");
                
                conexion.agregarParametro("@Codigo", nuevo.Codigo);
                conexion.agregarParametro("@Nombre", nuevo.Nombre);
                conexion.agregarParametro("@Descripcion", nuevo.Descripcion);
                conexion.agregarParametro("@IdMarca", nuevo.Marca.ID);
                conexion.agregarParametro("@IdCategoria", nuevo.Categoria.ID);
                conexion.agregarParametro("@ImagenUrl", nuevo.ImagenUrl);
                conexion.agregarParametro("@Precio", nuevo.Precio);
                conexion.ejecutarAccion();
               
            }
            catch (Exception)
            {

                throw;
            }

        }
        public void Eliminar ( int ID)
        {
            AccesoDatos Conexion = new AccesoDatos();
            try
            {
                Conexion.SetarQuery("Delete From Articulos Where Id = @Id");
                Conexion.agregarParametro("@Id", ID);
                Conexion.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
