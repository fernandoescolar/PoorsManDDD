using Ninject;

namespace PoorsManDDD.CrossDomain.Ninject
{
    internal class NinjectContainer : IContainer
    {
        private readonly IKernel kernel;

        public NinjectContainer(IKernel kernel)
        {
            this.kernel = kernel;
        }
        public T Get<T>()
        {
            return this.kernel.Get<T>();
        }

        public T Get<T>(string name)
        {
            return this.kernel.Get<T>(name);
        }

        public void Register<T>(T instance)
        {
            this.kernel.Bind<T>().ToConstant(instance);
        }

        public void Register<TInterface, TClass>() where TClass : TInterface
        {
            this.kernel.Bind<TInterface>().To<TClass>();
        }

        public void Register<TInterface, TClass>(string name) where TClass : TInterface
        {
            this.kernel.Bind<TInterface>().To<TClass>().Named(name);
        }
    }
}
