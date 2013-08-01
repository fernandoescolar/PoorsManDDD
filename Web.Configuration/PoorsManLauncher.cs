using System;
using PoorsManDDD.CrossDomain;

namespace PoorsManDDD.Web.Configuration
{
    public class PoorsManLauncher
    {
        public static void Setup()
        {
            var config = (BootstrapperSection)System.Configuration.ConfigurationManager.GetSection("bootstrapper");
            var bootstrapper = (IBootstrapper) Activator.CreateInstance(Type.GetType(config.Class));
            bootstrapper.Setup();
        }
    }
}
