using MySql.Data.MySqlClient;
using System;

namespace Datos
{
    public class cls_Conexion
    {
        public MySqlConnection conex;
        string cadenaconexion;
        public void fnt_Conectar()
        {
            conex = new MySqlConnection();
            //************* CONEXION LOCAL ******************
            String servidor = "10.230.16.156";
            String bd = "dbs_inscripcion_dulfran";
            String usuario = "yoyito";
            String contraseña = "Sena2023";
            String puerto = "3306";
            cadenaconexion = "server=" + servidor + ";port=" + puerto + ";user id=" + usuario + ";password=" + contraseña + ";database=" + bd + ";";
            try
            {
                conex.ConnectionString = cadenaconexion;
                conex.Open();
                //MessageBox.Show("Conexión establecida con el servidor de bases de datos");
            }
            catch (Exception)
            {
                //MessageBox.Show("No es posible conectar con el servidor de bases de datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return conex;
            }
        }
        public void fnt_Desconectar() { conex.Close(); }
    }
}