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
    class ToDoItemRepository : RepositoryBase<ToDoItem>, IToDoItemRepository
    {
        public ToDoItemRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<ToDoItem> GetAllToDoItems()
        {
            return FindAll()
                .OrderBy(tdi => tdi.Name)
                .ToList();
        }

        public ToDoItem GetToDoItemById(Guid ToDoItemId)
        {
            return FindByCondition(tdi => tdi.Id.Equals(ToDoItemId))
                .FirstOrDefault();
        }

        public void CreateToDoItem(ToDoItem ToDoItem)
        {
            ToDoItem.Status = ToDoItemStatus.PENDING;
            Create(ToDoItem);
        }

        public void UpdateToDoItem(ToDoItem ToDoItem)
        {
            Update(ToDoItem);
        }

        public void DeleteToDoItem(ToDoItem ToDoItem)
        {
            Delete(ToDoItem);
        }

        public IEnumerable<ToDoItem> ToDoItemsByList(Guid ToDoListId)
        {
            return FindByCondition(tdi => tdi.ToDoListId.Equals(ToDoListId)).ToList();
        }

        public void DeleteToDoItemByList(Guid ToDoListId)
        {
            var itemList = FindByCondition(tdi => tdi.ToDoListId.Equals(ToDoListId)).ToList();
            foreach (var item in itemList)
            {
                Delete(item);
            } 
                
        }

    }
}