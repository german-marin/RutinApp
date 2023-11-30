using RutinApp.Controllers;
using RutinApp.Models;
using System.Drawing.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace RutinApp
{
    public partial class Form1 : Form
    {
        private MuscleGroupController muscleGroupController;
        private CategoryController categoryController;
        private ExerciseController exerciseController;
        private List<TrainingLine> trainingLines;
        private string defaultText;

        public Form1()
        {
            InitializeComponent();
            muscleGroupController = new MuscleGroupController();
            categoryController = new CategoryController();
            exerciseController = new ExerciseController();
            trainingLines = new List<TrainingLine>();
            defaultText = txtNotasGenerales.Text;
            GetAllMuscleGroupTree();
        }
        private void cleanForm()
        {
            // Limpiar las listas y controles
            trainingLines.Clear();
            lstEjercicios.Items.Clear();
            trvGruposMusculares.Nodes.Clear();

            // Restablecer otros estados
            CleanTextbox();
            disableTextbox();
            btnLimpiar.Enabled = false;
            btnBorrar.Enabled = false;
            btnGuardar.Enabled = false;
            tabControl1.SelectedTab = tabPage1;

            // Volver a cargar datos iniciales
            GetAllMuscleGroupTree();
        }
        // Clase para almacenar información adicional en la lista
        public class ListItem
        {
            public string Text { get; set; }
            public int Tag { get; set; }

            public ListItem(string text, int tag)
            {
                Text = text;
                Tag = tag;
            }

            public override string ToString()
            {
                return Text; // Esto determina qué se mostrará en el ListBox
            }
        }
        private async void GetAllMuscleGroupTree()
        {
            List<MuscleGroup> muscleGroupList = await muscleGroupController.GetAllMuscleGroup();

            if (muscleGroupList != null)
            {
                foreach (MuscleGroup muscleGroup in muscleGroupList)
                {
                    // Agrega el nodo actual al TreeView              
                    TreeNode treeNode = new TreeNode(muscleGroup.Description);

                    // Guarda la categoría asociada al nodo
                    treeNode.Tag = muscleGroup.ID;
                    // Agrega un nodo Dummy para permitir la expansión
                    treeNode.Nodes.Add(new TreeNode("Dummy") { Tag = "Dummy" });

                    // Agrega el nodo actual al TreeView
                    trvGruposMusculares.Nodes.Add(treeNode);
                }
            }
            else
            {
                MessageBox.Show("No se pudo obtener la petición.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void trvGruposMusculares_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode selectedNode = e.Node;

            if (selectedNode.Level == 0) // Este es un nodo padre (nivel 0)
            {
                // Verifica si ya se cargaron los nodos hijos
                if (selectedNode.Nodes.Count == 1 && selectedNode.Nodes[0].Text == "Dummy")
                {
                    // Elimina el nodo Dummy
                    selectedNode.Nodes.Clear();

                    // Obtén el grupo muscular asociada al nodo padre
                    int idMuscleGroup = (int)selectedNode.Tag;

                    // Obtén los hijos desde la base de datos             
                    List<Category> categoryList = await categoryController.GetMuscleGroupCategories(idMuscleGroup);

                    // Agrega los nodos hijos al TreeNode
                    foreach (Category category in categoryList)
                    {
                        TreeNode newNode = new TreeNode(category.Description);
                        newNode.Tag = category.ID;  // Guarda la categoría asociada al nodo
                        newNode.Nodes.Add("Dummy");  // Agrega un nodo Dummy para permitir la expansión
                        selectedNode.Nodes.Add(newNode);
                    }
                    // Expande el nodo padre para mostrar los nuevos hijos
                    selectedNode.Expand();
                }
            }
            else if (selectedNode.Level == 1) // Este es un nodo hijo (nivel 1)
            {
                // Verifica si ya se cargaron los nodos hijos
                if (selectedNode.Nodes.Count == 1 && selectedNode.Nodes[0].Text == "Dummy")
                {
                    // Elimina el nodo Dummy
                    selectedNode.Nodes.Clear();

                    // Obtén la categoría asociada al nodo padre
                    int idCategory = (int)selectedNode.Tag;

                    // Obtén los hijos desde la API            
                    List<Exercise> exerciseList = await exerciseController.GetCategoryExercises(idCategory);

                    // Agrega los nodos hijos al TreeNode
                    foreach (Exercise exercise in exerciseList)
                    {
                        TreeNode newNode = new TreeNode(exercise.Description);
                        newNode.Tag = exercise.ID;  // Guarda la categoría asociada al nodo                        
                        selectedNode.Nodes.Add(newNode);
                    }
                    // Expande el nodo padre para mostrar los nuevos hijos
                    selectedNode.Expand();
                }
            }
        }

        private void trvGruposMusculares_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // Verifica si el evento de doble clic ocurrió en un nodo hijo del hijo
            if (e.Node.Level == 2)
            {
                // Acciones que deseas realizar al hacer doble clic en un nodo hijo del hijo
                ListItem newItem = new ListItem(e.Node.Text, (int)e.Node.Tag);
                // Agregar elementos al ListBox con Tags asociados
                lstEjercicios.Items.Add(newItem);
                // Selecciona el nuevo elemento recién agregado
                lstEjercicios.SelectedItem = newItem;

                //Preparamos el forms
                lstEjercicios.Enabled = false;
                CleanTextbox();
                enableTextbox();
                btnGuardar.Enabled = false;
                btnRecuperar.Enabled = false;
                lstEjercicios.Enabled = false;
                btnAñadir.Enabled = true;
                btnBorrar.Enabled = false;
            }
        }

        private void disableTextbox()
        {
            txtNotas.Enabled = false;
            txtOtros.Enabled = false;
            txtPeso.Enabled = false;
            txtRecuperacion.Enabled = false;
            txtRepes.Enabled = false;
            txtSeries.Enabled = false;
        }
        private void enableTextbox()
        {
            txtNotas.Enabled = true;
            txtOtros.Enabled = true;
            txtPeso.Enabled = true;
            txtRecuperacion.Enabled = true;
            txtRepes.Enabled = true;
            txtSeries.Enabled = true;
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            int tagListValue = ((ListItem)lstEjercicios.SelectedItem).Tag;

            disableTextbox();
            lstEjercicios.Enabled = true;
            btnGuardar.Enabled = true;
            btnRecuperar.Enabled = true;
            lstEjercicios.Enabled = true;
            btnAñadir.Enabled = false;
            btnBorrar.Enabled = false;
            btnLimpiar.Enabled = true;

            TrainingLine line = new TrainingLine(0, tagListValue, 0,
                                                    txtSeries.Text.Trim(),
                                                    txtRepes.Text.Trim(),
                                                    txtPeso.Text.Trim(),
                                                    txtRecuperacion.Text.Trim(),
                                                    txtOtros.Text.Trim(),
                                                    txtNotas.Text.Trim());
            trainingLines.Add(line);
            lstEjercicios.SelectedItem = null;
            btnGuardar.Enabled = true;
            CleanTextbox();
        }
        private void CleanTextbox()
        {
            txtSeries.Text = "";
            txtRepes.Text = "";
            txtPeso.Text = "";
            txtRecuperacion.Text = "";
            txtOtros.Text = "";
            txtNotas.Text = "";
            txtDescripcion.Text = "";
            txtCliente.Text = "";
            dtpFechaFin.Value = DateTime.Now;
            dtpFechaInicio.Value = DateTime.Now;
            txtNotasGenerales.Text = defaultText;
        }

        private void lstEjercicios_Click(object sender, EventArgs e)
        {
            if (lstEjercicios.SelectedItem != null)
            {
                int index = lstEjercicios.SelectedIndex;

                CleanTextbox();
                fillTextBox(trainingLines[index]);
                btnBorrar.Enabled = true;
            }
        }
        private void fillTextBox(TrainingLine line)
        {
            txtSeries.Text = line.Series;
            txtRepes.Text = line.Repetition;
            txtPeso.Text = line.Weight;
            txtRecuperacion.Text = line.Recovery;
            txtOtros.Text = line.Others;
            txtNotas.Text = line.Notes;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (lstEjercicios.SelectedItem != null)
            {
                disableTextbox();
                lstEjercicios.Enabled = true;
                btnGuardar.Enabled = true;
                btnRecuperar.Enabled = true;
                lstEjercicios.Enabled = true;
                btnAñadir.Enabled = false;
                btnBorrar.Enabled = false;
                // Obtén el objeto ListItem seleccionado
                ListItem itemToRemove = (ListItem)lstEjercicios.SelectedItem;

                // Elimina el elemento del ListBox
                lstEjercicios.Items.Remove(itemToRemove);
                // Obtén el objeto TrainingLine asociado al ListItem
                TrainingLine trainingLineToRemove = trainingLines.FirstOrDefault(tl => tl.IdExercise == itemToRemove.Tag);
                // Elimina el objeto de la lista de objetos
                if (trainingLineToRemove != null)
                {
                    trainingLines.Remove(trainingLineToRemove);
                }
                //deseleccionamos el objeto
                lstEjercicios.SelectedItem = null;
                CleanTextbox();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // Verificar el borrado
            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas borrar esta rutina?", "Confirmar borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                cleanForm();
            }
        }
       
        private void btnGuardar_Click(object sender, EventArgs e)
        {            
            // Verificar la inserción
            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas guardar esta rutina?", "Confirmar guardado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (txtDescripcion.Text == "")
                { 
                    MessageBox.Show("Es necesario indicar un título a la rutina","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    tabControl1.SelectedTab = tabPage2;
                    txtDescripcion.Focus();
                    return;
                }
                if (txtCliente.Text == "")
                {
                    MessageBox.Show("Es necesario indicar un cliente para la rutina", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tabControl1.SelectedTab = tabPage2;
                    txtCliente.Focus();
                    return;
                }
                SaveTraining();
            }
        }
        private async void SaveTraining()
        {
            try
            {
                // Obtén los datos necesarios para crear una nueva cabecera de la rutina                
                string description = txtDescripcion.Text;
                DateTime startDate = dtpFechaInicio.Value;
                DateTime endDate = dtpFechaFin.Value;
                int idClient = int.Parse(txtCliente.Text);
                string notes = txtNotasGenerales.Text;

                // Crea una instancia de Training
                Training newTraining = new Training(0,description, startDate, endDate, idClient, notes);

                // Llama al método InsertTraining que devuelve a su vez el ID del entrenamiento insertado
                int lastTrainingID = await newTraining.InsertTraining();

                if (lastTrainingID != -1)
                {                   
                    // Inserta las líneas de entrenamiento
                    foreach (TrainingLine line in trainingLines)
                    {
                        // Asigna el ID del entrenamiento recién insertado a cada línea
                        line.IdTraining = lastTrainingID;

                        // Realiza la inserción de la línea
                        bool lineSuccess = await line.InsertTrainingLine();

                        if (!lineSuccess)
                        {
                            // Maneja el fallo en la inserción de la línea
                            MessageBox.Show("Error al insertar línea de entrenamiento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    //todo ok
                    MessageBox.Show("Training insertado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cleanForm(); // Método para limpiar los campos después de la inserción
                }
                else
                {                    
                    MessageBox.Show("Error al recuperar el ultimo ID insertado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones generales
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
