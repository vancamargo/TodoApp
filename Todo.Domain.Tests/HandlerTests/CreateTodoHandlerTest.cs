using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.HandlerTests
{

   
        [TestClass]
        public class CreateTodoHandlerTest
        {

        private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", DateTime.Now, "");
        private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Título da Tarefa", DateTime.Now, "vanessacamargo");
        private readonly TodoHandler _handler = new TodoHandler(new FakeTodoRespository());

        public CreateTodoHandlerTest()
        {

        }

        [TestMethod]
            public void Dado_um_comando_invalido_intyerromper_a_execucao()
            {

          
            var result = (GenericCommandResult)_handler.Handle(_invalidCommand);
            Assert.AreEqual(result.Sucess, false);

        }


        [TestMethod]
        public void Dado_um_comando_valido_vai_executar()
        {

            var result = (GenericCommandResult)_handler.Handle(_validCommand);
            Assert.AreEqual(result.Sucess, true);


        }

    }
    }



   