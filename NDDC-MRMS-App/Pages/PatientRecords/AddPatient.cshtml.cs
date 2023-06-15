using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NddcMrmsLibrary.Model.Patient;

namespace NDDC_MRMS_App.Pages.PatientRecords
{
    public class AddPatientsModel : PageModel
    {
        public MyPatientModel Patient { get; set; }
        public void OnGet()
        {
        }
    }
}
