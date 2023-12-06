using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NddcMrmsLibrary.Data.Patient;
using NddcMrmsLibrary.Model.Patient;

namespace NDDC_MRMS_App.Pages.Settings
{
    public class AddCategoryModel : PageModel
    {
        private readonly IPatientData patienDb;

        [TempData]
        public string FormResult { get; set; }

        [BindProperty]
        public MyExaminationCategoryModel ExamCat { get; set; }

        public AddCategoryModel(IPatientData patienDb)
        {
            this.patienDb = patienDb;
        }
        public void OnGet(int? Id)
        {
            if (Id.HasValue)
            {
                ExamCat = patienDb.GetExaminationCategory(Id.Value);
            }
        }

        public IActionResult OnPost()
        {
            if (ExamCat.Id == 0)
            {
                patienDb.AddExaminationCategory(ExamCat);
                FormResult = $"A New Examination Category ({ExamCat.ExaminationCategory}) has been Successfully Added";
            }
            else
            {
                patienDb.UpdateExaminationCategory(ExamCat);
            }

            return RedirectToPage("CheckList");
        }
    }
}
