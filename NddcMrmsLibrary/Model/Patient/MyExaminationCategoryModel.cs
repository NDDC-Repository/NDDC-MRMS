using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NddcMrmsLibrary.Model.Patient
{
    public class MyExaminationCategoryModel
    {
        public int SrNo { get; set; }
        public int Id { get; set; }
        public string ExaminationCategory { get; set; }
        public Boolean ShowOnPortal { get; set; }
    }
}
