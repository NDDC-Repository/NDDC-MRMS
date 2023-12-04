using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NddcMrmsLibrary.Data.EmployeeData;
using NddcMrmsLibrary.Data.Patient;
using NddcMrmsLibrary.Model.Patient;

namespace NDDC_MRMS_App.Pages.PatientRecords
{
    public class ProfileModel : PageModel
    {
        public EmployeeModel Employee { get; set; }
        public List<MyVitalsModel> Vitals { get; set; }
        public List<MyMedicalBioModel> MedicalBio { get; set; }

        private readonly IEmployeeData empDb;
        private readonly IPatientData patientDb;

        public ProfileModel(IEmployeeData empDb, IPatientData patientDb)
        {
            this.empDb = empDb;
            this.patientDb = patientDb;
        }
        public void OnGet(int? EmpId)
        {
            Employee = empDb.GetEmployeeDetails(EmpId.Value);
            Vitals = patientDb.GetVitals(EmpId.Value);
            MedicalBio = patientDb.GetMedicalBio(EmpId.Value);
            
        }
    }
}
