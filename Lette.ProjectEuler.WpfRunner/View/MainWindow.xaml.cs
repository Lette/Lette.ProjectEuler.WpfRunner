namespace Lette.ProjectEuler.WpfRunner.View
{
    public partial class MainWindow : IMainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public IMainViewModel ViewModel
        {
            get { return (MainViewModel)DataContext; }
            set { DataContext = value; }
        }
    }
}