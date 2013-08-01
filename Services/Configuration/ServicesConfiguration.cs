using PoorsManDDD.CrossDomain;
using PoorsManDDD.Services.Contracts;

namespace PoorsManDDD.Services.Configuration
{
    public class ServicesConfiguration : IConfiguration
    {
        public void LoadConfiguration(IContainer container)
        {
            container.Register<ITodoService, TodoService>();
        }
    }
}
