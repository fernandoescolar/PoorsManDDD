namespace PoorsManDDD.CrossDomain
{
    public interface IContainer
    {
        T Get<T>();
        T Get<T>(string name);

        void Register<T>(T instance);
        void Register<TInterface, TClass>() where TClass : TInterface;
        void Register<TInterface, TClass>(string name) where TClass : TInterface;
    }
}
