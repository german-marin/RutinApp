using RutinApp.Controllers;
using RutinApp.Models;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace RutinApp.Views
{
    public partial class frmSelectorClientes : Form
    {
        private CustomerController customerController;
        private List<Customer> customerList;
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
            customerList = await customerController.GetAllCustomers();

            if (customerList != null)
            {
                FillGrid(customerList);
            }
            else
            {
                MessageBox.Show("No se pudo cargar los clientes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void FillGrid(List<Customer> customers)
        {
            dgvClientes.Rows.Clear();
            foreach (Customer customer in customers)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvClientes);

                row.Cells[0].Value = customer.ID;
                row.Cells[1].Value = customer.FirstName;
                row.Cells[2].Value = customer.LastName1;
                row.Cells[3].Value = customer.LastName2;
                row.Cells[4].Value = customer.PhoneNumber;

                dgvClientes.Rows.Add(row);
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
                    customerName = selectedRow.Cells[1].Value.ToString() + selectedRow.Cells[2].Value.ToString() + selectedRow.Cells[3].Value.ToString();
                    this.Close();
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario secundario
            frmAltaCliente popupForm = new frmAltaCliente();
            popupForm.IDCustomer = int.Parse(dgvClientes.SelectedRows[0].Cells[0].Value.ToString());

            // Mostrar el formulario secundario como un cuadro de diálogo modal
            popupForm.ShowDialog();
            LoadGrid();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario secundario
            frmAltaCliente popupForm = new frmAltaCliente();

            // Mostrar el formulario secundario como un cuadro de diálogo modal
            popupForm.ShowDialog();
            LoadGrid();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas borrar este cliente?", "Confirmar borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var deleteCompleted = await customerController.DeleteCustomer(int.Parse(dgvClientes.SelectedRows[0].Cells[0].Value.ToString()));
                if (deleteCompleted)
                {
                    LoadGrid();
                }
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string filterText = txtFilter.Text.ToLower();
            var filteredList = customerList.Where(c =>
                c.FirstName.ToLower().Contains(filterText) ||
                c.LastName1.ToLower().Contains(filterText) ||
                c.LastName2.ToLower().Contains(filterText)
            ).ToList();

            FillGrid(filteredList);
        }
    }
}
