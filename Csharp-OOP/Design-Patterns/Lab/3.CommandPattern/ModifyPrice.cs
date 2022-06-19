using System;
using System.Collections.Generic;
using System.Text;

namespace _3.CommandPattern
{
    public class ModifyPrice
    {
        private readonly List<ICommand> commands;
        //private ICommand command;

        public ModifyPrice()
        {
            commands = new List<ICommand>();
        }

        //private void SetCommand(ICommand command) => this.command = command;
        public void Invoke(ICommand command)
        {

            commands.Add(command);
            command.ExecuteCommand();

        }
    }
}
