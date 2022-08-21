using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.ViewModels
{
    public class CreatePlayerInputModel
    {
        public string FullName { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;
        
        public string Position { get; set; } = null!;

        public byte Speed { get; set; }
        public byte Endurance { get; set; }
        
        public string Description { get; set; } = null!;
    }
}
