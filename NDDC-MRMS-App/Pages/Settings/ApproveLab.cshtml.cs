using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NddcMrmsLibrary.Data.Helper;
using NddcMrmsLibrary.Data.LabData;
using System.Reflection.Emit;

namespace NDDC_MRMS_App.Pages.Settings
{
    public class ApproveLabModel : PageModel
    {
        private readonly ILabsData labDb;
        private readonly IHelperData helpDb;

        public string LabName { get; set; }

        public ApproveLabModel(ILabsData labDb, IHelperData  helpDb)
        {
            this.labDb = labDb;
            this.helpDb = helpDb;
        }
        public void OnGet(int? Id)
        {
            LabName = helpDb.GetAnyRecord<string, int>("Laboratories", "LabName", "Id", Id.Value);
        }
        public IActionResult OnPost(int? Id)
        {
            labDb.ApproveLab(Id.Value);
            return RedirectToPage("Labs");
        }
    }
}
