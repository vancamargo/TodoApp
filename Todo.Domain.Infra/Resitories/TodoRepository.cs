using System;
using System.Collections.Generic;
using System.Text;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Infra.Resitories
{
    public class TodoRepository : ITodoRepository
    {
        public void Create(TodoItem todo)
        {
            throw new NotImplementedException();
        }

        public TodoItem GetById(Guid id, string user)
        {
            throw new NotImplementedException();
        }

        public void Update(TodoItem todo)
        {
            throw new NotImplementedException();
        }
    }
}
