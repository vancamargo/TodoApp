using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Todo.Domain.Commands;

namespace Todo.Domain.Tests
{
    [TestClass]
    public class CreateTodoCommandTests
    {
        private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", DateTime.Now, "");
        private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("T�tulo da Tarefa", DateTime.Now, "vanessacamargo");
        [TestMethod]

        
        public void Dado_um_comando_invalido()
        {
        
            Assert.AreEqual(_invalidCommand.Valid, false);

        }

        [TestMethod]
        public void Dado_um_comando_valido()
        {
            
            Assert.AreEqual(_validCommand.Valid, true);
        }
    }
}
