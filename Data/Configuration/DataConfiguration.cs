using System.Data.Entity;
using PoorsManDDD.CrossDomain;
using PoorsManDDD.Data.Entities;
using PoorsManDDD.Data.Repositories;
using PoorsManDDD.Data.Specifications;
using PoorsManDDD.Domain.Entities;
using PoorsManDDD.Domain.Repositories;
using PoorsManDDD.Domain.Specifications;

namespace PoorsManDDD.Data.Configuration
{
    public class DataConfiguration : IConfiguration
    {
        public void LoadConfiguration(IContainer container)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<TodoItemContext>());

            container.Register<ITodoItem, TodoItem>();           
            container.Register<ITodoRepository, TodoRepository>();

            container.Register<ISpecification, AllItemsSpecification>(SpecificationType.All.ToString());
            container.Register<ISpecification, FinishedItemsSpecification>(SpecificationType.Finished.ToString());
            container.Register<ISpecification, PendingItemsSpecification>(SpecificationType.Pending.ToString());

            container.Register<IEntityFactory, EntityFactory>();
            container.Register<ISpecificationFactory, SpecificationFactory>();
        }
    }
}
