using RutinApp.Controllers;
using RutinApp.Models;
using System.Drawing.Text;
using System.Xml.Linq;

namespace RutinApp
{
    public partial class Form1 : Form
    {
        private MuscleGroupController muscleGroupController;
        private CategoryController categoryController;
        private ExerciseController exerciseController;
        public Form1()
        {
            InitializeComponent();
            muscleGroupController = new MuscleGroupController();
            categoryController = new CategoryController();
            exerciseController = new ExerciseController();
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
            GetAllMuscleGroupTree();
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

                    treeNode.Nodes.Add(new TreeNode("Dummy") { Tag = "Dummy" });

                    // Agrega el nodo actual al TreeView
                    trvGruposMusculares.Nodes.Add(treeNode);

                    //// Si el nodo tiene hijos, llama recursivamente al método para agregar los hijos
                    //if (node.Children != null && node.Children.Any())
                    //{
                    //    RellenarTreeView(node.Children, treeNode.Nodes);
                    //}

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

                    // Obtén los hijos desde la base de datos             
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
    }
}
