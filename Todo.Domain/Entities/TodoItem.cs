﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Domain.Entities
{
    public class TodoItem :Entity
    {
        public TodoItem(string title, DateTime date, string user)
        {
            Title = title;
            Done = false;
            Date = date;
            User = user;
        }

        public string Title { get; set; }
        public bool Done { get; set; }
        public DateTime Date { get; set; }
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
