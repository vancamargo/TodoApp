using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.QueryTest
{
    [TestClass]

    public class TodoQueryTests
    {
        private List<TodoItem> _items;
        public TodoQueryTests()
        {
            _items = new List<TodoItem>();
            _items.Add(new TodoItem("tarefa 1", DateTime.Now, "Usuarioa"));
            _items.Add(new TodoItem("tarefa 2", DateTime.Now, "Usuariob"));
            _items.Add(new TodoItem("tarefa 3", DateTime.Now, "Usuariob"));
            _items.Add(new TodoItem("tarefa 4", DateTime.Now, "vanessa"));
            _items.Add(new TodoItem("tarefa 5", DateTime.Now, "vanessa"));
        }
        [TestMethod]
        public void Data_a_consulta_retorne_consulta_vanessa()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAll("vanessa"));
            Assert.AreEqual(2, result.Count());
        }

    }
}
