using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Domain.Commands.Contracts
{
    public class UpdateTodoCommand : Notifiable, ICommand
    {
        public UpdateTodoCommand()
        {

        }
        public UpdateTodoCommand(Guid id, string user, string title)
        {
            Id = id;
            User = user;
            Title = title;
        }

        public Guid Id { get; set; }
        public string User { get; set; }
        public string Title { get; set; }
        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
