using Negocio;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Form1 : Form
    {
        string ruta_directorio_Raiz;
        public Form1()
        {
            InitializeComponent();
            fnt_CargarNivelEstudio();
            ruta_directorio_Raiz = Path.Combine(Application.StartupPath + "\\Imagenes");
            fnt_Nuevo();
        }
        private void fnt_Nuevo()
        {
            txt_Acudientes.Clear();
            txt_Contacto.Clear();
            txt_Correo.Clear();
            txt_Direccion.Clear();
            txt_Edad.Clear();
            txt_ID.Clear();
            txt_PApellido.Clear();
            txt_PNombre.Clear();
            txt_SApellido.Clear();
            txt_SNombre.Clear();
            cbx_Estudio.SelectedIndex = 0;
            ptb_Imagen.Image = Image.FromFile(ruta_directorio_Raiz + "\\nuevo.png");
            txt_ID.Focus();
        }
        private void fnt_CargarNivelEstudio()
        {
            cls_NivelEstudio objDt = new cls_NivelEstudio();
            objDt.fnt_CargarTipoEstudio();
            cbx_Estudio.ValueMember = "PKCodigo";
            cbx_Estudio.DisplayMember = "Nombre";
            cbx_Estudio.DataSource = objDt.getDt();
        }
        private void btn_Nuevo_Click(object sender, EventArgs e)
        {
            fnt_Nuevo();
        }
        private void btn_Guardar_Click(object sender, EventArgs e)
        {
           
            MemoryStream ms = new MemoryStream();
            ptb_Imagen.Image.Save(ms, ImageFormat.Jpeg);
            byte[] aByte = ms.ToArray();

           
            cls_AgregarCandidato objAgregarCandidato = new cls_AgregarCandidato(
                txt_ID.Text,txt_PNombre.Text,txt_SNombre.Text,txt_PApellido.Text, txt_SApellido.Text,
                txt_Contacto.Text,txt_Direccion.Text,txt_Correo.Text,txt_Edad.Text,
                cbx_Estudio.SelectedIndex+1,txt_Acudientes.Text, aByte);
            MessageBox.Show("" + objAgregarCandidato.getMsn());
            fnt_Nuevo() ;
        }

        private void ptb_Imagen_Click(object sender, EventArgs e)
        {
            try
            {
                ruta_directorio_Raiz = Path.Combine(Application.StartupPath + "\\Imagenes");
                OpenFileDialog file = new OpenFileDialog();
                file.Filter = "Archivo JPG|*.jpg";

                if (file.ShowDialog() == DialogResult.OK)
                {
                    ptb_Imagen.Image = Image.FromFile(file.FileName);
                }
            }
            catch { }
        }
        private void fnt_Consultar(string id)
        {
            cls_ConsultarCandidato obj_Consultar = new cls_ConsultarCandidato();
            obj_Consultar.fnt_Consultar(id);
            ptb_Imagen.Image = obj_Consultar.getBmp();
            txt_PNombre.Text = obj_Consultar.getPNombre();
            txt_SNombre.Text = obj_Consultar.getSNombre();
        }
        private void btn_Consultar_Click(object sender, EventArgs e)
        {
            fnt_Consultar(txt_ID.Text);
        }
    }
}