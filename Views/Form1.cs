using RutinApp.Controllers;
using RutinApp.Models;

namespace RutinApp
{
    public partial class Form1 : Form
    {
        private MuscleGroupController muscleGroupController;
        public Form1()
        {
            InitializeComponent();
            muscleGroupController = new MuscleGroupController();
        }
        private async void GetAllMuscleGroup()
        {
            List<MuscleGroup> muscleGroupList = await muscleGroupController.GetAllMuscleGroup();

            if (muscleGroupList != null)
            {

                foreach (MuscleGroup muscleGroup in muscleGroupList)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dgvCities);

                    row.Cells[0].Value = muscleGroup.Description;
                    row.Cells[1].Value = muscleGroup.ImageFront;
                    row.Cells[2].Value = muscleGroup.ImageRear;

                    dgvCities.Rows.Add(row);

                }
            }
            else
            {
                MessageBox.Show("No se pudo obtener la petición.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnObtener_Click(object sender, EventArgs e)
        {
            GetAllMuscleGroup();
        }
    }
}
