using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NddcMrmsLibrary.Data.EmployeeData;
using NddcMrmsLibrary.Model.Patient;

namespace NDDC_MRMS_App.Pages.PatientRecords
{
    public class PatientsModel : PageModel
    {
        private readonly IEmployeeData db;
        public List<EmployeeGridModel> Employees { get; set; }
        public List<EmployeeGridModel> ArchivedEmployees { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public PatientsModel(IEmployeeData db)
        {
            this.db = db;
        }
        public void OnGet()
        {
            Employees = db.GetAllEmployees(SearchTerm);
        }
    }
}
