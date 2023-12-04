using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NddcMrmsLibrary.Data.LabData;
using NddcMrmsLibrary.Model.Lab;

namespace NDDC_MRMS_App.Pages.Settings
{
    public class LabsModel : PageModel
    {
        private readonly ILabsData labDb;

        [BindProperty]
        public string SearchTerm { get; set; }
        public List<MyLabModel> Labs { get; set; }
        
        public LabsModel(ILabsData labDb)
        {
            this.labDb = labDb;
        }
        public void OnGet()
        {
            Labs = labDb.GetAllLabs();
        }
        public void OnPost()
        {
        }

    }
}
