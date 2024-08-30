using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DatosLayer;
using System.Net;
using System.Reflection;

namespace ConexionEjemplo
{
    // Clase principal del formulario que maneja la interfaz para gestionar datos de clientes.
    public partial class Form1 : Form
    {
        // Instancia de un repositorio de clientes, que maneja la interacción con la base de datos.
        CustomerRepository customerRepository = new CustomerRepository();

        // Constructor del formulario. Aquí se inicializan los componentes de la interfaz.
        public Form1()
        {
            InitializeComponent();
        }

        // Método que se ejecuta al hacer clic en el botón 'Cargar'. 
        // Recupera todos los clientes desde la base de datos y los muestra en un DataGridView.
        private void btnCargar_Click(object sender, EventArgs e)
        {
            var Customers = customerRepository.ObtenerTodos();
            dataGrid.DataSource = Customers;
        }

        // Manejador de eventos para el cambio de texto en un TextBox.
        // Este método tiene código comentado que sugiere una funcionalidad para filtrar los clientes
        // por el nombre de la empresa en función del texto ingresado.
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Código comentado para filtrar los clientes según el nombre de la empresa.
            // var filtro = Customers.FindAll(X => X.CompanyName.StartsWith(tbFiltro.Text));
            // dataGrid.DataSource = filtro;
        }

        // Método que se ejecuta cuando se carga el formulario.
        // Contiene código comentado que configuraría la conexión a la base de datos.
        private void Form1_Load(object sender, EventArgs e)
        {
            /* Código comentado para configurar la conexión a la base de datos
            DatosLayer.DataBase.ApplicationName = "Programacion 2 ejemplo";
            DatosLayer.DataBase.ConnectionTimeout = 30;
            string cadenaConexion = DatosLayer.DataBase.ConnectionString;
            var conexion = DatosLayer.DataBase.GetSqlConnection();
            */
        }

        // Método que se ejecuta al hacer clic en el botón 'Buscar'.
        // Busca un cliente por su ID y muestra sus datos en los TextBox correspondientes.
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var cliente = customerRepository.ObtenerPorID(txtBuscar.Text);
            tboxCustomerID.Text = cliente.CustomerID;
            tboxCompanyName.Text = cliente.CompanyName;
            tboxContacName.Text = cliente.ContactName;
            tboxContactTitle.Text = cliente.ContactTitle;
            tboxAddress.Text = cliente.Address;
            tboxCity.Text = cliente.City;
        }

        // Manejador de eventos para clic en un label (etiqueta). 
        // Este método actualmente no realiza ninguna acción.
        private void label4_Click(object sender, EventArgs e)
        {

        }

        // Método que se ejecuta al hacer clic en el botón 'Insertar'.
        // Inserta un nuevo cliente en la base de datos si todos los campos son válidos y no están vacíos.
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            var resultado = 0;

            var nuevoCliente = ObtenerNuevoCliente();

            // Código comentado que originalmente validaba los campos manualmente.
            // Ahora se usa una función `validarCampoNull` para verificar si hay campos vacíos.

            if (validarCampoNull(nuevoCliente) == false)
            {
                resultado = customerRepository.InsertarCliente(nuevoCliente);
                MessageBox.Show("Guardado" + "Filas modificadas = " + resultado);
            }
            else
            {
                MessageBox.Show("Debe completar los campos por favor");
            }
        }

        // Método que valida si algún campo del objeto cliente es nulo o está vacío.
        // Si se encuentra un campo vacío, devuelve true; de lo contrario, false.
        public Boolean validarCampoNull(Object objeto)
        {
            foreach (PropertyInfo property in objeto.GetType().GetProperties())
            {
                object value = property.GetValue(objeto, null);
                if ((string)value == "")
                {
                    return true;
                }
            }
            return false;
        }

        // Manejador de eventos para clic en un label (etiqueta).
        // Este método actualmente no realiza ninguna acción.
        private void label5_Click(object sender, EventArgs e)
        {

        }

        // Método que se ejecuta al hacer clic en el botón 'Modificar'.
        // Actualiza la información de un cliente en la base de datos.
        private void btModificar_Click(object sender, EventArgs e)
        {
            var actualizarCliente = ObtenerNuevoCliente();
            int actualizadas = customerRepository.ActualizarCliente(actualizarCliente);
            MessageBox.Show($"Filas actualizadas = {actualizadas}");
        }

        // Método que crea un nuevo objeto cliente con los valores ingresados en los TextBox del formulario.
        private Customers ObtenerNuevoCliente()
        {
            var nuevoCliente = new Customers
            {
                CustomerID = tboxCustomerID.Text,
                CompanyName = tboxCompanyName.Text,
                ContactName = tboxContacName.Text,
                ContactTitle = tboxContactTitle.Text,
                Address = tboxAddress.Text,
                City = tboxCity.Text
            };

            return nuevoCliente;
        }

        // Método que se ejecuta al hacer clic en el botón 'Eliminar'.
        // Elimina un cliente de la base de datos utilizando su ID.
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int eliminadas = customerRepository.EliminarCliente(tboxCustomerID.Text);
            MessageBox.Show("Filas eliminadas = " + eliminadas);
        }
    }
}
