using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Data;

namespace Datos
{
    public class cls_Funciones_Candidatos
    {
        private DataTable dt;
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
    }
}