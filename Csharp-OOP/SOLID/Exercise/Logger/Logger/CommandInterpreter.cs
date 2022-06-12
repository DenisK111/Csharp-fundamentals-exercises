using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public class CommandInterpreter
    {

        public string[] InterpretMessage(string message)
        {
            return message.Split("|");

        }

        public string[] InterpretAppender(string message)
        { return message.Split(); }

    }
}
