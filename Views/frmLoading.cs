
namespace RutinApp.Views
{
    public partial class frmLoading : Form
    {
        private System.Windows.Forms.Timer timer;
        public frmLoading()
        {
            InitializeComponent();
            // Crear una instancia del formulario secundario
            frmLogin popupForm = new frmLogin();

            // Mostrar el formulario secundario como un cuadro de diálogo modal
            //popupForm.ShowDialog();
            // Configura el temporizador para cerrar el SplashScreen después de 3 segundos
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 3000; // 3000 milisegundos = 3 segundos
            timer.Tick += TimerTick;
            //timer.Tick += (sender, args) => Close();
            //timer.Tick += (sender, args) => popupForm.ShowDialog();           
            timer.Start();


        }
        private void TimerTick(object sender, EventArgs e)
        {
            timer.Stop();
            loadLogin();
        }
        private void loadLogin()
        {
            frmLogin popupForm = new frmLogin();
            popupForm.ShowDialog();
            Close();

        }
    
    }
}
