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
    public partial class Form1 : Form
    {
        // Constructor del formulario. Aquí se inicializan los componentes del formulario.
        public Form1()
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

        // Este es otro manejador de eventos para el clic del botón de guardar.
        // Parece ser un duplicado del anterior, lo que podría ser innecesario.
        private void customersBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.customersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwindDataSet);
        }

        // Un tercer manejador de eventos para el mismo botón. Al igual que los anteriores,
        // valida, finaliza la edición y actualiza la base de datos.
        private void customersBindingNavigatorSaveItem_Click_2(object sender, EventArgs e)
        {
            this.Validate();
            this.customersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwindDataSet);
        }

        // Método que se ejecuta cuando el formulario se carga.
        // Aquí se carga la información de la tabla 'Customers' del DataSet 'northwindDataSet'.
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'northwindDataSet.Customers'
            // Puede moverla o quitarla según sea necesario.
            this.customersTableAdapter.Fill(this.northwindDataSet.Customers);
        }

        // Manejador de eventos para cuando se hace clic en una celda del DataGridView.
        // Actualmente no realiza ninguna acción.
        private void customersDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
