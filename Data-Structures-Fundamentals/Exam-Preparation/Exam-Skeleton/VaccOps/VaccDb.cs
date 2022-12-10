namespace VaccOps
{
    using Models;
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class VaccDb : IVaccOps
    {
        private Dictionary<Doctor, HashSet<Patient>> doctors = new Dictionary<Doctor, HashSet<Patient>>();
        private HashSet<Patient> patients = new HashSet<Patient>();


        public void AddDoctor(Doctor doctor)
        {
            if (doctors.ContainsKey(doctor))
            {
                throw new ArgumentException();
            }

            doctors[doctor] = new HashSet<Patient>();
        }

        public void AddPatient(Doctor doctor, Patient patient)
        {
            if (!doctors.ContainsKey(doctor))
            {
                throw new ArgumentException();
            }

            if (patients.Contains(patient))
            {
                throw new ArgumentException();
            }
                     

            doctors[doctor].Add(patient);
            patients.Add(patient);
        }

        public void ChangeDoctor(Doctor oldDoctor, Doctor newDoctor, Patient patient)
        {
            var oldDoctorExists = doctors.ContainsKey(oldDoctor);
            var newDoctorExists = doctors.ContainsKey(newDoctor);

            if (oldDoctorExists && newDoctorExists && doctors[oldDoctor].Contains(patient))
            {
                doctors[oldDoctor].Remove(patient);
                doctors[newDoctor].Add(patient);                
            }

            else
            {
                throw new ArgumentException();
            }
        }

        public bool Exist(Doctor doctor)
        {
            return doctors.ContainsKey(doctor);
        }

        public bool Exist(Patient patient)
        {
            return doctors.SelectMany(x => x.Value).Contains(patient);
        }

        public IEnumerable<Doctor> GetDoctors()
        {
            return doctors.Keys;
        }

        public IEnumerable<Doctor> GetDoctorsByPopularity(int populariry)
        {
            return doctors.Where(x => x.Key.Popularity == populariry).Select(x=>x.Key);
        }

        public IEnumerable<Doctor> GetDoctorsSortedByPatientsCountDescAndNameAsc()
        {
            return doctors.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key.Name).Select(x => x.Key);
        }

        public IEnumerable<Patient> GetPatients()
        {
            return doctors.SelectMany(x=>x.Value);
        }

        public IEnumerable<Patient> GetPatientsByTown(string town)
        {
            return patients.Where(x => x.Town == town);
        }

        public IEnumerable<Patient> GetPatientsInAgeRange(int lo, int hi)
        {
            return patients.Where(x => x.Age >= lo && x.Age <= hi);
        }

        public IEnumerable<Patient> GetPatientsSortedByDoctorsPopularityAscThenByHeightDescThenByAge()
        {
            var patients =  doctors.SelectMany(x => x.Value, (x, y) => new { Popularity = x.Key.Popularity, Patient = y });

            return patients.OrderBy(x => x.Popularity).ThenByDescending(x => x.Patient.Height).ThenBy(x => x.Patient.Age).Select(x => x.Patient);
        }

        public Doctor RemoveDoctor(string name)
        {
            var doctor = new Doctor(name, 12);
            
            

            if (!doctors.ContainsKey(doctor))
            {
                throw new ArgumentException();
            }

            //foreach (var item in doctors)
            //{
            //    if (item.Key.Equals(doctor))
            //    {

            //        doctor = item.Key;

            //    }
            //}

            doctors.Remove(doctor);
            return doctor;
        }
    }
}
