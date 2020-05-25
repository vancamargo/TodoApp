using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Domain.Entities
{
    public class TodoItem :Entity
    {
        public TodoItem(string title, DateTime dateTime, string user)
        {
            Title = title;
            Done = false;
            DateTime = dateTime;
            User = user;
        }

        public string Title { get; set; }
        public bool Done { get; set; }
        public DateTime DateTime { get; set; }
        public string User { get; set; }

        public void MarkAsDone()
        {
            Done = true;
        }

        public void MarkAsUndone()
        {
            Done = false;
        }

        public void UpdateTitle(string title)
        {
            Title = Title;
        }

    }
}
