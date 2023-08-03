using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;


namespace presentacion
{
    public partial class frmDetalle : Form
    {
        private Articulo articulo = null;
        public frmDetalle()
        {
            InitializeComponent();
        }
        public frmDetalle(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;

        }


        private void frmDetalle_Load(object sender, EventArgs e)
        {
            ElementoNegocio elementoNegocio = new ElementoNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            try
            {
                txtCodigo.Text = articulo.Codigo;
                txtNombre.Text = articulo.Nombre;
                txtDescripcion.Text = articulo.Descripcion;
                txtMarca.Text = articulo.Marca.Descripcion;
                txtCategoria.Text = articulo.Categoria.Descripcion;
                txtUrlImagen.Text = articulo.ImagenUrl;
                cargarImagen(articulo.ImagenUrl);
                txtPrecio.Text = articulo.Precio.ToString("0.00");
                
                                                                               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void txtUrlImagen_Leave(object sender, EventArgs e)
        {

        }
        private void cargarImagen(string imagen)
        {
            try
            {
                pbxArticulo.Load(imagen);
            }
            catch (Exception ex)
            {

                pbxArticulo.Load("https://media.istockphoto.com/id/1147544807/vector/thumbnail-image-vector-graphic.jpg?s=612x612&w=0&k=20&c=rnCKVbdxqkjlcs3xH87-9gocETqpspHFXu5dIGB4wuM=");
            }
        }
        
       
    }
}

