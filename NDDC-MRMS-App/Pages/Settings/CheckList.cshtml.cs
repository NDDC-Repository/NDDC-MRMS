using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NddcMrmsLibrary.Data.Patient;
using NddcMrmsLibrary.Model.Patient;

namespace NDDC_MRMS_App.Pages.Settings
{
    public class CheckListModel : PageModel
    {
        private readonly IPatientData patientDb;
        public List<MyExaminationCategoryModel> ExamCategories { get; set; }

        public CheckListModel(IPatientData patientDb)
        {
            this.patientDb = patientDb;
        }
        public void OnGet()
        {
            ExamCategories = patientDb.GetAllExaminationCategories();
        }
    }
}
