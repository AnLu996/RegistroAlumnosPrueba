using RegistroAlumnos.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace RegistroAlumnos
{
    public partial class Formulario : System.Web.UI.Page
    {
        protected void CrearDropDowlist()
        {
            /*---------- PARA LEER POR TXT---------
              
            try
            {
                String line;
                List<string> items = new List<string>();
                StreamReader sr = new StreamReader("E:Ciudades.txt");

                line = sr.ReadLine();
                items.Add(line);
                while (line != null)
                {
                    line = sr.ReadLine();
                    if (line != null)
                    {
                        items.Add(line);
                    }
                }
                sr.Close();
                items.Sort();
                items.Insert(0, "Eliga una opcion...");
                city.DataSource = items;
                city.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al leer el archivo: " + ex.Message);
            }*/

            String[] ciudades = serviceCall();
            Array.Sort(ciudades);
            city.Items.Add("Selecciona una opcion");
            for (int i = 0; i < ciudades.Length; i++)
            {
                string s = ciudades[i];
                city.Items.Add(s);
            }

        }
        private String[] serviceCall()
        {
            Service1Client client = new Service1Client();
            String[] ciudades = client.getCiudades();

            return ciudades;
        }
        protected void ButtonEnviar_Click(object sender, EventArgs e)
        {
            string nom = nombre.Text;
            string apell = apellido.Text;
            //string ciudad = city.SelectedValue;
            int ciudad = city.SelectedIndex;
            string correo = email.Text;
            bool sexf = sexo_femenino.Checked;
            bool sexm = sexo_masculino.Checked;
            string sex = " ";
            if (sexf)
            {

                sex = "femenino";

            }
            else
            {
                sex = "masculino";

            }

            string direc = direccion.Text;
            string reque = requerimientos.Text;

            labelreg.Visible = true;
            informacion.Text = "Nombre: " + nom + "\nApellido: " + apell + "\nGenero: " + sex + "\nEmail: " + correo + "\nDireccion: " + direc + "\nCiudad: " + ciudad + "\nRequerimentos: " + reque;
            informacion.Visible = true;
            Service1Client client = new Service1Client();
            client.Information(nom, apell, sex, correo, direc, ciudad, reque);
            
            CreateSession(nom, apell);
            CreateCookie(correo, sex, direc, reque);

            Response.Redirect("Auxiliar.aspx");
            
            Clean();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CrearDropDowlist();
            }
        }
        protected void Clean()
        {
            nombre.Text = " ";
            apellido.Text = " ";
            city.SelectedIndex = 0;
            email.Text = " ";
            sexo_femenino.Checked = false;
            sexo_masculino.Checked = false;
            direccion.Text = " ";
            requerimientos.Text = " ";


        }

        private void CreateSession(String nombre, String apellido)
        {
            Session["Nombre"] = nombre;
            Session["Apellido"] = apellido;
        }
        private void CreateCookie(String email, String sexo, String direccion, String requerimiento)
        {
            HttpCookie cookie1 = new HttpCookie("Email", email);
            Response.Cookies.Add(cookie1);
            HttpCookie cookie2 = new HttpCookie("Sexo", sexo);
            Response.Cookies.Add(cookie2);
            HttpCookie cookie3 = new HttpCookie("Direccion", direccion);
            Response.Cookies.Add(cookie3);
            HttpCookie cookie4 = new HttpCookie("Requerimiento", requerimiento);
            Response.Cookies.Add(cookie4);
        }

    }
}