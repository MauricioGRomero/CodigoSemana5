using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DatosLayer
{
    // Repositorio para la entidad "Customers", maneja operaciones CRUD con la base de datos.
    public class CustomerRepository
    {
        // Método para obtener todos los registros de la tabla "Customers".
        public List<Customers> ObtenerTodos()
        {
            using (var conexion = DataBase.GetSqlConnection())
            {
                String selectFrom = "";
                selectFrom = selectFrom + "SELECT [CustomerID], [CompanyName], [ContactName], [ContactTitle], " +
                             "[Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax] " +
                             "FROM [dbo].[Customers]";

                using (SqlCommand comando = new SqlCommand(selectFrom, conexion))
                {
                    SqlDataReader reader = comando.ExecuteReader();
                    List<Customers> Customers = new List<Customers>();

                    while (reader.Read())
                    {
                        var customers = LeerDelDataReader(reader); // Método que convierte cada fila en un objeto "Customers".
                        Customers.Add(customers);
                    }
                    return Customers;
                }
            }
        }

        // Método para obtener un cliente específico por su ID.
        public Customers ObtenerPorID(string id)
        {
            using (var conexion = DataBase.GetSqlConnection())
            {

                String selectForID = "";
                selectForID = selectForID + "SELECT [CustomerID], [CompanyName], [ContactName], [ContactTitle], " +
                             "[Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax] " +
                             "FROM [dbo].[Customers] WHERE CustomerID = @customerId";

                using (SqlCommand comando = new SqlCommand(selectForID, conexion))
                {
                    comando.Parameters.AddWithValue("customerId", id);
                    var reader = comando.ExecuteReader();
                    Customers customers = null;

                    if (reader.Read())
                    {
                        customers = LeerDelDataReader(reader);
                    }
                    return customers;
                }
            }
        }

        // Método para leer los datos de un SqlDataReader y convertirlos en un objeto "Customers".
        public Customers LeerDelDataReader(SqlDataReader reader)
        {
            Customers customers = new Customers();
            customers.CustomerID = reader["CustomerID"] == DBNull.Value ? " " : (String)reader["CustomerID"];
            customers.CompanyName = reader["CompanyName"] == DBNull.Value ? "" : (String)reader["CompanyName"];
            customers.ContactName = reader["ContactName"] == DBNull.Value ? "" : (String)reader["ContactName"];
            customers.ContactTitle = reader["ContactTitle"] == DBNull.Value ? "" : (String)reader["ContactTitle"];
            customers.Address = reader["Address"] == DBNull.Value ? "" : (String)reader["Address"];
            customers.City = reader["City"] == DBNull.Value ? "" : (String)reader["City"];
            customers.Region = reader["Region"] == DBNull.Value ? "" : (String)reader["Region"];
            customers.PostalCode = reader["PostalCode"] == DBNull.Value ? "" : (String)reader["PostalCode"];
            customers.Country = reader["Country"] == DBNull.Value ? "" : (String)reader["Country"];
            customers.Phone = reader["Phone"] == DBNull.Value ? "" : (String)reader["Phone"];
            customers.Fax = reader["Fax"] == DBNull.Value ? "" : (String)reader["Fax"];
            return customers;
        }

        // Método para insertar un nuevo cliente en la base de datos.
        public int InsertarCliente(Customers customer)
        {
            using (var conexion = DataBase.GetSqlConnection())
            {
                String insertInto = "";
                insertInto = insertInto + "INSERT INTO [dbo].[Customers] " +
                             "([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City]) " +
                             "VALUES (@CustomerID, @CompanyName, @ContactName, @ContactTitle, @Address, @City)";

                using (var comando = new SqlCommand(insertInto, conexion))
                {
                    int insertados = parametrosCliente(customer, comando); // Método que configura los parámetros SQL.
                    return insertados;
                }
            }
        }

        // Método para actualizar los datos de un cliente existente en la base de datos.
        public int ActualizarCliente(Customers customer)
        {
            using (var conexion = DataBase.GetSqlConnection())
            {
                String ActualizarCustomerPorID = "";
                ActualizarCustomerPorID = ActualizarCustomerPorID + "UPDATE [dbo].[Customers] " +
                                          "SET [CustomerID] = @CustomerID, [CompanyName] = @CompanyName, " +
                                          "[ContactName] = @ContactName, [ContactTitle] = @ContactTitle, " +
                                          "[Address] = @Address, [City] = @City " +
                                          "WHERE CustomerID= @CustomerID";

                using (var comando = new SqlCommand(ActualizarCustomerPorID, conexion))
                {
                    int actualizados = parametrosCliente(customer, comando);
                    return actualizados;
                }
            }
        }

        // Método auxiliar para configurar los parámetros SQL comunes entre insertar y actualizar.
        public int parametrosCliente(Customers customer, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("CustomerID", customer.CustomerID);
            comando.Parameters.AddWithValue("CompanyName", customer.CompanyName);
            comando.Parameters.AddWithValue("ContactName", customer.ContactName);
            comando.Parameters.AddWithValue("ContactTitle", customer.ContactName); // Aquí debería ser "customer.ContactTitle"
            comando.Parameters.AddWithValue("Address", customer.Address);
            comando.Parameters.AddWithValue("City", customer.City);
            var insertados = comando.ExecuteNonQuery(); // Ejecuta la instrucción SQL.
            return insertados;
        }

        // Método para eliminar un cliente de la base de datos por su ID.
        public int EliminarCliente(string id)
        {
            using (var conexion = DataBase.GetSqlConnection())
            {
                String EliminarCliente = "";
                EliminarCliente = EliminarCliente + "DELETE FROM [dbo].[Customers] " +
                                  "WHERE CustomerID = @CustomerID";

                using (SqlCommand comando = new SqlCommand(EliminarCliente, conexion))
                {
                    comando.Parameters.AddWithValue("@CustomerID", id);
                    int eliminados = comando.ExecuteNonQuery(); // Ejecuta la instrucción SQL.
                    return eliminados;
                }
            }
        }
    }
}
