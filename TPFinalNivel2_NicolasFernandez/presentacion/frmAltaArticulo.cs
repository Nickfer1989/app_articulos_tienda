using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;
using System.Configuration;

namespace presentacion
{
    public partial class frmAltaArticulo : Form
    {
        private Articulo articulo = null;
        private OpenFileDialog archivo = null;

        public frmAltaArticulo()
        {
            InitializeComponent();
        }
        public frmAltaArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            Text = "Modificar Artículo";
        }






        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            ArticuloNegocio negocio = new ArticuloNegocio();

            try
            {
                if (validarFormulario())
                    return;

                if (articulo == null)
                    articulo = new Articulo();




                articulo.Codigo = txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.Marca = (Elemento)cboMarca.SelectedItem;
                articulo.Categoria = (Elemento)cboCategoria.SelectedItem;
                articulo.ImagenUrl = txtUrlImagen.Text;
                articulo.Precio = decimal.Parse(txtPrecio.Text);

                
                   
                    if (articulo.Id != 0)
                    {
                        negocio.modificar(articulo);
                        MessageBox.Show("Modificado exitosamente");
                    }
                    else
                    {
                        negocio.agregar(articulo);
                        MessageBox.Show("Agregado exitosamente");
                    }

                    if (archivo != null && txtUrlImagen.Text.Contains("http"))
                        guardarImagen();


                    Close();
                 
               
                



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void frmAltaArticulo_Load(object sender, EventArgs e)
        {
            ElementoNegocio elementoNegocio = new ElementoNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            try
            {
                cboMarca.DataSource = elementoNegocio.listar();
                cboMarca.ValueMember = "Id";
                cboMarca.DisplayMember = "Descripcion";
                cboCategoria.DataSource = categoriaNegocio.listar();
                cboCategoria.ValueMember = "Id";
                cboCategoria.DisplayMember = "Descripcion";

                if (articulo != null)
                {
                    txtCodigo.Text = articulo.Codigo;
                    txtNombre.Text = articulo.Nombre;
                    txtDescripcion.Text = articulo.Descripcion;
                    txtUrlImagen.Text = articulo.ImagenUrl;
                    cargarImagen(articulo.ImagenUrl);
                    txtPrecio.Text = articulo.Precio.ToString("0.00");
                    cboMarca.SelectedValue = articulo.Marca.Id;
                    cboCategoria.SelectedValue = articulo.Categoria.Id;

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void txtUrlImagen_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtUrlImagen.Text);

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

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            archivo = new OpenFileDialog();
            archivo.Filter = "jpg|*jpg|png|*png";
            if (archivo.ShowDialog() == DialogResult.OK)
            {
                txtUrlImagen.Text = archivo.FileName;
                cargarImagen(archivo.FileName);


            }
        }
        private void guardarImagen()
        {
            File.Copy(archivo.FileName, ConfigurationManager.AppSettings["productos-app"] + archivo.SafeFileName);
        }


        Validaciones vali = new Validaciones();

        private bool validarFormulario()
        {
            if (txtCodigo.Text == "" && txtNombre.Text == "" && txtDescripcion.Text == "" && txtPrecio.Text == "")
            {
                MessageBox.Show("Por favor complete los campos vacíos...");
                return true;
            }
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                MessageBox.Show("Por favor escriba el Código...");
                return true;
            }
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Por favor escriba el Nombre...");
                return true;
            }
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                MessageBox.Show("Por favor escriba la Descripción...");
                return true;
            }
            if (string.IsNullOrEmpty(txtPrecio.Text))
            {
                MessageBox.Show("Por favor escriba el Precio...");
                return true;
            }


                return false;
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            vali.soloLetras(e);
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            vali.soloLetras(e);
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            vali.soloNumeros(e);
        }

        
    }
}