using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectForm
{
    public partial class Auxiliar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadSession();
            DeleteSessions();
        }

        private void LoadSession()
        {
            String nombre = (String)(Session["Nombre"]);
            String apellido = (String)(Session["Apellido"]);
            // Asignacion de la informacion a los campos HTML respectivos
            LabelUsuario.Text = "Enviado por Sesion: ";
            LabelNombre.Text = "Nombre: " + nombre;
            LabelApellido.Text = " Apellido: " + apellido;
        }
        private void DeleteSessions()
        {
            Session.RemoveAll();
            Session.Abandon();
        }

        [WebMethod]
        public static String getInformacion(String valor)
        {
            return "Desde el servidor se recibio:" + valor;
        }

    }
}