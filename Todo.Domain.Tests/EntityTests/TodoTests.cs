﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Todo.Domain.Entities;

namespace Todo.Domain.Tests.EntityTests
{
    [TestClass]
    public class TodoTests
    {

        private readonly TodoItem _validTodo = new TodoItem("titulo", DateTime.Now, "vanessa");

            [TestMethod]
            public void Dado_um_novo_todo_o_mesmo_nao_pode_ser_concluido()
            {

            Assert.AreEqual(_validTodo.Done, false);
             

            }


           

        }
    


}
