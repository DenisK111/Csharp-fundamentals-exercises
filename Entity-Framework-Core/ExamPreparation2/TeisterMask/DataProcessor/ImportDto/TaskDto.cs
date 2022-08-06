using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using TeisterMask.Data.Models.Enums;

namespace TeisterMask.DataProcessor.ImportDto
{
    [XmlType("Task")]
    public class TaskDto
    {
        [XmlElement]
        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string Name { get; set; }
        [XmlElement]
        [Required]
        public string OpenDate { get; set; }
        [Required]
        [XmlElement]
        public string DueDate { get; set; }

        [Required]
        [XmlElement]
        public string ExecutionType { get; set; }
        [Required]
        [XmlElement]
        public string LabelType { get; set; }
    }


}