using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IToDoListRepository _toDoList;
        private IToDoItemRepository _toDoItem;

        public IToDoListRepository ToDoList
        {
            get
            {
                if (_toDoList == null)
                {
                    _toDoList = new ToDoListRepository(_repoContext);
                }
                return _toDoList;
            }
        }

        public IToDoItemRepository ToDoItem
        {
            get
            {
                if (_toDoItem == null)
                {
                    _toDoItem = new ToDoItemRepository(_repoContext);
                }
                return _toDoItem;
            }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}