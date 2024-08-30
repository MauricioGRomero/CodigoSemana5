using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataSourceDemo
{
    // Esta es la clase principal del formulario, que hereda de la clase Form de Windows Forms.
    public partial class Form2 : Form
    {
        // Constructor del formulario. Aquí se inicializan los componentes del formulario.
        public Form2()
        {
            InitializeComponent();
        }

        // Método que se ejecuta cuando se hace clic en el botón de guardar (bindingNavigatorSaveItem).
        // Valida los cambios en los controles del formulario, finaliza la edición del origen de datos
        // y luego actualiza la base de datos utilizando el TableAdapterManager.
        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.customersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwindDataSet);
        }

        // Método que se ejecuta cuando el formulario se carga.
        // Aquí se carga la información de la tabla 'Customers' del DataSet 'northwindDataSet'.
        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'northwindDataSet.Customers'
            // Puede moverla o quitarla según sea necesario.
            this.customersTableAdapter.Fill(this.northwindDataSet.Customers);
        }

        // Manejador de eventos para cuando se hace clic en la caja de texto (cajaTextoID).
        // Actualmente no realiza ninguna acción.
        private void cajaTextoID_Click(object sender, EventArgs e)
        {

        }

        // Manejador de eventos para cuando se presiona una tecla en la caja de texto (cajaTextoID).
        // Si se presiona la tecla Enter (char 13), se busca en el origen de datos un cliente con el ID
        // introducido en la caja de texto. Si se encuentra, se mueve la posición del BindingSource a ese cliente;
        // de lo contrario, se muestra un mensaje indicando que el elemento no fue encontrado.
        private void cajaTextoID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) // Verifica si se presiona la tecla Enter
            {
                // Busca la posición del cliente en el BindingSource por su ID
                var index = customersBindingSource.Find("customerID", cajaTextoID);
                if (index > -1)
                {
                    // Si se encuentra, establece la posición del BindingSource en ese cliente
                    customersBindingSource.Position = index;
                    return;
                }
                else
                {
                    // Si no se encuentra, muestra un mensaje de alerta
                    MessageBox.Show("Elemento no encontrado");
                }
            }
        }
    }
}
