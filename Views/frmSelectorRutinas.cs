using RutinApp.Controllers;
using RutinApp.Models;

namespace RutinApp.Views
{
    public partial class frmSelectorRutinas : Form
    {
        private TrainingController trainingController;
        private CustomerController customerController;
        private List<Training> trainingList;
        private List<TrainingWithCustomer> combinedList = new List<TrainingWithCustomer>();
        public int IDTraining { get; set; }
        public int IDCustomer { get; set; }
        public class TrainingWithCustomer
        {
            public int TrainingID { get; set; }
            public string TrainingDescription { get; set; }
            public int CustomerID { get; set; }
            public string CustomerFullName { get; set; }
        }
        public frmSelectorRutinas()
        {
            trainingController = new TrainingController();
            customerController = new CustomerController();
            InitializeComponent();
            LoadGrid();
        }
        private async void LoadGrid()
        {
            trainingList = await trainingController.GetAllTrainings();

            if (trainingList != null)
            {
                combinedList.Clear();

                foreach (Training training in trainingList)
                {
                    Customer customer = await customerController.GetCustomer(training.CustomerID);

                    var combinedItem = new TrainingWithCustomer
                    {
                        TrainingID = training.ID,
                        TrainingDescription = training.Description,
                        CustomerID = training.CustomerID,
                        CustomerFullName = customer.FirstName + " " + customer.LastName1 + " " + customer.LastName2
                    };

                    combinedList.Add(combinedItem);
                }

                ApplyFilterAndLoadGrid();
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
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            ApplyFilterAndLoadGrid();
        }
        
        private void ApplyFilterAndLoadGrid()
        {
            dgvRutinas.Rows.Clear();

            // Filtrar la lista combinada según el texto en el TextBox
            var filterText = txtFilter.Text.ToLower();
            var filteredList = combinedList
                .Where(item => IDCustomer == 0 || item.CustomerID == IDCustomer)
                .Where(item => string.IsNullOrEmpty(filterText) || item.TrainingDescription.ToLower().Contains(filterText) || item.CustomerFullName.ToLower().Contains(filterText))
                .ToList();

            foreach (var item in filteredList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvRutinas);

                row.Cells[0].Value = item.TrainingID;
                row.Cells[1].Value = item.TrainingDescription;
                row.Cells[2].Value = item.CustomerFullName;

                dgvRutinas.Rows.Add(row);
            }
        }
    }
}
