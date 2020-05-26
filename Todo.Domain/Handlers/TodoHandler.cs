using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class TodoHandler :
        Notifiable,
        IHandler<CreateTodoCommand>
    {
        private readonly ITodoRepository _repository;

        public TodoHandler(ITodoRepository repository)
        {
            _repository = repository;
        }
        public ICommandResult Handle(CreateTodoCommand command)
        {
            //fail fast validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(
                    false,
                    "Ops, parece que sua tarefa está errada!",
                    command.Notifications
                    );
            //criar um todo
            //salvar um todo no banco
            // notificar o usuario
            //gerar o todoITem
            var todo = new TodoItem(command.Title, command.Date, command.User);
            //salvar no banco

            _repository.Create(todo);
            return new GenericCommandResult(
                   true,
                   "Tarefa salva",
                   command.Notifications
                   );

        }
    }
}
