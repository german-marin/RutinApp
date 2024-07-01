using iText.StyledXmlParser.Jsoup.Nodes;
using RutinApp.Controllers;
using RutinApp.Models;
using RutinApp.Views;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Application = System.Windows.Forms.Application;
using Image = System.Drawing.Image;

namespace RutinApp
{
    public partial class Form1 : Form
    {
        private MuscleGroupController muscleGroupController;
        private CategoryController categoryController;
        private ExerciseController exerciseController;
        private TrainingController trainingController;
        private TrainingLineController trainingLineController;
        private CustomerController customerController;
        private List<TrainingLine> trainingLines;
        private List<ExerciseToPrint> exercisesToPrint;
        private readonly string defaultText;
        private int idTrainingRecovered;
        private string selectedGrip;

        public Form1()
        {
            // Mostrar el SplashScreen
            frmLoading splashScreen = new frmLoading();
            //splashScreen.Show();
            splashScreen.ShowDialog();
            InitializeComponent();
            muscleGroupController = new MuscleGroupController();
            categoryController = new CategoryController();
            exerciseController = new ExerciseController();
            trainingController = new TrainingController();
            trainingLineController = new TrainingLineController();
            customerController = new CustomerController();
            trainingLines = new List<TrainingLine>();
            exercisesToPrint = new List<ExerciseToPrint>();
            defaultText = txtNotasGenerales.Text;
            EnsureApiAvailability();
            GetAllMuscleGroupTree();
            //splashScreen.Close();
        }
        private void cleanForm()
        {
            // Limpiar las listas y controles
            trainingLines.Clear();
            lstEjercicios.Items.Clear();
            trvGruposMusculares.Nodes.Clear();
            idTrainingRecovered = 0;
            // Restablecer otros estados
            CleanTextbox();
            disableTextbox();
            //btnLimpiar.Enabled = false;
            btnImprimir.Enabled = false;
            tsmImprimir.Enabled = false;
            btnBorrar.Enabled = false;
            btnGuardar.Enabled = false;
            btnAñadir.Enabled = false;
            btnAgarre.Enabled = false;
            tsmRecuperar.Enabled = true;
            tabControl1.SelectedTab = tabPage1;
            trvGruposMusculares.Enabled = true;
            //Limpiar imagen de ejercicio
            pbExercise.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Resources", "rutinApp.jpg"));
            // Volver a cargar datos iniciales
            GetAllMuscleGroupTree();
            ChangeMuscleGroupImage(null);
            ChangeExcerciseGrip(null);
        }
        // Clase para almacenar información adicional en la lista
        public class ListItem
        {
            public string Text { get; set; }
            public int ExerciseID { get; set; }
            public int LineID { get; set; }
            public string Image { get; set; }
            public string MuscleGroup { get; set; }
            public string Grip { get; set; }

