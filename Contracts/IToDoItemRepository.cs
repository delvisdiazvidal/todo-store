using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IToDoItemRepository : IRepositoryBase<ToDoItem>
    {
        IEnumerable<ToDoItem> GetAllToDoItems();
        ToDoItem GetToDoItemById(Guid ToDoItemId);
        void CreateToDoItem(ToDoItem ToDoItem);
        void UpdateToDoItem(ToDoItem ToDoItem);
        void DeleteToDoItem(ToDoItem ToDoItem);
        IEnumerable<ToDoItem> ToDoItemsByList(Guid ToDoListId);
        void DeleteToDoItemByList(Guid ToDoListId);
    }
}