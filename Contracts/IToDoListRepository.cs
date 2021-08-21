using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IToDoListRepository : IRepositoryBase<ToDoList>
    {
        IEnumerable<ToDoList> GetAllToDoLists();
        ToDoList GetToDoList(Guid ToDoListId);
        ToDoList GetToDoListById(Guid ToDoListId);
        void CreateToDoList(ToDoList ToDoList);
        void UpdateToDoList(ToDoList ToDoList);
        void DeleteToDoList(ToDoList ToDoList);
    }
}