            public ListItem(string text, int excerciseID, int lineID, string image, string muscleGroup, string grip)
            {
                Text = text;
                ExerciseID = excerciseID;
                LineID = lineID;
                Image = image;
                MuscleGroup = muscleGroup;
                Grip = grip;
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
                    //treeNode.Tag = muscleGroup.ID;
                    treeNode.Tag = new Tuple<int, string, string>(muscleGroup.ID, muscleGroup.ImageFront, muscleGroup.ImageRear);

                    // Agrega un nodo Dummy para permitir la expansión
                    treeNode.Nodes.Add(new TreeNode("Dummy") { Tag = "Dummy" });

                    // Agrega el nodo actual al TreeView
                    trvGruposMusculares.Nodes.Add(treeNode);
                }
                //Limpiar imagen de ejercicio
                pbExercise.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Resources", "rutinApp.jpg"));
                ChangeExcerciseGrip(null);
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
                    var tagData = (Tuple<int, string, string>)selectedNode.Tag;
                    int idMuscleGroup = tagData.Item1; // Get the muscle group id from the Tuple                                       
                    //int idMuscleGroup = (int)selectedNode.Tag;

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
                ChangeMuscleGroupImage(selectedNode);
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
                    if (exerciseList != null)
                    {
                        // Agrega los nodos hijos al TreeNode
                        foreach (Exercise exercise in exerciseList)
                        {
                            //Solo cargamos los ejercicios activos
                            if (exercise.Active == true)
                            {
                                TreeNode newNode = new TreeNode(exercise.Description);
                                // Guarda la categoría asociada al nodo         
                                newNode.Tag = new Tuple<int, string>(exercise.ID, exercise.Image);
                                selectedNode.Nodes.Add(newNode);
                            }
                        }
                    }
                    // Expande el nodo padre para mostrar los nuevos hijos
                    selectedNode.Expand();
                }
                ChangeMuscleGroupImage(selectedNode.Parent);
            }
        }

        private void trvGruposMusculares_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // Verifica si el evento de doble clic ocurrió en un nodo hijo del hijo
            if (e.Node.Level == 2)
            {


                // Acciones que deseas realizar al hacer doble clic en un nodo hijo del hijo
                var tagData = (Tuple<int, string>)e.Node.Tag;

                //comprobamos si el ejercicio ya está en la lista
                TrainingLine trainingLineToRemove = trainingLines.FirstOrDefault(tl => tl.ExerciseID == (int)tagData.Item1);
                if (trainingLineToRemove != null)
                {
                    MessageBox.Show("Ejercicio ya añadido a la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                ListItem newItem = new ListItem(e.Node.Text, (int)tagData.Item1, 0, tagData.Item2, e.Node.Parent.Parent.Text, null);

                // Agregar elementos al ListBox con Tags asociados
                lstEjercicios.Items.Add(newItem);
                // Selecciona el nuevo elemento recién agregado
                lstEjercicios.SelectedItem = newItem;

                //Preparamos el forms
                lstEjercicios.Enabled = false;
                trvGruposMusculares.Enabled = false;
                CleanExerciseTextbox();
                enableTextbox();
                btnGuardar.Enabled = false;
                tsmRecuperar.Enabled = false;
                lstEjercicios.Enabled = false;
                btnAñadir.Enabled = true;
                btnAgarre.Enabled = true;
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
            int exerciseIdListValue = ((ListItem)lstEjercicios.SelectedItem).ExerciseID;

            if (txtSeries.Text == "")
            {
                MessageBox.Show("El campo Series es obligatorio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSeries.Focus();
                return;
            }
            if (txtRepes.Text == "")
            {
                MessageBox.Show("El campo Repeticiones es obligatorio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRepes.Focus();
                return;
            }

            disableTextbox();
            lstEjercicios.Enabled = true;
            btnGuardar.Enabled = true;
            tsmRecuperar.Enabled = true;
            trvGruposMusculares.Enabled = true;
            btnAñadir.Enabled = false;
            btnAgarre.Enabled = false;
            btnBorrar.Enabled = false;
            btnLimpiar.Enabled = true;
            btnImprimir.Enabled = true;
            tsmImprimir.Enabled = true;
            TrainingLine line = new TrainingLine(0, exerciseIdListValue, 0,
                                                    txtSeries.Text.Trim(),
                                                    txtRepes.Text.Trim(),
                                                    txtPeso.Text.Trim(),
                                                    txtRecuperacion.Text.Trim(),
                                                    txtOtros.Text.Trim(),
                                                    txtNotas.Text.Trim(),
                                                    selectedGrip);
            trainingLines.Add(line);
            lstEjercicios.SelectedItem = null;
            btnGuardar.Enabled = true;
            CleanExerciseTextbox();
            pbExercise.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Resources", "rutinApp.jpg"));
            pbAgarre.Image = null;
            selectedGrip = "";
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
            txtCliente.Tag = "";
            txtdias.Text = "";
            dtpFechaFin.Value = DateTime.Now;
            dtpFechaInicio.Value = DateTime.Now;
            txtNotasGenerales.Text = defaultText;
        }
        private void CleanExerciseTextbox()
        {
            txtSeries.Text = "";
            txtRepes.Text = "";
            txtPeso.Text = "";
            txtRecuperacion.Text = "";
            txtOtros.Text = "";
            txtNotas.Text = "";
            ChangeExcerciseGrip(null);
        }
        private void lstEjercicios_Click(object sender, EventArgs e)
        {
            //if (lstEjercicios.SelectedItem != null)
            //{
            //    int index = lstEjercicios.SelectedIndex;
            //    ChangeExcerciseImage(((ListItem)lstEjercicios.SelectedItem).Image);
            //    CleanExerciseTextbox();
            //    fillTextBox(trainingLines[index]);
            //    btnBorrar.Enabled = true;
            //}
        }
        private void lstEjercicios_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.lstEjercicios.SelectedItem == null)
            {
                return;
            }
            int index = lstEjercicios.SelectedIndex;
            ChangeExcerciseImage(((ListItem)lstEjercicios.SelectedItem).Image);
            CleanExerciseTextbox();
            fillTextBox(trainingLines[index]);
            btnBorrar.Enabled = true;
            // Iniciar el arrastre y soltar con el ítem seleccionado
            this.lstEjercicios.DoDragDrop(this.lstEjercicios.SelectedItem, DragDropEffects.Move);
        }
        private void fillTextBox(TrainingLine line)
        {
            txtSeries.Text = line.Sets ?? "";
            txtRepes.Text = line.Repetitions;
            txtPeso.Text = line.Weight;
            txtRecuperacion.Text = line.Recovery;
            txtOtros.Text = line.Others;
            txtNotas.Text = line.Notes;
            ChangeExcerciseGrip(line.Grip);
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (lstEjercicios.SelectedItem != null)
            {
                disableTextbox();
                lstEjercicios.Enabled = true;
                btnGuardar.Enabled = true;
                tsmRecuperar.Enabled = true;
                trvGruposMusculares.Enabled = true;
                btnAñadir.Enabled = false;
                btnAgarre.Enabled = false;
                btnBorrar.Enabled = false;
                // Obtén el objeto ListItem seleccionado
                ListItem itemToRemove = (ListItem)lstEjercicios.SelectedItem;

                // Elimina el elemento del ListBox
                lstEjercicios.Items.Remove(itemToRemove);
                // Obtén el objeto TrainingLine asociado al ListItem
                TrainingLine trainingLineToRemove = trainingLines.FirstOrDefault(tl => tl.ExerciseID == itemToRemove.ExerciseID);
                // Elimina el objeto de la lista de objetos
                if (trainingLineToRemove != null)
                {
                    trainingLines.Remove(trainingLineToRemove);
                }
                //deseleccionamos el objeto
                lstEjercicios.SelectedItem = null;
                CleanExerciseTextbox();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // Verificar el borrado
            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas limpiar esta rutina?", "Confirmar limpiado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                cleanForm();
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar la inserción
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas guardar esta rutina?", "Confirmar guardado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (txtDescripcion.Text == "")
                    {
                        MessageBox.Show("Es necesario indicar un título a la rutina", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    if (trainingLines.Count == 0)
                    {
                        MessageBox.Show("Es necesario añadir al menos un ejercicio a la rutina", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tabControl1.SelectedTab = tabPage1;
                        return;
                    }
                    if (dtpFechaFin.Value < dtpFechaInicio.Value)
                    {
                        MessageBox.Show("La fecha de fin no puede ser anterior a la fecha de inicio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tabControl1.SelectedTab = tabPage2;
                        dtpFechaFin.Focus();
                        return;
                    }

                    if (idTrainingRecovered != 0)
                    {
                        var deleteCompleted = await trainingController.DeleteTrainingAndTrainingLines(idTrainingRecovered);
                        if (deleteCompleted)
                        {
                            //borramos el id de las lineas recuperadas por si se reordenan
                            foreach (var trainingLine in trainingLines)
                            {
                                trainingLine.ID = 0;
                            }
                            SaveTraining();
                        }
                    }
                    else
                    {
                        SaveTraining();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo realizar el guardado. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<int> InsertTraining(Training training)
        {
            try
            {
                // Crea una instancia de TrainingController
                TrainingController trainingController = new TrainingController();

                // Llama al método InsertTraining que devuelve el último ID insertado
                int lastInsertID = await trainingController.InsertTraining(training);

                if (lastInsertID != 0)
                {
                    // Si la inserción fue exitosa, actualiza el ID local
                    training.ID = lastInsertID;
                    return lastInsertID;
                }
                else
                {
                    // La inserción falló
                    MessageBox.Show("Error al insertar Training.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }

            }
            catch (HttpRequestException ex)
            {
                // Manejo de excepciones específicas de la solicitud HTTP
                MessageBox.Show($"Error en la solicitud HTTP: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        public async Task<bool> InsertTrainingLine(TrainingLine trainingLine)
        {
            try
            {
                bool insertionResult = await trainingLineController.InsertTrainingLine(trainingLine);

                if (insertionResult)
                {
                    // todo ok                   
                    return true;
                }
                else
                {
                    // La inserción falló
                    MessageBox.Show("Error al insertar TrainingLine.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (HttpRequestException ex)
            {
                // Manejo de excepciones específicas de la solicitud HTTP
                MessageBox.Show($"Error en la solicitud HTTP: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
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
                int idClient = int.Parse(txtCliente.Tag.ToString());
                string notes = txtNotasGenerales.Text;
                string days = txtdias.Text;

                // Crea una instancia de Training
                Training newTraining = new Training(0, description, startDate, endDate, idClient, notes, days);

                // Llama al método InsertTraining que devuelve a su vez el ID del entrenamiento insertado
                int lastTrainingID = await InsertTraining(newTraining);

                if (lastTrainingID != -1)
                {
                    // Inserta las líneas de entrenamiento
                    foreach (TrainingLine line in trainingLines)
                    {
                        // Asigna el ID del entrenamiento recién insertado a cada línea
                        line.TrainingID = lastTrainingID;

                        // Realiza la inserción de la línea
                        bool lineSuccess = await InsertTrainingLine(line);

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

        private void recuperarRutinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario secundario
            frmSelectorRutinas popupForm = new frmSelectorRutinas();

            if (txtCliente.Tag == "" || txtCliente.Tag is null)
            {
                popupForm.IDCustomer = 0;
            }
            else
            {
                popupForm.IDCustomer = int.Parse(txtCliente.Tag.ToString());
            }
            // Mostrar el formulario secundario como un cuadro de diálogo modal
            popupForm.ShowDialog();
            //Asignamos el valor recuperado del id del training a la variable global
            idTrainingRecovered = popupForm.IDTraining;

            if (popupForm.IDTraining != 0)
            {
                cleanForm();
                idTrainingRecovered = popupForm.IDTraining;
                RecoverTraining(idTrainingRecovered);
            }
        }

        private async void RecoverTraining(int recoveredID)
        {
            List<TrainingLine> trainingLineList = await trainingLineController.GetTrainingLinesOfTraining(recoveredID);

            if (trainingLineList != null)
            {
                //Recuperamos y cargamos en el form los datos de la rutina devuelta
                Training training = await trainingController.GetTraining(recoveredID);
                Customer customer = await customerController.GetCustomer(training.CustomerID);

                txtDescripcion.Text = training.Description;
                dtpFechaInicio.Value = training.StartDate;
                dtpFechaFin.Value = training.EndDate;
                txtdias.Text = training.Days.ToString();
                txtCliente.Tag = training.CustomerID.ToString();
                txtCliente.Text = customer.FirstName + " " + customer.LastName1 + " " + customer.LastName2;
                txtNotasGenerales.Text = training.Notes;
                btnLimpiar.Enabled = true;
                btnImprimir.Enabled = true;
                tsmImprimir.Enabled = true;

                //cargamos la lista recuperada en la lista de ejercicios del form
                trainingLines = trainingLineList;

                foreach (TrainingLine trainingLine in trainingLineList)
                {
                    //recuperamos la descripción del ejercicio
                    Exercise exercise = await exerciseController.GetExercise(trainingLine.ExerciseID);

                    Category category = await categoryController.GetCategory(exercise.CategoryID);
                    MuscleGroup muscleGroup = await muscleGroupController.GetMuscleGroup(category.MuscleGroupID);

                    ListItem newItem = new ListItem(exercise.Description, exercise.ID, trainingLine.ID, exercise.Image, muscleGroup.Description, trainingLine.Grip);
                    // Agregar elementos al ListBox con Tags asociados
                    lstEjercicios.Items.Add(newItem);
                }
            }
            else
            {
                MessageBox.Show("No se pudo cargar las rutinas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void trvGruposMusculares_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 0)
            {
                ChangeMuscleGroupImage(e.Node);
            }
            else if (e.Node.Level == 1) // Este es un nodo hijo (nivel 1)
            {
                ChangeMuscleGroupImage(e.Node.Parent);
            }
            else if (e.Node.Level == 2) // Este es un nodo hijo del hijo (nivel 2)
            {
                ChangeMuscleGroupImage(e.Node.Parent.Parent);

                var tagData = (Tuple<int, string>)e.Node.Tag;
                string image = tagData.Item2; // Get the Image from the Tuple  
                ChangeExcerciseImage(image);
                ChangeExcerciseGrip(null);
            }
        }

        private void ChangeMuscleGroupImage(TreeNode node)
        {
            try
            {
                if (node != null)
                {
                    var tagData = (Tuple<int, string, string>)node.Tag;
                    string imageFront = tagData.Item2; // Get the ImageFront from the Tuple
                    string imageRear = tagData.Item3;

                    pbFront.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Resources", imageFront));
                    pbBack.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Resources", imageRear));
                }
                else
                {
                    // Set the default image here
                    pbFront.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Resources", "MA.jpg"));
                    pbBack.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Resources", "MP.jpg"));
                }
            }
            catch (FileNotFoundException)
            {
                // Set the default image here
                pbFront.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Resources", "MA.jpg"));
                pbBack.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Resources", "MP.jpg"));
            }

        }

        private void ChangeExcerciseImage(string image)
        {
            try
            {
                pbExercise.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Resources/exercisePictures", image + ".jpg"));
            }
            catch (FileNotFoundException)
            {
                // Set the default image here
                pbExercise.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Resources/exercisePictures", "noPicFound.jpg"));
            }
        }
        private void ChangeExcerciseGrip(string image)
        {
            try
            {
                pbAgarre.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Resources/Grips", image + ".jpg"));
            }
            catch (FileNotFoundException)
            {
                pbAgarre.Image = null;
            }
        }
        private async Task<bool> VerifyApiAvailability()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // URL con la dirección del punto de entrada de salud
                    string apiUrl = $"{ApiConfiguration.ApiBaseUrl}/health";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        return true; // La API está en línea
                    }
                    else
                    {
                        MessageBox.Show($"Error al acceder a la API. Código de estado: {response.StatusCode}",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false; // La API no está disponible
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al verificar la API: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // Error en la verificación
            }
        }

        private async void EnsureApiAvailability()
        {
            bool apiAvailable = await VerifyApiAvailability();

            if (!apiAvailable)
            {
                // Cierra la aplicación si la API no está disponible
                Application.Exit();
            }
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            imprimirRutina();
        }

        private void imprimirRutina()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            // Configurar el SaveFileDialog
            saveFileDialog1.Filter = "Archivos PDF (*.pdf)|*.pdf";
            saveFileDialog1.Title = "Guardar archivo PDF";
            saveFileDialog1.FileName = "rutina.pdf"; // Nombre predeterminado del archivo
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string pdfPath = saveFileDialog1.FileName;

                exercisesToPrint.Clear();
                for (int i = 0; i < trainingLines.Count; i++)
                {
                    var trainingLine = trainingLines[i];

                    // Crea un nuevo ExerciseToPrint con los datos necesarios
                    ExerciseToPrint exerciseToPrint = new ExerciseToPrint(
                        (i + 1).ToString() + "-" + ((ListItem)lstEjercicios.Items[i]).MuscleGroup + "\n" + ((ListItem)lstEjercicios.Items[i]).Text,
                        trainingLine.Sets,
                        trainingLine.Repetitions,
                        trainingLine.Weight,
                        trainingLine.Recovery,
                        trainingLine.Others,
                        trainingLine.Notes,
                        string.IsNullOrEmpty(((ListItem)lstEjercicios.Items[i]).Image) ? "noPicFound" : ((ListItem)lstEjercicios.Items[i]).Image,
                        dtpFechaInicio.Value.ToString("dd/MM/yyyy"),
                        dtpFechaFin.Value.ToString("dd/MM/yyyy"),
                        txtCliente.Text,
                        int.Parse(txtCliente.Tag.ToString()),
                        txtNotasGenerales.Text,
                        txtdias.Text,
                        trainingLine.Grip
                    );

                    // Añade el ExerciseToPrint a la lista
                    exercisesToPrint.Add(exerciseToPrint);
                }
                // Generar el PDF en la ubicación elegida por el usuario
                GenerarPDF.CrearPDF(exercisesToPrint, pdfPath);
            }
        }
        private void btnClientes_Click(object sender, EventArgs e)
        {
            cargarCliente();
        }
        private void cargarCliente()
        {
            // Crear una instancia del formulario secundario
            frmSelectorClientes popupForm = new frmSelectorClientes();

            // Mostrar el formulario secundario como un cuadro de diálogo modal
            popupForm.ShowDialog();
            if (popupForm.iDCustomer != 0)
            {
                //Asignamos el valor recuperado del id del training a la variable global
                txtCliente.Tag = popupForm.iDCustomer;
                txtCliente.Text = popupForm.customerName.ToString();
            }
        }

        private void txtdias_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si el carácter es un dígito o una tecla de control
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Si no es un dígito ni una tecla de control, cancelar la entrada
                e.Handled = true;
            }
        }

        private void lstEjercicios_DragOver(object sender, DragEventArgs e)
        {
            // Permitir el efecto de mover
            e.Effect = DragDropEffects.Move;
        }

        private void lstEjercicios_DragDrop(object sender, DragEventArgs e)
        {
            // Obtener el índice del ítem de destino
            Point point = this.lstEjercicios.PointToClient(new Point(e.X, e.Y));
            int index = this.lstEjercicios.IndexFromPoint(point);

            // Si el índice es -1, el ítem se suelta fuera del ListBox
            if (index < 0)
            {
                index = this.lstEjercicios.Items.Count - 1;
            }

            // Obtener el ítem arrastrado como ListItem
            ListItem data = e.Data.GetData(typeof(ListItem)) as ListItem;

            // Eliminar el ítem arrastrado de su posición original y añadirlo en la nueva posición
            this.lstEjercicios.Items.Remove(data);

            // Obtén el objeto TrainingLine asociado al ListItem
            TrainingLine trainingLineToRemove = trainingLines.FirstOrDefault(tl => tl.ExerciseID == data.ExerciseID);

            // Elimina el objeto de la lista de objetos
            if (trainingLineToRemove != null)
            {
                trainingLines.Remove(trainingLineToRemove);
            }
            // Lo añadimos a su nueva posicion
            trainingLines.Insert(index, trainingLineToRemove);
            this.lstEjercicios.Items.Insert(index, data);

            btnGuardar.Enabled = true;
        }

        private void imprimirRutinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imprimirRutina();
        }

        private void tsmAltaCliente_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario secundario
            frmAltaCliente popupForm = new frmAltaCliente();

            // Mostrar el formulario secundario como un cuadro de diálogo modal
            popupForm.ShowDialog();
        }

        private void mantenimientoDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cargarCliente();
        }

        private void mantenimientoDeEjerciciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario secundario
            frmMantenimientoEjercicios popupForm = new frmMantenimientoEjercicios();

            // Mostrar el formulario secundario como un cuadro de diálogo modal
            popupForm.ShowDialog();
            trvGruposMusculares.Nodes.Clear();
            GetAllMuscleGroupTree();
            ChangeMuscleGroupImage(null);
        }

        private void btnAgarre_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario secundario
            frmSelectorAgarres popupForm = new frmSelectorAgarres();

            // Mostrar el formulario secundario como un cuadro de diálogo modal
            popupForm.ShowDialog();
            if (popupForm.pbSelected != null)
            {
                selectedGrip = Path.GetFileNameWithoutExtension(popupForm.pbSelected.ImageLocation);

                if (selectedGrip == "00" || selectedGrip == "AA") //Ningun agarre
                {
                    selectedGrip = "";
                    pbAgarre.ImageLocation = null;
                }
                else
                {
                    pbAgarre.ImageLocation = popupForm.pbSelected.ImageLocation;
                }
            }
        }

    }
}
