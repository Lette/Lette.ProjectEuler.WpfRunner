using System;

namespace Lette.ProjectEuler.WpfRunner.View
{
    public interface IMainController
    {
        void Initialize();

        void Quit();
        bool CanQuit();

        void Stop();
        bool CanStop();

        void Start();
        bool CanStart();

        void OpenWebLink(Uri uri);
    }
}