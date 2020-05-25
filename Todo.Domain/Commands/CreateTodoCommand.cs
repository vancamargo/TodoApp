using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class CreateTodoCommand :Notifiable, ICommand
    {
        public CreateTodoCommand()
        {

        }
        public CreateTodoCommand(string title, DateTime dateTime, string user)
        {
            Title = title;
            DateTime = dateTime;
            User = user;
        }

        public string Title { get; set; }
        public DateTime DateTime { get; set; }
        public string User { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Title, 3, "Title", "Por favor, descreva melhor sua tarefa")
                .HasMaxLen(User, 6, "User", "Usuario inválido")
                );
        }
    }
}
