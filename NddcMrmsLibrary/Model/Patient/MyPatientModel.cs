using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NddcMrmsLibrary.Model.Patient
{
    public class MyPatientModel
    {
        public int Id { get; set; }
        public string EmployeeCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string OtherNames { get; set; }
        public string Phone { get; set; }   
        public string Email { get; set; }
        public string MaritalStatus { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Height { get; set; }
        public string BloodGroup { get; set; }
        public string Genotype { get; set; }
        public Boolean Disabltities { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string Lga { get; set; }
        public string City { get; set; }
        public string NoKName { get; set; }
        public string NoKPhone { get; set; }
        public string NoKAddress { get; set; }
        public string NoKRelationship { get; set; }
        public string NoKEmail { get; set; }
        public string EmergencyName { get; set; }
        public string EmergencyAddress { get; set; }
        public string EmergencyEmail { get; set; }
        public string EmergencyPhone { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
