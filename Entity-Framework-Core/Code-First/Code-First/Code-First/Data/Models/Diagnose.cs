using P01_HospitalDatabase.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P01_HospitalDatabase.Data.Models
{
    public class Diagnose
    {

        [Key]
        public int DiagnoseId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }


        [Required]
        [MaxLength(250)]
        public string Comments { get; set; }


        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        /*⦁	DiagnoseId
        ⦁	Name (up to 50 characters, unicode)
        ⦁	Comments (up to 250 characters, unicode)
        ⦁	Patient
        */
    }
}
