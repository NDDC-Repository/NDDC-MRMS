using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NddcMrmsLibrary.Data.Patient;
using NddcMrmsLibrary.Model.Patient;

namespace NDDC_MRMS_App.Pages.Settings
{
    public class ChecklistItemsModel : PageModel
    {
        private readonly IPatientData patientDb;
        public List<MyExaminationTypeModel> ExamTypes { get; set; }

        public ChecklistItemsModel(IPatientData patientDb)
        {
            this.patientDb = patientDb;
        }
        public void OnGet(int? Id)
        {
            ExamTypes = patientDb.GetAllExaminationTypes(Id.Value);
        }
    }
}
