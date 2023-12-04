using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NddcMrmsLibrary.Model.Patient
{
	public class MyDocumentsModel
	{
        public int Id { get; set; }
        public int EmpId { get; set; }
        public string DocTitle { get; set; }
        public string DocDesc { get; set; }
        public string AddedBy { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
