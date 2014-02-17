using System.Collections.ObjectModel;
using Lette.ProjectEuler.WpfRunner.Utils;

namespace Lette.ProjectEuler.WpfRunner.View
{
    public interface IMainViewModel
    {
        void Initialize(IMainController controller);

        RelayCommand QuitCommand { get; }
        RelayCommand StartCommand { get; }
        RelayCommand StopCommand { get; }

        bool IsRunning { get; set; }
        bool ShouldStop { get; set; }
        bool RunParallel { get; set; }
        int AllProblemsCount { get; set; }

        ObservableCollection<ProblemViewModel> Solutions { get; set; }
        void AddSolution(ProblemViewModel problem);
    }
}