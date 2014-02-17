using System.Configuration;

namespace Lette.ProjectEuler.WpfRunner.Services
{
    public class Settings : ISettings
    {
        public string SolutionsAssembly
        {
            get { return ConfigurationManager.AppSettings["SolutionsAssembly"]; }
        }
    }
}