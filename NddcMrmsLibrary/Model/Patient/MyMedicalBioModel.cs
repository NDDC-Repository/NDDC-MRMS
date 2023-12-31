﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NddcMrmsLibrary.Model.Patient
{
	public class MyMedicalBioModel
	{
        public int SrNo { get; set; }
        public int Id { get; set; }
        public int EmpId { get; set; }
        public string EmployeeCode { get; set; }
        public double Height { get; set; }
        public string BloodGroup { get; set; }
        public string Genotype { get; set; }
        public int Weight { get; set; }
        public double BMI { get; set; }
        public Boolean Disabilities { get; set; }
        public string AddedBy { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
