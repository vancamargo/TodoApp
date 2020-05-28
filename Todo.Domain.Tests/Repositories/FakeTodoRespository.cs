using System;
using System.Collections.Generic;
using System.Text;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Tests.Repositories
{
    class FakeTodoRespository : ITodoRepository
    {
        public void Create(TodoItem todo)
        {
            
        }

        public TodoItem GetById(Guid id, string user)
        {
            return new TodoItem("Titulo aqui", DateTime.Now, "vanessacamargo");
        }

        public void Update(TodoItem todo)
        {
            
        }
    }
}
