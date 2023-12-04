using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NddcMrmsLibrary.Data.Patient;
using NddcMrmsLibrary.Model.Patient;

namespace NDDC_MRMS_App.Pages.Settings
{
    public class AddChecklistItemModel : PageModel
    {
        private readonly IPatientData patientDb;
        [BindProperty]
        public MyExaminationTypeModel ExamType { get; set; }

        public AddChecklistItemModel(IPatientData patientDb)
        {
            this.patientDb = patientDb;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost(int? Id)
        {
            ExamType.ExaminationCategoryId = Id.Value;
            patientDb.AddExaminationType(ExamType);

            return RedirectToPage("ChecklistItems", new { Id = Id.Value });
        }
    }
}
