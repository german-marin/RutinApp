using RutinApp.Controllers;
using RutinApp.Models;

namespace RutinApp.Views
{
    public partial class frmSelectorRutinas : Form
    {
        private TrainingController trainingController;
        private CustomerController customerController;
        public int IDTraining { get; set; }
        public int IDCustomer { get; set; }
        public frmSelectorRutinas()
        {
            trainingController = new TrainingController();
            customerController = new CustomerController();
            InitializeComponent();
            LoadGrid();
        }
        private async void LoadGrid()
        {
            List<Training> trainingList = await trainingController.GetAllTrainings();

            if (trainingList != null)
            {
                foreach (Training training in trainingList)
                {
                    if ( IDCustomer != 0 && IDCustomer != training.CustomerID )
                    {
                        continue;
                    }
                    Customer customer = await customerController.GetCustomer(training.CustomerID);

                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dgvRutinas);

                    row.Cells[0].Value = training.ID;
                    row.Cells[1].Value = training.Description;
                    row.Cells[2].Value = customer.FirstName + " " + customer.LastName1 + " " + customer.LastName2;

                    dgvRutinas.Rows.Add(row);

                }
            }
            else
            {
                MessageBox.Show("No se pudo cargar las rutinas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvRutinas.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dgvRutinas.SelectedRows[0];

                    DialogResult result = MessageBox.Show($"¿Estás seguro de que deseas eliminar la rutina: \"{selectedRow.Cells[1].Value}\"?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        if (selectedRow.Cells.Count > 0)
                        {
                            // Obtener el valor de la primera celda de la fila seleccionada, que contiene el id del training
                            int idToDelete = (int)selectedRow.Cells[0].Value;

                            var deleteCompleted = await trainingController.DeleteTrainingAndTrainingLines(idToDelete);
                            if (deleteCompleted)
                            {
                                dgvRutinas.Rows.Clear();
                                LoadGrid();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo realizar la eliminación. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            recuperarRutina();
        }

        private void dgvRutinas_DoubleClick(object sender, EventArgs e)
        {
            recuperarRutina();
        }

        private void recuperarRutina()
        {
            if (dgvRutinas.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvRutinas.SelectedRows[0];

                DialogResult result = MessageBox.Show($"¿Estás seguro de que deseas cargar la rutina: \"{selectedRow.Cells[1].Value}\"?", "Confirmar recuperación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (selectedRow.Cells.Count > 0)
                    {
                        // Pasamos el id del training al forms principal
                        IDTraining = (int)selectedRow.Cells[0].Value;
                        this.Close();
                    }
                }
            }
        }
    }
}
