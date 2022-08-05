using P01_HospitalDatabase.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P01_HospitalDatabase.Data.Models
{
    public class Visitation
    {

        [Key]
        public int VisitationId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [MaxLength(250)]
        public string Comments { get; set; }

        public int PatientId { get; set; }

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public Patient Patient { get; set; }
        /*⦁	VisitationId
        ⦁	Date
        ⦁	Comments (up to 250 characters, unicode)
        ⦁	Patient
        */
    }
}
