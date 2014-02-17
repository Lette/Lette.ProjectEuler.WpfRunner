using System;
using System.Collections.Generic;
using Lette.ProjectEuler.Core;
using Lette.ProjectEuler.Core.Runner;
using Lette.ProjectEuler.WpfRunner.Services;

namespace Lette.ProjectEuler.WpfRunner.View
{
    public class MainController : IMainController
    {
        private readonly IMainWindow _view;
        private readonly IMainViewModel _viewModel;
        private readonly IProblemSuiteBuilder _suiteBuilder;
        private readonly ISolver _solver;
        private readonly IProcessWrapper _process;
        private readonly ISettings _settings;
        private IReadOnlyList<IProblem> _problemSuite;

        public MainController(
            IMainWindow view,
            IMainViewModel viewModel,
            IProblemSuiteBuilder suiteBuilder,
            ISolver solver,
            IProcessWrapper process,
            ISettings settings)
        {
            _view = view;
            _viewModel = viewModel;
            _suiteBuilder = suiteBuilder;
            _solver = solver;
            _process = process;
            _settings = settings;
        }

        public void Initialize()
        {
            _viewModel.Initialize(this);
            _view.ViewModel = _viewModel;
            _view.Show();

            _problemSuite = _suiteBuilder.CreateFromAssembly(_settings.SolutionsAssembly);

            _viewModel.AllProblemsCount = _problemSuite.Count;

            Start();
        }

        public void Quit()
        {
            _view.Close();
        }

        public bool CanQuit()
        {
            return !_viewModel.IsRunning;
        }

        public bool CanStart()
        {
            return _viewModel != null && !_viewModel.IsRunning;
        }

        public void Stop()
        {
            _viewModel.ShouldStop = true;
            _solver.Cancel();
        }

        public bool CanStop()
        {
            return _viewModel.IsRunning && !_viewModel.ShouldStop;
        }

        public async void Start()
        {
            _viewModel.IsRunning = true;
            _viewModel.ShouldStop = false;
            _viewModel.Solutions.Clear();

            await _solver.SolveAllAsync(_problemSuite, SolvedProblemCallback, _viewModel.RunParallel);

            _viewModel.IsRunning = false;
            _viewModel.ShouldStop = false;
        }

        private void SolvedProblemCallback(Solution solution)
        {
            var vm = new ProblemViewModel();

            vm.Number = solution.Number;
            vm.Description = solution.Description;
            vm.ExpectedAnswer = solution.ExpectedAnswer;
            vm.ProposedAnswer = solution.ProposedAnswer;
            vm.IsCanceled = solution.IsCanceled;
            vm.IsCorrect = solution.IsCorrect;
            vm.IsWrong = solution.IsWrong;
            vm.ElapsedTime = (DateTime.Today + solution.ElapsedTime).ToString("s.fff");

            _viewModel.AddSolution(vm);
        }

        public void OpenWebLink(Uri uri)
        {
            _process.Start(uri.ToString());
        }
    }
}