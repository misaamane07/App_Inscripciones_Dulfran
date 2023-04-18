using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
namespace Datos
{
    public class cls_Funciones_Candidatos
    {
        public void fnt_Guardar(
            string id, string p_nombre, string s_nombre, 
            string p_apellido, string s_apellido,string contacto, string direccion,
            string correo, string edad, int estudio, string acudientes)
        {
            try
            {
                cls_Conexion obj_conexion = new cls_Conexion();
                obj_conexion.fnt_Conectar();
                string consulta = "insert into tbl_personas(PKId,P_Nombre,S_Nombre," +
                    "P_Apellido,S_Apellido,Contacto,Dirección,Correo,Edad,FKCodigo_tbl_nivelestudio,Acudiente)" +
                    "values ('"+id+"','"+p_nombre+"','"+s_nombre+"','"+p_apellido+"','"+s_apellido+"','"+contacto+"','"+direccion+"'," +
                    "'"+correo+"','"+edad+"','"+estudio+"','"+acudientes+"')";
                MySqlCommand comando = new MySqlCommand(consulta, obj_conexion.conex);
                MySqlDataReader lectura = comando.ExecuteReader();
                obj_conexion.fnt_Desconectar();
            }catch(Exception) { }
        }
    }
}