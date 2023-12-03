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
        void AddVitals(MyVitalsModel vitals);
        List<MyInvestigationDetailsModel> AllInvestigationDetails();
        List<MyInvestigationsModel> AllInvestigations();
        List<MyExaminationCategoryModel> GetAllExaminationCategories();
        List<MyExaminationTypeModel> GetAllExaminationTypes(int examCatId);
        MyMedicalBioModel GetMedicalBio(int empId);
        MyVitalsModel GetVitalDetails(int Id);
        List<MyVitalsModel> GetVitals(int empId);
    }
}