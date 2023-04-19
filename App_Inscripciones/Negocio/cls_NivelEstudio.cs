using System;
using System.Data;
using Datos;
namespace Negocio
{
    public class cls_NivelEstudio
    {
        private DataTable dt;
        public void fnt_CargarTipoEstudio()
        {
            cls_Funciones_Candidatos objDt = new cls_Funciones_Candidatos();
            objDt.fnt_CargarNivelEstudio();
            this.dt = objDt.getDt();
        }
        public DataTable getDt() { return this.dt; }
    }
}