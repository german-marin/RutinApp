using RutinApp.Controllers;
using RutinApp.Models;
using System.Drawing.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RutinApp
{
    public partial class Form1 : Form
    {
        private MuscleGroupController muscleGroupController;
        private CategoryController categoryController;
        private ExerciseController exerciseController;
        private List<TrainingLine> trainingLines;
        public Form1()
        {
            InitializeComponent();
            muscleGroupController = new MuscleGroupController();
            categoryController = new CategoryController();
            exerciseController = new ExerciseController();
            trainingLines = new List<TrainingLine>();
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
            btnBorrar.Enabled=false;

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
                //MessageBox.Show($"Doble clic en el nodo: {e.Node.Text}");
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

            TrainingLine line = new TrainingLine(0, tagListValue, 0,
                                                    txtSeries.Text.Trim(),
                                                    txtRepes.Text.Trim(),
                                                    txtPeso.Text.Trim(),
                                                    txtRecuperacion.Text.Trim(),
                                                    txtOtros.Text.Trim(),
                                                    txtNotas.Text.Trim());
            trainingLines.Add(line);
            lstEjercicios.SelectedItem = null;
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
    }
}
