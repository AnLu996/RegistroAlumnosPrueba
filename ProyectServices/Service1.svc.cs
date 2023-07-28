using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Services;
using System.Web.Services.Description;
using ProyectData;

namespace ProyectServices
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        public IList<String> getCiudades()
        {
            Ciudad ciudades = new Ciudad();
            IList<String> city = ciudades.getCiudades();
            return city;

            //IList<String> ciudades = File.ReadAllLines("F:\\Departamentos.txt");
            //return ciudades;
        }

        public void Information(string nombre, string apellido, string sexo, string email, string direccion, int ciudad, string requerimiento)
        {
            DataAlumnos dataAlumnos = new DataAlumnos();
            dataAlumnos.Ingresar_Alumnos(nombre, apellido, sexo, email, direccion, ciudad, requerimiento);

            //string filepath = "F:\\Respuesta.txt";
            //string respuesta = "Nombre: " + nombre + "\nApellido: " + apellido + "\nSexo: " + sexo + "\nEmail: " + email + "\nDireccion: " + direccion
            //    + "\nCiudad: " + ciudad + "\nRequerimiento: " + requerimiento;
            //File.WriteAllText(filepath, respuesta);
        }

        public bool Verificar(string nombre, string apellido)
        {
            DataAlumnos datos = new DataAlumnos();
            bool estado = datos.VerificarNombreApellido(nombre, apellido);

            return estado;

        }
    }
}
