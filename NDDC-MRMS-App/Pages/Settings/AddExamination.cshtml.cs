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
        public void OnGet(int? myId)
        {
            if (myId.HasValue)
            {
                ExamType = patientDb.GetExaminationType(myId.Value);
            }
        }

        public IActionResult OnPost(int? myId)
        {
            if (ExamType.Id == 0)
            {
                ExamType.ExaminationCategoryId = myId.Value;
                patientDb.AddExaminationType(ExamType);
            }
            else
            {
                patientDb.UpdateExaminationType(ExamType);
            }
            

            return RedirectToPage("ChecklistItems", new { Id = myId.Value });
        }
    }
}
