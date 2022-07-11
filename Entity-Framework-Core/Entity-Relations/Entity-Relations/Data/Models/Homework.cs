using Entity_Relations.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P01_StudentSystem.Data.Models
{
    public class Homework
    {
       
        [Key]
        public int HomeworkId { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(MAX)")]
        public string Content { get; set; }
        [Required]
        public ContentType ContentType { get; set; }
        [Required]

        public DateTime SubmissionTime { get; set; }

        [Required]
        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }
        [Required]
        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }

        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
