using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Administracion_de_articulos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Articulo> listaArticulos = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            datos.setConsulta("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, A.ImagenUrl, A.Precio  FROM ARTICULOS A INNER JOIN MARCAS M ON A.IdMarca = M.Id INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id");
            datos.ejecutarLectura();
            while (datos.Lector.Read())
            {
                Articulo articulo= new Articulo();
                articulo.Id = (int)datos.Lector["Id"];
                articulo.Codigo = (string)datos.Lector["Codigo"];
                articulo.Nombre = (string)datos.Lector["Nombre"];
                articulo.Descripcion = (string)datos.Lector["Descripcion"];
                articulo.Marca = (string)datos.Lector["Marca"];
                articulo.Categoria = (string)datos.Lector["Categoria"];
                articulo.UrlImagen = (string)datos.Lector["ImagenUrl"];
                articulo.Precio = Convert.ToSingle(datos.Lector["Precio"]);

                listaArticulos.Add(articulo);
            }
            dgvArticulos.DataSource = listaArticulos;
        }
    }
}
