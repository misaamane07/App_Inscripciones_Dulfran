using System;
using System.Drawing;
using Datos;
namespace Negocio
{
    public class cls_ConsultarCandidato
    {
        private Bitmap bmp;
        private string str_pnombre;
        private string str_snombre;
        private string str_papellido;
        private string str_sapellido;
        private string str_contacto;
        private string str_direccion;
        private string str_correo;
        private string str_edad;
        private int int_estudio;
        private string acudientes;
        public void fnt_Consultar(string id)
        {
            Console.WriteLine(id);
            cls_Funciones_Candidatos obj_Consultar = new cls_Funciones_Candidatos();
            obj_Consultar.fnt_Consultar(id);
            this.bmp = obj_Consultar.getBmp();
            this.str_pnombre = obj_Consultar.getPNombre();
            this.str_snombre = obj_Consultar.getSNombre();
            this.str_papellido = obj_Consultar.getPApellido();
            this.str_sapellido = obj_Consultar.getSApellido();
            this.str_contacto = obj_Consultar.getContacto();
            this.str_direccion = obj_Consultar.getDireccion();
            this.str_correo = obj_Consultar.getCorreo();
            this.str_edad = obj_Consultar.getEdad();
            this.int_estudio = obj_Consultar.getEstudio();
            this.acudientes = obj_Consultar.getAcudientes();
        }
        public Bitmap getBmp() { return this.bmp; }
        public string getPNombre() { return this.str_pnombre; }
        public string getSNombre() { return this.str_snombre; }
        public string getPApellido() { return this.str_papellido; }
        public string getSApellido() { return this.str_sapellido; }
        public string getContacto() { return this.str_contacto; }
        public string getDireccion() { return this.str_direccion; }
        public string getCorreo() { return this.str_correo; }
        public string getEdad() { return this.str_edad; }
        public int getEstudio() { return this.int_estudio; }
        public string getAcudientes() { return this.acudientes; }
    }
}