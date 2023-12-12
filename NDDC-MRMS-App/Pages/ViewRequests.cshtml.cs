using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NddcMrmsLibrary.Data.Patient;
using NddcMrmsLibrary.Model.Patient;

namespace NDDC_MRMS_App.Pages
{
    public class ViewRequestsModel : PageModel
    {
        private readonly IPatientData patientDb;

        public MyRequestModel MyRequest { get; set; }
        public MyInvestigationsModel Investigation { get; set; }

        public ViewRequestsModel(IPatientData patientDb)
        {
            this.patientDb = patientDb;
        }

        public void OnGet(int? Id)
        {
            MyRequest = patientDb.GetRequestDetails(Id.Value);
            Investigation = patientDb.GetInvestigationDetails(MyRequest.InvestigationId);

        }
    }
}
