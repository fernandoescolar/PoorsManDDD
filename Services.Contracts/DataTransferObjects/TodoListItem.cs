using System;

namespace PoorsManDDD.Services.Contracts.DataTransferObjects
{
    public class TodoListItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
    }
}
