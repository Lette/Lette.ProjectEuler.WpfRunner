namespace Lette.ProjectEuler.WpfRunner.View
{
    public interface IMainWindow
    {
        IMainViewModel ViewModel { get; set; }
        void Show();
        void Close();
    }
}