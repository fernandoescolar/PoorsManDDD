using System;
using System.Collections.Generic;
using PoorsManDDD.Services.Contracts.DataTransferObjects;

namespace PoorsManDDD.Services.Contracts
{
    public interface ITodoService
    {
        IEnumerable<TodoListItem> GetPending();
        void AddNew(TodoListItem item);
        void UpdateStateToDone(Guid itemId);
    }
}
