using RutinApp.Controllers;
using RutinApp.Models;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace RutinApp.Views
{
    public partial class frmSelectorClientes : Form
    {
        private CustomerController customerController;
        public int iDCustomer { get; set; }
        public string customerName { get; set; }
        public frmSelectorClientes()
        {
            customerController = new CustomerController();
            InitializeComponent();
            LoadGrid();

        }
        private async void LoadGrid()
        {
            List<Customer> customerList = await customerController.GetAllCustomers();

            if (customerList != null)
            {
                foreach (Customer customer in customerList)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dgvClientes);

                    row.Cells[0].Value = customer.ID;
                    row.Cells[1].Value = customer.FirstName + " " + customer.LastName1 + " " + customer.LastName2;
                    row.Cells[2].Value = customer.PhoneNumber;

                    dgvClientes.Rows.Add(row);

                }
            }
            else
            {
                MessageBox.Show("No se pudo cargar las rutinas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            cargarCliente();
        }

        private void dgvClientes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            cargarCliente();
        }

        private void cargarCliente() 
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvClientes.SelectedRows[0];

                if (selectedRow.Cells.Count > 0)
                {
                    // Pasamos el id del training al forms principal
                    iDCustomer = (int)selectedRow.Cells[0].Value;
                    customerName = selectedRow.Cells[1].Value.ToString();
                    this.Close();
                }
            }
        }
    }
}
