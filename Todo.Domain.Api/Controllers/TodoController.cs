using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    

    public class TodoController : ControllerBase
    {

        [Route("")]
        [HttpPost]
        public GenericCommandResult Create([FromBody] CreateTodoCommand command, [FromServices] TodoHandler handler)
        {
            command.User = "vanessacamargo";
            return (GenericCommandResult)handler.Handle(command);
        }
        [Route("")]
        [HttpPut]
        public GenericCommandResult Update([FromBody] UpdateTodoCommand command, [FromServices] TodoHandler handler)
        {
            command.User = "vanessacamargo";
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAll(
           [FromServices]ITodoRepository repository
         )
        {
            return repository.GetAll("vanessacamargo");
        }

        [Route("done")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllDone(
          [FromServices]ITodoRepository repository
         )
        {
            return repository.GetAllDone("vanessacamargo");
        }

        [Route("undone")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllUndone(
         [FromServices]ITodoRepository repository
        )
        {
            return repository.GetAllUndone("vanessacamargo");
        }

        [Route("done/today")]
        [HttpGet]
        public IEnumerable<TodoItem> GetDoneForToday(
        [FromServices]ITodoRepository repository
       )
        {
            return repository.GetByPeriod("vanessacamargo", DateTime.Now.Date, true) ;
            
        }

        [Route("done/tomorrow")]
        [HttpGet]
        public IEnumerable<TodoItem> GetDoneForTomorrow(
       [FromServices]ITodoRepository repository
      )
        {
            return repository.GetByPeriod("vanessacamargo", DateTime.Now.Date.AddDays(1), true);

        }

        [Route("undone/tomorrow")]
        [HttpGet]
        public IEnumerable<TodoItem> GetUnDoneForTomorrow(
       [FromServices]ITodoRepository repository
      )
        {
            return repository.GetByPeriod("vanessacamargo", DateTime.Now.Date.AddDays(1), false);

        }

  

        [Route("mark-as-undone")]
        [HttpPut]
        public GenericCommandResult MarkAsUndone([FromBody] MarkTodoAsUndoneCommand command, [FromServices] TodoHandler handler)
        {
            command.User = "vanessacamargo";
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("mark-as-done")]
        [HttpPut]
        public GenericCommandResult MarkAsdone([FromBody] MarkTodoAsDoneCommand command, [FromServices] TodoHandler handler)
        {
            command.User = "vanessacamargo";
            return (GenericCommandResult)handler.Handle(command);
        }

    }


}



