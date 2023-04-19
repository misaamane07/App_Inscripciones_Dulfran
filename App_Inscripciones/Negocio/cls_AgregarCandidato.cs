using System;
using System.Reflection.Emit;
using Datos;
namespace Negocio
{
    public class cls_AgregarCandidato
    {
        private string str_id;
        private string str_pnombre;
        private string str_snombre;
        private string str_papellido;
        private string str_sapellido;
        private string str_contacto;
        private string str_direccion;
        private string str_correo;
        private string str_edad;
        private int int_estudio;
        private string str_acudientes;
        private byte[] byt_imagen;
        private string str_msn;//Enviar mensajes a la capa de presentación.

        public cls_AgregarCandidato(string str_id, string str_pnombre, string str_snombre, string str_papellido, string str_sapellido, string str_contacto, string str_direccion, string str_correo, string str_edad, int int_estudio, string str_acudientes, byte[] aByte)
        {
            this.str_id = str_id;
            this.str_pnombre = str_pnombre;
            this.str_snombre = str_snombre;
            this.str_papellido = str_papellido;
            this.str_sapellido = str_sapellido;
            this.str_contacto = str_contacto;
            this.str_direccion = str_direccion;
            this.str_correo = str_correo;
            this.str_edad = str_edad;
            this.int_estudio = int_estudio;
            this.str_acudientes = str_acudientes;
            this.byt_imagen = aByte;
            if (str_id == "" || str_pnombre == "" || str_snombre == "" || str_papellido == "" ||
                str_sapellido == "" || str_contacto == "" || str_direccion == "" ||
                str_correo == "" || str_edad == "" || str_acudientes == "")
            {
                str_msn = "Debe ingresar toda la información requerida";
            }
            else
            {
                cls_Funciones_Candidatos objGuardar = new cls_Funciones_Candidatos();
                objGuardar.fnt_Guardar
                    (str_id, str_pnombre, str_snombre, str_papellido, str_sapellido,
                    str_contacto, str_direccion, str_correo, str_edad, int_estudio, 
                    str_acudientes, byt_imagen);
                str_msn = "El candadidato " + str_pnombre + " ha sido registrado";
            }
        }
        public string getMsn() { return this.str_msn; }
    }
}