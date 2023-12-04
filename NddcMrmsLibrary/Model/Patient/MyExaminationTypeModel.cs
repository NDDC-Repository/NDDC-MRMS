using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NddcMrmsLibrary.Model.Patient
{
    public class MyExaminationTypeModel
    {
        public int SrNo { get; set; }
        public int Id { get; set; }
        public int ExaminationCategoryId { get; set; }
        public string ExaminationType { get; set; }
    }
}
