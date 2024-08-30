using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace DatosLayer
{
    // Clase que maneja la conexión a la base de datos y su configuración.
    public class DataBase
    {
        // Propiedad estática que obtiene la cadena de conexión configurada.
        public static string ConnectionString
        {
            get
            {
                // Obtiene la cadena de conexión de la configuración.
                string CadenaConexion = ConfigurationManager
                    .ConnectionStrings["NWConnection"]
                    .ConnectionString;

                // Construye una cadena de conexión SQL basada en la existente.
                SqlConnectionStringBuilder conexionBuilder =
                    new SqlConnectionStringBuilder(CadenaConexion);

                // Si se ha establecido un nombre de aplicación, lo asigna a la cadena de conexión.
                conexionBuilder.ApplicationName =
                    ApplicationName ?? conexionBuilder.ApplicationName;

                // Si se ha establecido un tiempo de espera, lo asigna a la cadena de conexión.
                conexionBuilder.ConnectTimeout = (ConnectionTimeout > 0)
                    ? ConnectionTimeout : conexionBuilder.ConnectTimeout;

                // Devuelve la cadena de conexión completa.
                return conexionBuilder.ToString();
            }
        }

        // Propiedad estática para establecer o obtener el tiempo de espera de la conexión.
        public static int ConnectionTimeout { get; set; }

        // Propiedad estática para establecer o obtener el nombre de la aplicación que se conecta a la base de datos.
        public static string ApplicationName { get; set; }

        // Método estático que crea y abre una conexión SQL usando la cadena de conexión configurada.
        public static SqlConnection GetSqlConnection()
        {
            // Crea una nueva conexión SQL usando la cadena de conexión.
            SqlConnection conexion = new SqlConnection(ConnectionString);
            // Abre la conexión.
            conexion.Open();
            // Devuelve la conexión abierta.
            return conexion;
        }
    }
}
