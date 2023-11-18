using RutinApp.Controllers;
using RutinApp.Models;

namespace RutinApp
{
    public partial class Form1 : Form
    {
        private CitiesController citiesController;
        private Cities cities;
        public Form1()
        {
            InitializeComponent();
            citiesController = new CitiesController();  
            cities = new Cities();
        }
        private async void GetCities()
        {
            List<City> cities = await citiesController.GetCities();
            //cities= await citiesController.GetCities();

            if (cities != null) 
            {
                //foreach (var city in  cities?.results!)
                //{
                //    DataGridViewRow row = new DataGridViewRow();
                //    row.CreateCells(dgvCities);

                //    row.Cells[0].Value = city.Name;
                //    row.Cells[1].Value = city.CountryCode;
                //    row.Cells[2].Value = city.District;
                //    row.Cells[3].Value = city.Population;

                //    dgvCities.Rows.Add(row);
                //}
                //dgvCities.DataSource = cities;
                
                foreach (City city in cities)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dgvCities);

                    row.Cells[0].Value = city.Name;
                    row.Cells[1].Value = city.CountryCode;
                    row.Cells[2].Value = city.District;
                    row.Cells[3].Value = city.Population;

                    dgvCities.Rows.Add(row);

                }
            }
            else
            {
                MessageBox.Show("No se pudo obtener la petición.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnObtener_Click(object sender, EventArgs e)
        {
            GetCities();
        }
    }
}
