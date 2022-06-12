using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using CommandPattern.Core;
using CommandPattern.Core.Commands;
using System.Linq;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            
            string[] interpreted = args.Split();
            string[] commandArgs = interpreted.Skip(1).ToArray();
            Array.Copy(interpreted, 1, commandArgs, 0, interpreted.Length - 1);
            

            ICommand command = default;
            Type t = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == $"{interpreted[0]}Command");//Type.GetType($"CommandPattern.Core.Commands.{interpreted[0]}Command");
            command = (ICommand)Activator.CreateInstance(t);
            return command.Execute(commandArgs);
                       
        }

        

        
      
    }
}
