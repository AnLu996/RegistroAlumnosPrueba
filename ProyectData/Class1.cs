using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectData
{
    class DBconnection
    {
        public static void Main(string[] args)
        {
            DBconnection dBconnection = new DBconnection();
            dBconnection.query();

            Console.ReadKey();
        }

        private void query()
        {
            Ciudad ciudad = new Ciudad();
            IList<string> ciudades = ciudad.getCiudades();

            if (ciudades == null)
            {
                Console.WriteLine("No data");
                return;
            }

            for (int i = 0; i < ciudades.Count; i++)
            {
                Console.WriteLine(ciudades[i]);
            }
            DataAlumnos dataAlumnos = new DataAlumnos();
            dataAlumnos.Ingresar_Alumnos("Giomar", "Muñoz Curi", "Masculino", "gmunozcu@unsa.edu.pe", "Alto Selva Alegre", 4, "Estudiante de Ciencia de la Computacion");
        }
    }
    public class Ciudad
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=RegistroAlumnos;Integrated Security=True";

        public IList<string> getCiudades()
        {
            List<string> ciudades = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "select Ciudad from DataCiudad";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string ciudad = reader.GetString(0);
                        ciudades.Add(ciudad);
                    }

                    reader.Close();
                }
            }
            return ciudades;
        }

    }
    public class DataAlumnos
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=RegistroAlumnos;Integrated Security=True";

        public void Ingresar_Alumnos(string nombre, string apellido, string sexo, string email, string direccion, int ciudad, string requerimiento)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string insertQuery = "INSERT INTO DataAlumnos VALUES(@Nombre, @Apellidos, @Sexo, @Email, @Direccion, @Codeciudad, @Requerimiento)";

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Apellidos", apellido);
                    command.Parameters.AddWithValue("@Sexo", sexo);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Direccion", direccion);
                    command.Parameters.AddWithValue("@Codeciudad", ciudad);
                    command.Parameters.AddWithValue("@Requerimiento", requerimiento);

                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public bool VerificarNombreApellido(string nombre, string apellido)
        {

            //string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=RegistroAlumnos;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM alumnos WHERE nombre = @Nombre AND apellido = @Apellido";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", nombre);
                        command.Parameters.AddWithValue("@Apellido", apellido);

                        int count = Convert.ToInt32(command.ExecuteScalar());

                        return count > 0;
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}