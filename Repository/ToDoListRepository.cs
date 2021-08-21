using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    class ToDoListRepository : RepositoryBase<ToDoList>, IToDoListRepository
    {
        public ToDoListRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<ToDoList> GetAllToDoLists()
        {

            return FindAll()
                .OrderBy(tdl => tdl.Name)
                .Include(tdi => tdi.ToDoItems)
                .ToList();
        }


        public ToDoList GetToDoList(Guid ToDoListId)
        {
            return FindByCondition(tdl => tdl.Id.Equals(ToDoListId))
                .Include(tdi => tdi.ToDoItems)
                .FirstOrDefault();
        }

        public ToDoList GetToDoListById(Guid ToDoListId)
        {
            return FindByCondition(tdl => tdl.Id.Equals(ToDoListId))
                .FirstOrDefault();
        }

        public void CreateToDoList(ToDoList ToDoList)
        {
            ToDoList.CreateDate = DateTimeOffset.UtcNow;
            Create(ToDoList);
        }

        public void UpdateToDoList(ToDoList ToDoList)
        {
            Update(ToDoList);
        }

        public void DeleteToDoList(ToDoList ToDoList)
        {
            Delete(ToDoList);
        }

    }
}
