using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Core.Commands
{
    class WaveCommand : ICommand
    {
        public string Execute(string[] args)
        {
            return $"Waving to {args[0]}";
        }
    }
}
