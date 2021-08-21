﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IToDoListRepository ToDoList { get; }
        IToDoItemRepository ToDoItem { get; }
        void Save();
    }
}
