using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Domain.Commands.Contracts
{
    public class MarkTodoAsUndoneCommand :Notifiable, ICommand
    {
        public MarkTodoAsUndoneCommand()
        {

        }
        public MarkTodoAsUndoneCommand(Guid id, string user)
        {
            Id = id;
            User = user;
        }

        public Guid Id { get; set; }
        public string User { get; set; }

        public void Validate()
        {
            new Contract()
                .Requires()
                .HasMinLen(User, 6, "User", "Usuário inválido");
        }

      
    }

}
