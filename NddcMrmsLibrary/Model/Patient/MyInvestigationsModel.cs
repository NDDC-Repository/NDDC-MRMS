using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NddcMrmsLibrary.Model.Patient
{
	public class MyInvestigationsModel
	{
        public int Id { get; set; }
        public int EmpId { get; set; }
        public string TestDescription { get; set; }
        public string ConductedBy { get; set; }
        public DateTime DateConducted { get; set; }
    }
}
