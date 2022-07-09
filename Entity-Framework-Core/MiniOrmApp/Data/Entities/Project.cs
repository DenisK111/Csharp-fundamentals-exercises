using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MiniOrmApp.Data.Entities
{
    internal class Project
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<EmployeeProject> EmployeeProject { get; }
    }
}
