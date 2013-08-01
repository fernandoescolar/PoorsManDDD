using System;

namespace PoorsManDDD.Domain.Entities
{
    public interface ITodoItem : IEntity<Guid>
    {
        string Name { get; set; }
        DateTime DateCreation { get; set; }
        DateTime LastModificationDate { get; set; }
        TodoState State { get; set; }
    }
}
