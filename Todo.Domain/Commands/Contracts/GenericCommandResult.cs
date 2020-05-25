﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Domain.Commands.Contracts
{
    public class GenericCommandResult: ICommandResult
    {
        public GenericCommandResult()
        {

        }
        public GenericCommandResult(bool sucess, string message, object data)
        {
            Sucess = sucess;
            Message = message;
            Data = data;
        }

        public bool Sucess { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
