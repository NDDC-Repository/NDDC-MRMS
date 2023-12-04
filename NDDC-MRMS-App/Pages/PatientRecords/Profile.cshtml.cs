using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NddcMrmsLibrary.Data.EmployeeData;
using NddcMrmsLibrary.Data.Helper;
using NddcMrmsLibrary.Data.Patient;
using NddcMrmsLibrary.Model.Patient;

namespace NDDC_MRMS_App.Pages.PatientRecords
{
    public class ProfileModel : PageModel
    {
        public EmployeeModel Employee { get; set; }
        public List<MyVitalsModel> Vitals { get; set; }
        public List<MyMedicalBioModel> MedicalBio { get; set; }
        public List<MyInvestigationsModel> Investigations { get; set; }
        public List<MyMedicalReportModel> MedicalReport { get; set; }
        public int Age { get; set; }

        private readonly IEmployeeData empDb;
        private readonly IPatientData patientDb;
        private readonly IHelperData helpDb;

        public ProfileModel(IEmployeeData empDb, IPatientData patientDb, IHelperData helpDb)
        {
            this.empDb = empDb;
            this.patientDb = patientDb;
            this.helpDb = helpDb;
        }
        public void OnGet(int? EmpId)
        {
           
            Employee = empDb.GetEmployeeDetails(EmpId.Value);
            //var today = DateTime.Today;
            //DateTime myAge = (DateTime)Employee.DateOfBirth;
            //Age = today.Year - myAge.Year;
            Age = helpDb.GetAge((DateTime)Employee.DateOfBirth);
            Vitals = patientDb.GetVitals(EmpId.Value);
            MedicalBio = patientDb.GetMedicalBio(EmpId.Value);
            Investigations = patientDb.AllInvestigations(EmpId.Value);
            MedicalReport = patientDb.GetAllMedicalReports(EmpId.Value);
            
        }
    }
}
