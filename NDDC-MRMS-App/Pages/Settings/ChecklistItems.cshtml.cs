using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NddcMrmsLibrary.Data.Helper;
using NddcMrmsLibrary.Data.Patient;
using NddcMrmsLibrary.Model.Patient;

namespace NDDC_MRMS_App.Pages.Settings
{
    public class ChecklistItemsModel : PageModel
    {
        private readonly IPatientData patientDb;
        private readonly IHelperData helpDb;

        public List<MyExaminationTypeModel> ExamTypes { get; set; }
        public int MyId { get; set; }
        public string ExamCategory { get; set; }

        public ChecklistItemsModel(IPatientData patientDb, IHelperData helpDb)
        {
            this.patientDb = patientDb;
            this.helpDb = helpDb;
        }
        public void OnGet(int? Id)
        {
            ExamCategory = helpDb.GetAnyRecord<string, int>("ExaminationCategory", "ExaminationCategory", "Id", Id.Value);
            MyId = Id.Value;
            ExamTypes = patientDb.GetAllExaminationTypes(Id.Value);
        }
    }
}
