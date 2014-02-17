using System.Diagnostics;

namespace Lette.ProjectEuler.WpfRunner.Services
{
    public class ProcessWrapper : IProcessWrapper
    {
        public void Start(string path)
        {
            Process.Start(path);
        }
    }
}