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
        IHandler<CreateTodoCommand>, 
        IHandler<UpdateTodoCommand>,
        IHandler<MarkTodoAsDoneCommand>, 
        IHandler<MarkTodoAsUndoneCommand>
    {
        private readonly ITodoRepository _repository;

        public TodoHandler(ITodoRepository repository)
        {
            _repository = repository;
        }
        public ICommandResult Handle(CreateTodoCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

            // Gera o TodoItem
            var todo = new TodoItem(command.Title, command.Date, command.User );

            // Salva no banco
            _repository.Create(todo);

            // Retorna o resultado
            return new GenericCommandResult(true, "Tarefa salva", todo);

        }

        public ICommandResult Handle(UpdateTodoCommand command)
        {
            //fail fast validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

            //recupera o todoItem
            var todo = _repository.GetById(command.Id, command.User);

            //altera o titulo
            todo.UpdateTitle(command.Title);

            //salva no banco
            _repository.Update(todo);

            _repository.Create(todo);
            return new GenericCommandResult(
                   true,
                   "Tarefa salva",
                   command.Notifications
                   );
        }

        public ICommandResult Handle(MarkTodoAsDoneCommand command)
        {
            //fail fast validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

            //recupera o todoItem
            var todo = _repository.GetById(command.Id, command.User);

            //altera o titulo
            todo.MarkAsDone();

            //salva no banco
            _repository.Update(todo);

            _repository.Create(todo);
            return new GenericCommandResult(
                   true,
                   "Tarefa salva",
                   command.Notifications
                   );
        }

        public ICommandResult Handle(MarkTodoAsUndoneCommand command)
        {
            //fail fast validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

            //recupera o todoItem
            var todo = _repository.GetById(command.Id, command.User);

            //altera o titulo
            todo.MarkAsUndone();

            //salva no banco
            _repository.Update(todo);

            _repository.Create(todo);
            return new GenericCommandResult(
                   true,
                   "Tarefa salva",
                   command.Notifications
                   );
        }
    }
}
