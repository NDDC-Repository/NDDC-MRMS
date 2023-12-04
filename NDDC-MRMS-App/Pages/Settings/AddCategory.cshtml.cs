using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NddcMrmsLibrary.Data.Patient;
using NddcMrmsLibrary.Model.Patient;

namespace NDDC_MRMS_App.Pages.Settings
{
    public class AddCategoryModel : PageModel
    {
        private readonly IPatientData patienDb;

        [BindProperty]
        public MyExaminationCategoryModel ExamCat { get; set; }

        public AddCategoryModel(IPatientData patienDb)
        {
            this.patienDb = patienDb;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            patienDb.AddExaminationCategory(ExamCat);

            return RedirectToPage("CheckList");
        }
    }
}
