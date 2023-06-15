using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NDDC_MRMS_App.Pages.PatientRecords
{
    public class PatientsModel : PageModel
    {
        public string? SearchTerm { get; set; }
        public void OnGet()
        {
        }
    }
}
