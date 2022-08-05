
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P01_HospitalDatabase.Data.Models 
{
    public class Patient
    {
        public Patient()
        {
            this.Visitations = new HashSet<Visitation>();
            this.Diagnoses = new HashSet<Diagnose>();
            this.Prescriptions = new HashSet<PatientMedicament>();
        }

        [Key]
        public int PatientId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(250)]
        public string Address { get; set; }

        [Required]
        [MaxLength(80)]
        public string Email { get; set; }

        [Required]
        public bool HasInsurance { get; set; }
        /*⦁	PatientId
        ⦁	FirstName (up to 50 characters, unicode)
        ⦁	LastName (up to 50 characters, unicode)
        ⦁	Address (up to 250 characters, unicode)
        ⦁	Email (up to 80 characters, not unicode)
        ⦁	HasInsurance
        */

        public ICollection<Visitation> Visitations { get; set; }


        public ICollection<Diagnose> Diagnoses { get; set; }

        public ICollection<PatientMedicament> Prescriptions { get; set; }
    }
}
