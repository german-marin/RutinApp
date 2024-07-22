using iText.Layout.Splitting;
using RutinApp.Controllers;
using RutinApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace RutinApp.Views
{
    public partial class frmAltaCliente : Form
    {
        private CustomerController customerController;
        public int IDCustomer { get; set; }
        Customer customer = new Customer();
        public frmAltaCliente()
        {
            customerController = new CustomerController();
            InitializeComponent();

        }

        private void frmAltaCliente_Load(object sender, EventArgs e)
        {
            // si el id está informado, es que vamos a editar
            if (IDCustomer != 0)
            {
                loadData();
            }
        }

        private async void loadData()
        {
            customer = await customerController.GetCustomer(IDCustomer);
            this.Text = "Modificar cliente";

            txtNombre.Text = customer.FirstName;
            txtApellido1.Text = customer.LastName1;
            txtApellido2.Text = customer.LastName2;
            dtpNacimiento.Value = customer.BirthDate ?? DateTime.Now;
            // Asignar el valor del ComboBox según el valor de género de la base de datos
            switch (customer.Gender.Trim())
            {
                case "m":
                    cmbSex.SelectedItem = "Masculino";
                    break;
                case "f":
                    cmbSex.SelectedItem = "Femenino";
                    break;
                case "o":
                    cmbSex.SelectedItem = "Otro";
                    break;
                default:
                    cmbSex.SelectedItem = "Otro";
                    break;
            }
            txtTelefono.Text = customer.PhoneNumber.ToString();
            txtEmail.Text = customer.Email;
            dtpAlta.Value = customer.RegistrationDate ?? DateTime.Now;
            if (customer.UnregistrationDate != null)
            {
                dtpBaja.Checked = true;
                dtpBaja.Value = customer.UnregistrationDate.Value;
            }
            txtNotas.Text = customer.Notes;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNombre.Text == "")
                {
                    MessageBox.Show("Es necesario indicar un nombre", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNombre.Focus();
                    return;
                }
                if (txtApellido1.Text == "")
                {
                    MessageBox.Show("Es necesario indicar primer apellido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtApellido1.Focus();
                    return;
                }
                if (txtApellido2.Text == "")
                {
                    MessageBox.Show("Es necesario indicar segundo apellido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtApellido2.Focus();
                    return;
                }
                if (cmbSex.SelectedIndex == -1)
                {
                    MessageBox.Show("Es necesario indicar el sexo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbSex.Focus();
                    return;
                }
                if (txtTelefono.Text == "")
                {
                    MessageBox.Show("Es necesario indicar un telefono de contacto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTelefono.Focus();
                    return;
                }
                //if (txtEmail.Text == "")
                //{
                //    MessageBox.Show("Es necesario indicar un email", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    txtEmail.Focus();
                //    return;
                //}

                if (IDCustomer != 0)
                {
                    customer.ID = IDCustomer;
                }
                customer.FirstName = txtNombre.Text;
                customer.LastName1 = txtApellido1.Text;
                customer.LastName2 = txtApellido2.Text;
                customer.Email = txtEmail.Text;
                customer.BirthDate = dtpNacimiento.Value;
                customer.PhoneNumber = int.Parse(txtTelefono.Text);
                switch (cmbSex.SelectedItem.ToString())
                {
                    case "Masculino":
                        customer.Gender = "m";
                        break;
                    case "Femenino":
                        customer.Gender = "f";
                        break;
                    case "Otro":
                        customer.Gender = "o";
                        break;
                    default:
                        customer.Gender = "o";
                        break;
                }
                customer.RegistrationDate = dtpAlta.Value;
                if (dtpBaja.Checked == true)
                {
                    customer.UnregistrationDate = dtpBaja.Value;
                }
                customer.Notes = txtNotas.Text;
                customer.LastUpdated = DateTime.Now;

                bool result;

                if (IDCustomer != 0)
                {
                    result = await customerController.UpdateCustomer(customer);
                }
                else
                {
                    result = await customerController.InsertCustomer(customer);
                }

                if (result)
                {
                    // todo ok                   
                    this.Close();
                }
                else
                {
                    // La inserción falló
                    if (IDCustomer != 0)
                    {
                        MessageBox.Show("Error al modificar Cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Error al insertar Cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }


            }
            catch (HttpRequestException ex)
            {
                // Manejo de excepciones específicas de la solicitud HTTP
                MessageBox.Show($"Error en la solicitud HTTP: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si el carácter es un dígito o una tecla de control
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Si no es un dígito ni una tecla de control, cancelar la entrada
                e.Handled = true;
            }
        }
    }
}

