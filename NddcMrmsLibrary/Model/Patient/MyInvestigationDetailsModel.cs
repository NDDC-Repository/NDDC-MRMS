using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NddcMrmsLibrary.Model.Patient
{
	public class MyInvestigationDetailsModel
	{
        public int Id { get; set; }
        public int InvestigationId { get; set; }
        public int ProcessCategoryId { get; set; }
        public int ProcessNameId { get; set; }
        public string TestResult { get; set; }
        public string ResultUnit { get; set; }
        public string RefRange { get; set; }
        public string Flag { get; set; }
        public DateOnly DateConducted { get; set; }
        public TimeOnly TimeReported { get; set; }
        public string ConductedBy { get; set; }
        public string Summary { get; set; }
    }
}
