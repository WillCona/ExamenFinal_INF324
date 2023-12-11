using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace crudWeb
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod]
        public DataSet ListaEstudiante()
        {
            // Cadena de conexión a la base de datos MySQL
            string connectionString = "Server=localhost;Database=bd_surco;Uid=root;Pwd=";

            // Consulta SQL
            string query = "select * from persona";

            // Crear la conexión a la base de datos
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // Crear el adaptador de datos
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);

                // Crear y llenar el DataSet
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                return ds;
            }
        }

        [WebMethod]
        public int IngresarEstudiante(string ci, string nombre, string fechaNa, string telefono, string depto)
        {
            // Cadena de conexión a la base de datos MySQL
            string connectionString = "Server=127.0.0.1;Database=bd_surco;Uid=root;Pwd=";

            // Consulta SQL con parámetros
            string query = "INSERT INTO persona (ci, nombre_completo, fecha_nacimiento, telefono, departamento) VALUES (@ci, @nombre, @fechaNa, @telefono, @depto)";
            //STR_TO_DATE(fecha_str, '%Y-%m-%d')
            try
            {
                // Crear la conexión a la base de datos
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Crear el comando con la consulta de inserción
                    MySqlCommand insertCommand = new MySqlCommand(query, connection);

                    // Asignar valores a los parámetros
                    insertCommand.Parameters.AddWithValue("@ci", ci);
                    insertCommand.Parameters.AddWithValue("@nombre", nombre);
                    insertCommand.Parameters.AddWithValue("@fechaNa", fechaNa);
                    insertCommand.Parameters.AddWithValue("@telefono", telefono);
                    insertCommand.Parameters.AddWithValue("@depto", depto);

                    // Ejecutar la consulta de inserción
                    int rowsAffected = insertCommand.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción (por ejemplo, registrarla)
                return -1;
            }
        }


        [WebMethod]
        public String ActualizarEstudiante(string ci, string nombre, string fechaNa, string telefono, string depto)
        {
            // Cadena de conexión a la base de datos MySQL
            string connectionString = "Server=127.0.0.1;Database=bd_surco;Uid=root;Pwd=";

            // Consulta SQL con parámetros
            string query = "update persona set nombre_completo=@nombre, " +
                                            "fecha_nacimiento=@fechaNa, " +
                                            "telefono=@telefono, " +
                                            "departamento=@depto WHERE ci=@ci";
            //STR_TO_DATE(fecha_str, '%Y-%m-%d')
            try
            {
                // Crear la conexión a la base de datos
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Crear el comando con la consulta de inserción
                    MySqlCommand insertCommand = new MySqlCommand(query, connection);

                    // Asignar valores a los parámetros
                    insertCommand.Parameters.AddWithValue("@ci", ci);
                    insertCommand.Parameters.AddWithValue("@nombre", nombre);
                    insertCommand.Parameters.AddWithValue("@fechaNa", fechaNa);
                    insertCommand.Parameters.AddWithValue("@telefono", telefono);
                    insertCommand.Parameters.AddWithValue("@depto", depto);

                    // Ejecutar la consulta de inserción
                    int rowsAffected = insertCommand.ExecuteNonQuery();
                    return "ok";
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción (por ejemplo, registrarla)
                
                return ex.Message;
            }
        }


        [WebMethod]
        public String EliminarEstudiante(string ci)
        {
            // Cadena de conexión a la base de datos MySQL
            string connectionString = "Server=127.0.0.1;Database=bd_surco;Uid=root;Pwd=";

            // Consulta SQL con parámetros
            string query = "DELETE from persona where ci = @ci";
            //STR_TO_DATE(fecha_str, '%Y-%m-%d')
            try
            {
                // Crear la conexión a la base de datos
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Crear el comando con la consulta de inserción
                    MySqlCommand insertCommand = new MySqlCommand(query, connection);

                    // Asignar valores a los parámetros
                    insertCommand.Parameters.AddWithValue("@ci", ci);

                    // Ejecutar la consulta de inserción
                    int rowsAffected = insertCommand.ExecuteNonQuery();
                    return "ok";
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción (por ejemplo, registrarla)

                return ex.Message;
            }
        }
    }
}
