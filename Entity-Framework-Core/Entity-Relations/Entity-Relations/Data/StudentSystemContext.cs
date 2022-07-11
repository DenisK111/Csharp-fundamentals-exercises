using P01_StudentSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<Homework> HomeworkSubmissions { get; set; }
        public StudentSystemContext()
        {
        }

        public StudentSystemContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost,1433;Initial Catalog=StudentSystemDB;User ID=sa;Password=Sql12345678");
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(builder => 
            {
                builder.Property(x=>x.PhoneNumber)
                    .IsUnicode(false);
                            });
            modelBuilder.Entity<Homework>(builder =>
            {
                builder.Property(x => x.SubmissionTime)
                    .HasDefaultValue(DateTime.Now);
            });


            modelBuilder.Entity<StudentCourse>(builder =>
            {
                builder.HasKey(p => new { p.StudentId, p.CourseId });

            });

            modelBuilder.Entity<Resource>(builder =>
            {
                builder.Property(p => p.Url)
                    .IsUnicode(false);


            });

        }

    }
}
