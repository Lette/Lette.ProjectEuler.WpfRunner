using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Threading;
using Lette.ProjectEuler.WpfRunner.Utils;

namespace Lette.ProjectEuler.WpfRunner.View
{
    public class MainViewModel : INotifyPropertyChanged, IMainViewModel
    {
        private IMainController _controller;
        private readonly Dispatcher _dispatcher;

        private bool _isRunning;
        private bool _shouldStop;
        private bool _runParallel = true;
        private int _allProblemsCount;
        private ObservableCollection<ProblemViewModel> _solutions;

        public MainViewModel()
        {
            QuitCommand = new RelayCommand(_ => _controller.Quit(), _ => _controller.CanQuit());
            StartCommand = new RelayCommand(_ => _controller.Start(), _ => _controller.CanStart());
            StopCommand = new RelayCommand(_ => _controller.Stop(), _ => _controller.CanStop());
            OpenWebLinkCommand = new RelayCommand(x => _controller.OpenWebLink((Uri)x));

            Solutions = new ObservableCollection<ProblemViewModel>();

            _dispatcher = Dispatcher.CurrentDispatcher;
        }

        public void Initialize(IMainController controller)
        {
            _controller = controller;
        }

        public RelayCommand QuitCommand { get; private set; }
        public RelayCommand StartCommand { get; private set; }
        public RelayCommand StopCommand { get; private set; }
        public RelayCommand OpenWebLinkCommand { get; private set; }

        public bool IsRunning
        {
            get { return _isRunning; }
            set
            {
                _isRunning = value;
                OnPropertyChanged();
                CommandManager.InvalidateRequerySuggested();
            }
        }

        public bool ShouldStop
        {
            get { return _shouldStop; }
            set
            {
                _shouldStop = value;
                OnPropertyChanged();
                CommandManager.InvalidateRequerySuggested();
            }
        }

        public bool RunParallel
        {
            get { return _runParallel; }
            set
            {
                _runParallel = value;
                OnPropertyChanged();
            }
        }

        public int AllProblemsCount
        {
            get { return _allProblemsCount; }
            set
            {
                _allProblemsCount = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ProblemViewModel> Solutions
        {
            get { return _solutions; }
            set
            {
                _solutions = value;
                OnPropertyChanged();
            }
        }

        public void AddSolution(ProblemViewModel problem)
        {
            _dispatcher.Invoke(() => _solutions.Add(problem));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}