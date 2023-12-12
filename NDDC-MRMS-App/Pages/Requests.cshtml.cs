using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NddcMrmsLibrary.Data.Patient;
using NddcMrmsLibrary.Model.Patient;

namespace NDDC_MRMS_App.Pages
{
    public class RequestsModel : PageModel
    {
        public List<MyRequestModel> Requests { get; set; }

        private readonly IPatientData patientDb;

        public RequestsModel(IPatientData patientDb)
        {
            this.patientDb = patientDb;
        }
        public void OnGet()
        {
            Requests = patientDb.GetAllRequests();
        }
    }
}
