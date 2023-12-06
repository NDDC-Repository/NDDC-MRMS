using NddcMrmsLibrary.Model.Patient;

namespace NddcMrmsLibrary.Data.Patient
{
    public interface IPatientData
    {
        void AddExaminationCategory(MyExaminationCategoryModel examCat);
        void AddExaminationType(MyExaminationTypeModel examType);
        void AddInvestigation(MyInvestigationsModel invest);
        void AddInvestigationDetails(MyInvestigationDetailsModel investDet);
        void AddMedicalBio(MyMedicalBioModel medicalBio);
        List<MyMedicalBioModel> GetMedicalBio(int empId);
        void AddVitals(MyVitalsModel vitals);
        List<MyInvestigationDetailsModel> AllInvestigationDetails();
        List<MyInvestigationsModel> AllInvestigations(int empId);
        List<MyExaminationCategoryModel> GetAllExaminationCategories();
        List<MyExaminationTypeModel> GetAllExaminationTypes(int examCatId);
        MyVitalsModel GetVitalDetails(int Id);
        List<MyVitalsModel> GetVitals(int empId);
        List<MyMedicalReportModel> GetAllMedicalReports(int empId);
        MyExaminationCategoryModel GetExaminationCategory(int Id);
        void UpdateExaminationCategory(MyExaminationCategoryModel examCat);
        void UpdateExaminationType(MyExaminationTypeModel examType);
        MyExaminationTypeModel GetExaminationType(int Id);
    }
}