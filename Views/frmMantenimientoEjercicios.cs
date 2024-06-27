using Org.BouncyCastle.Asn1.Pkcs;
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
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace RutinApp.Views
{
    public partial class frmMantenimientoEjercicios : Form
    {
        private MuscleGroupController muscleGroupController;
        private CategoryController categoryController;
        private ExerciseController exerciseController;
        private bool editando = false;
        private string selectedImageName;
        public frmMantenimientoEjercicios()
        {
            muscleGroupController = new MuscleGroupController();
            categoryController = new CategoryController();
            exerciseController = new ExerciseController();

            InitializeComponent();
        }
        public class ListItem
        {
            public string Text { get; set; }
            public int ID { get; set; }
            public string Image { get; set; }

            public bool Active { get; set; }

            public ListItem(string text, int id, string image, bool active)
            {
                Text = text;
                ID = id;
                Image = image;
                Active = active;
            }

            public override string ToString()
            {
                return Text; // Esto determina qué se mostrará en el ListBox
            }
        }

        private void frmMantenimientoEjercicios_Load(object sender, EventArgs e)
        {
            // Cargar los grupos musculares en el ComboBox
            cargarComboGruposMusculares();

            // Reactivar el evento SelectedIndexChanged
            //cmbGruposMusculares.SelectedIndexChanged += cmbGruposMusculares_SelectedIndexChanged;


        }
        private async void cargarComboGruposMusculares()
        {
            List<MuscleGroup> muscleGroupList = await muscleGroupController.GetAllMuscleGroup();

            if (muscleGroupList != null)
            {
                // Limpiar ComboBox
                cmbGruposMusculares.Items.Clear();

                // Asignar la lista como DataSource del ComboBox
                cmbGruposMusculares.DataSource = muscleGroupList;

                // Establecer qué propiedad mostrar (descripción del grupo muscular)
                cmbGruposMusculares.DisplayMember = "Description";

                // Establecer qué propiedad usar como valor seleccionado (ID del grupo muscular)
                cmbGruposMusculares.ValueMember = "ID";

                cmbGruposMusculares.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("No se pudo obtener la petición.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //activamos el evento
            cmbGruposMusculares.SelectedIndexChanged += cmbGruposMusculares_SelectedIndexChanged;
        }
        private void btnCambiar_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario secundario
            frmSelectorImagenes popupForm = new frmSelectorImagenes();

            // Mostrar el formulario secundario como un cuadro de diálogo modal
            popupForm.ShowDialog();
            if (popupForm.pbSelected != null)
            {
                pbExercise.ImageLocation = popupForm.pbSelected.ImageLocation;
                selectedImageName = Path.GetFileNameWithoutExtension(popupForm.pbSelected.ImageLocation);
            }
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen (*.jpg)|*.jpg";
            openFileDialog.Title = "Seleccionar imagen .jpg";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedImagePath = openFileDialog.FileName;


                // Obtener el nombre del archivo seleccionado
                string fileName = Path.GetFileName(selectedImagePath);

                // Definir el nuevo path en el directorio Resources/exercisePictures
                string destinationPath = Path.Combine(Application.StartupPath, "Resources/exercisePictures", fileName);


                try
                {
                    // Copiar la imagen al directorio Resources/exercisePictures
                    File.Copy(selectedImagePath, destinationPath, true);

                    MessageBox.Show("Imagen añadida con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    pbExercise.ImageLocation = destinationPath;
                    selectedImageName = Path.GetFileNameWithoutExtension(destinationPath);
                    // Aquí puedes llamar a métodos para ajustar el tamaño de la imagen si es necesario
                    // Ejemplo: ResizeAndSaveImage(destinationPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al añadir la imagen: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbGruposMusculares_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el ID del grupo muscular seleccionado
            if (cmbGruposMusculares.SelectedItem != null)
            {
                int selectedMuscleGroupId = (int)cmbGruposMusculares.SelectedValue;

                cmbCategoria.Enabled = true;
                lstEjercicios.Enabled = false;
                lstEjercicios.Items.Clear();
                pbExercise.Image = Properties.Resources.rutinApp;

                // Aquí puedes llamar a un método para cargar el segundo ComboBox
                CargarCategorias(selectedMuscleGroupId);
            }
        }

        private async void CargarCategorias(int muscleGroupId)
        {
            List<Category> categoryList = await categoryController.GetMuscleGroupCategories(muscleGroupId);
            //activamos el evento
            cmbCategoria.SelectedIndexChanged -= cmbCategoria_SelectedIndexChanged;

            // Desasignar el DataSource para poder modificar los ítems manualmente
            cmbCategoria.DataSource = null;
            // Limpiar ComboBox de categorias
            cmbCategoria.Items.Clear();

            // Asignar la lista como DataSource del ComboBox
            cmbCategoria.DataSource = categoryList;

            // Establecer qué propiedad mostrar
            cmbCategoria.DisplayMember = "Description";

            // Establecer qué propiedad usar como valor seleccionado
            cmbCategoria.ValueMember = "ID";
            cmbCategoria.SelectedIndex = -1;
            //activamos el evento
            cmbCategoria.SelectedIndexChanged += cmbCategoria_SelectedIndexChanged;
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarLista();
        }
        private void cargarLista()
        {
            int selectedCategory = (int)cmbCategoria.SelectedValue;
            lstEjercicios.Enabled = true;            
            btnNuevoEjercicio.Enabled = true;

            lstEjercicios.Items.Clear();
            cargarEjercicios(selectedCategory);
            pbExercise.Image = Properties.Resources.rutinApp;
        }

        private async void cargarEjercicios(int idCategory)
        {
            List<Exercise> exerciseList = await exerciseController.GetCategoryExercises(idCategory);
            //limpiamos la lista
            lstEjercicios.Items.Clear();
            if (exerciseList != null)
            {
                // Agrega los nodos hijos al TreeNode
                foreach (Exercise exercise in exerciseList)
                {
                    ListItem newItem = new ListItem(exercise.Description, (int)exercise.ID, exercise.Image, exercise.Active);

                    // Agregar elementos al ListBox con Tags asociados
                    lstEjercicios.Items.Add(newItem);
                }
            }
        }

        private void lstEjercicios_Click(object sender, EventArgs e)
        {
            ChangeExcerciseImage(((ListItem)lstEjercicios.SelectedItem).Image);
        }

        private void ChangeExcerciseImage(string image)
        {
            try
            {
                pbExercise.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Resources/exercisePictures", image + ".jpg"));
                selectedImageName = image;
            }
            catch (FileNotFoundException)
            {
                // Set the default image here
                pbExercise.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Resources/exercisePictures", "noPicFound.jpg"));
                selectedImageName = "noPicFound";
            }
        }

        private void lstEjercicios_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            cmbCategoria.Enabled = false;
            cmbGruposMusculares.Enabled = false;
            lstEjercicios.Visible = false;
            txtEjercicio.Visible = true;
            txtEjercicio.Text = ((ListItem)lstEjercicios.SelectedItem).Text;
            btnDelete.Visible = true;
            btnSave.Visible = true;
            btnCancelar.Visible = true;
            btnAñadir.Visible = true;
            btnCambiar.Visible = true;
            chkbActivo.Visible = true;
            chkbActivo.Checked = ((ListItem)lstEjercicios.SelectedItem).Active;
            editando = true;
            btnNuevoEjercicio.Visible = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
        private void limpiar()
        {
            cmbCategoria.Enabled = true;
            cmbGruposMusculares.Enabled = true;
            lstEjercicios.Visible = true;
            txtEjercicio.Visible = false;
            txtEjercicio.Text = "";
            btnDelete.Visible = false;
            btnSave.Visible = false;
            btnCancelar.Visible = false;
            btnAñadir.Visible = false;
            btnCambiar.Visible = false;
            chkbActivo.Visible = false;
            chkbActivo.Checked = true;
            editando = false;
            btnNuevoEjercicio.Visible = true;
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar la inserción
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas borrar este ejercicio?", "Confirmar borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    var deleteCompleted = await exerciseController.DeleteExercise(((ListItem)lstEjercicios.SelectedItem).ID);
                    limpiar();
                    cargarLista();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar el ejercicio. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (editando)
            {
                updateEjercicio();
            }
            else
            {
                insertEjercicio();
            }
        }
        private async void insertEjercicio()
        {
            try
            {
                Exercise exercise = new Exercise();
                
                exercise.CategoryID = (int)cmbCategoria.SelectedValue;
                if (txtEjercicio.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Es necesario indicar una descripción al ejercicio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEjercicio.Focus();
                    return;
                }
                exercise.Description = txtEjercicio.Text;
                exercise.Active = chkbActivo.Checked;
                exercise.Image = selectedImageName;

                var insertCompleted = await exerciseController.InsertExercise(exercise);
                if (insertCompleted)
                {
                    MessageBox.Show("Ejercicio añadido correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiar();
                    cargarLista();
                }  
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar el ejercicio. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void updateEjercicio()
        {
            try
            {
                Exercise exercise = new Exercise();

                exercise.ID = ((ListItem)lstEjercicios.SelectedItem).ID;
                exercise.CategoryID = (int)cmbCategoria.SelectedValue;
                if (txtEjercicio.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Es necesario indicar una descripción al ejercicio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEjercicio.Focus();
                    return;
                }
                exercise.Description = txtEjercicio.Text;
                exercise.Active = chkbActivo.Checked;
                exercise.Image = selectedImageName;

                var updateCompleted = await exerciseController.UpdateExercise(exercise);
                limpiar();
                cargarLista();

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar el ejercicio. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            cmbCategoria.Enabled = false;
            cmbGruposMusculares.Enabled = false;
            lstEjercicios.Visible = false;
            txtEjercicio.Visible = true;
            txtEjercicio.Text = "";
            btnDelete.Visible = true; 
            btnDelete.Enabled = false;  
            btnSave.Visible = true;
            btnCancelar.Visible = true;
            btnAñadir.Visible = true;
            btnCambiar.Visible = true;
            chkbActivo.Visible = true;
            chkbActivo.Checked = true;
            editando = false;
            btnNuevoEjercicio.Visible=false;
            txtEjercicio.Focus();
            // Set the default image here
            pbExercise.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Resources/exercisePictures", "noPicFound.jpg"));
            selectedImageName = "noPicFound";         
        }
    }
}
