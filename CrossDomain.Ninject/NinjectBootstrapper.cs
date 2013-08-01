using System.IO;
using System.Reflection;
using System.Web.Http;
using Ninject;
using Ninject.Extensions.Conventions;

namespace PoorsManDDD.CrossDomain.Ninject
{
    public class NinjectBootstrapper : IBootstrapper
    {
        private readonly IKernel kernel;
        private readonly NinjectContainer container;

        public NinjectBootstrapper()
        {
            this.kernel = new StandardKernel();
            this.container = new NinjectContainer(this.kernel);
        }

        public void Setup()
        {
            var path = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "bin");
            this.LoadModulesFromFolder(path);
            var modules = this.kernel.GetAll<IConfiguration>();
            foreach (var module in modules)
            {
                module.LoadConfiguration(this.container);
            }

            this.container.Register<IContainer>(this.container);

            GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(this.kernel);
            //DependencyResolver.SetResolver(new NinjectDependencyResolver(this.kernel));
        }

        private void LoadModulesFromFolder(string path)
        {
            this.kernel.Bind(scanner =>
            {
                scanner
                    .FromAssembliesInPath(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), path))
                    .SelectAllClasses()
                    .InheritedFrom<IConfiguration>()
                    .BindAllInterfaces();
            });
        }
    }
}
