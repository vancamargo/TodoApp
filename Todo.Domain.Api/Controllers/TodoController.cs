using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;

namespace Todo.Domaim.Api.Controllers
{


    [ApiController]
    [Route("v1/todos")]
    public class TodoController
    {
        [Route("")]
        [HttpPost]
        public GenericCommandResult Create([FromBody] CreateTodoCommand command, [FromServices] TodoHandler handler)
        {
            command.User = "vanessacamargo";
            return (GenericCommandResult)handler.Handle(command);
        }
    }

    //  public IEnumerable<TodoItem> GetAll([FromServices]ITodoRepository repository)
    //{
    //    return repository.GetAll("vanessacamargo");
    //}
    

}
