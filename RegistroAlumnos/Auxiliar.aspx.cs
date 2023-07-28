using RegistroAlumnos.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistroAlumnos
{
    public partial class Auxiliar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadSession();
            deleteSessions();
        }

        private void loadSession()
        {
            String nombre = (String)(Session["Nombre"]);
            String apellido = (String)(Session["Apellido"]);
            // Asignacion de la informacion a los campos HTML respectivos
            LabelUsuario.Text = "Enviado por Sesion: ";
            LabelNombre.Text = "Nombre: " + nombre;
            LabelApellido.Text = " Apellido: " + apellido;
        }
        private void deleteSessions()
        {
            Session.RemoveAll();
            Session.Abandon();
        }
    }
}