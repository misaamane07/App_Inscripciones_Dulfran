using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.Remoting.Messaging;

namespace Datos
{
    public class cls_Funciones_Candidatos
    {
        private DataTable dt;
        private Bitmap bmp;
        private string str_pnombre;
        private string str_snombre;
        private string str_papellido;
        private string str_sapellido;
        private string str_contacto;
        private string str_direccion;
        private string str_correo;
        private string str_edad;
        private int  int_estudio;
        private string acudientes;
        public void fnt_Guardar(
            string id, string p_nombre, string s_nombre, 
            string p_apellido, string s_apellido,string contacto, string direccion,
            string correo, string edad, int estudio, string acudientes, byte[] imagen)
        {
            try
            {
                cls_Conexion obj_conexion = new cls_Conexion();
                obj_conexion.fnt_Conectar();
                string consulta = "insert into tbl_personas(PKId,P_Nombre,S_Nombre," +
                    "P_Apellido,S_Apellido,Contacto,Dirección,Correo,Edad,FKCodigo_tbl_nivelestudio,Acudiente, Imagen)" +
                    "values ('"+id+"','"+p_nombre+"','"+s_nombre+"','"+p_apellido+"','"+s_apellido+"','"+contacto+"','"+direccion+"'," +
                    "'"+correo+"','"+edad+"','"+estudio+"','"+acudientes+"','"+imagen+"')";
                MySqlCommand comando = new MySqlCommand(consulta, obj_conexion.conex);
                MySqlDataReader lectura = comando.ExecuteReader();
                obj_conexion.fnt_Desconectar();
            }catch(Exception) { }
        }
        public void fnt_CargarNivelEstudio()
        {
            string sql = "select PKCodigo,Nombre from tbl_nivelestudio";
            cls_Conexion objConecta = new cls_Conexion();
            objConecta.fnt_Conectar();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, objConecta.conex);
                dt = new DataTable();
                MySqlDataAdapter Data = new MySqlDataAdapter(comando);
                Data.Fill(dt);
            }
            catch (Exception)
            {
                objConecta.fnt_Desconectar();
            }
        }
        public DataTable getDt() { return  dt; }
        public void fnt_Consultar(string id)
        {
            Console.WriteLine("ID" + id);
            String sql = "select P_Nombre,S_Nombre,P_Apellido,S_Apellido,Contacto,Dirección,Correo,Edad,FKCodigo_tbl_nivelestudio,Acudiente,Imagen from tbl_personas where PKId = '" + id + "'";
            cls_Conexion obj_Conectar = new cls_Conexion();
            obj_Conectar.fnt_Conectar();
           
                MySqlCommand comando = new MySqlCommand(sql, obj_Conectar.conex);
                MySqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    MemoryStream ms = new MemoryStream((byte[])reader["Imagen"]);
                    bmp = new Bitmap(ms);
                    str_pnombre = reader["P_Nombre"].ToString();
                    str_snombre = reader["S_Nombre"].ToString();
                    str_papellido = reader["P_Apellido"].ToString();
                    str_sapellido = reader["S_Apellido"].ToString();
                    str_contacto = reader["Contacto"].ToString();
                    str_direccion = reader["Dirección"].ToString() ;
                    str_correo = reader["Correo"].ToString();
                    str_edad = reader["Edad"].ToString();
                    int_estudio = Convert.ToInt16(reader["FKCodigo_tbl_nivelestudio"].ToString());
                    acudientes = reader["Acudiente"].ToString();
                    Console.WriteLine ("Nombre: " + str_pnombre);
                }
            
            obj_Conectar.fnt_Desconectar();
        }
        public Bitmap getBmp() { return this.bmp; }
        public string getPNombre() { return this.str_pnombre; }
        public string getSNombre() { return this.str_snombre;}
        public string getPApellido() { return this.str_papellido; }
        public string getSApellido() { return this.str_sapellido; }
        public string getContacto() { return this.str_contacto; }
        public string getDireccion() { return this.str_direccion; }
        public string getCorreo() { return  this.str_correo; }
        public string getEdad() { return this.str_edad; }
        public int getEstudio() { return this.int_estudio; }
        public string getAcudientes() {  return this.acudientes; }
    }
}