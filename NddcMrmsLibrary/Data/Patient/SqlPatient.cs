using NddcMrmsLibrary.Databases;
using NddcMrmsLibrary.Model.Patient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NddcMrmsLibrary.Data.Patient
{
    public class SqlPatient : IPatientData
    {
        private readonly string connectionStringName = "SqlDb";
        private readonly ISqlDataAccess db;

        public SqlPatient(ISqlDataAccess db)
        {
            this.db = db;
        }

        //Medical Bio
        public void AddMedicalBio(MyMedicalBioModel medicalBio)
        {
            db.SaveData("Insert Into MedicalBio (EmpId, Height, BloodGroup, Genotype, Weight, BMI, Disabilities, AddedBy, DateAdded) Values(@EmpId, @Height, @BloodGroup, @Genotype, @Weight, @BMI, @Disabilities, @AddedBy, @DateAdded)", new { medicalBio.EmpId, medicalBio.Height, medicalBio.BloodGroup, medicalBio.Genotype, medicalBio.Weight, medicalBio.BMI, medicalBio.Disabilities, medicalBio.AddedBy, medicalBio.DateAdded }, connectionStringName, false);
        }
        public List<MyMedicalBioModel> GetMedicalBio(int empId)
        {
            return db.LoadData<MyMedicalBioModel, dynamic>("Select ROW_NUMBER() OVER(ORDER BY Id DESC) As SrNo, Id, EmpId, Height, BloodGroup, Genotype, Weight, BMI, Disabilities, AddedBy, DateAdded From MedicalBio Where EmpId = @empId", new { empId }, connectionStringName, false).ToList();
        }

        //Vitals
        public void AddVitals(MyVitalsModel vitals)
        {
            db.SaveData("Insert Into MedicalBio (EmpId, Temp, Pulse, Oxygen, Systolic, Diastolic, DateAdded, AddedBy) Values (@EmpId, @Temp, @Pulse, @Oxygen, @Systolic, @Diastolic, @DateAdded, @AddedBy)", new { vitals.EmpId, vitals.Temp, vitals.Pulse, vitals.Oxygen, vitals.Systolic, vitals.Diastolic, vitals.DateAdded, vitals.AddedBy }, connectionStringName, false);
        }
        public MyVitalsModel GetVitalDetails(int Id)
        {
            return db.LoadData<MyVitalsModel, dynamic>("Select Id, EmpId, Temp, Pulse, Oxygen, Systolic, Diastolic, DateAdded, AddedBy From Vitals Where Id = @Id", new { Id }, connectionStringName, false).FirstOrDefault();
        }
        public List<MyVitalsModel> GetVitals(int empId)
        {
            return db.LoadData<MyVitalsModel, dynamic>("Select ROW_NUMBER() OVER (ORDER BY Id DESC) As SrNo, Id, EmpId, Temp, Pulse, Oxygen, Systolic, Diastolic, DateAdded, AddedBy From Vitals Where EmpId = @empId", new { empId }, connectionStringName, false).ToList();
        }

        //Investigations
        public void AddInvestigation(MyInvestigationsModel invest)
        {
            db.SaveData("Insert Into Investigations (EmpId, TestDescription, ConductedBy, DateConducted) Values (@EmpId, @TestDescription, @ConductedBy, @DateConducted)", new { invest.EmpId, invest.TestDescription, invest.ConductedBy, invest.DateConducted }, connectionStringName, false);
        }
        public List<MyInvestigationsModel> AllInvestigations(int empId)
        {
            return db.LoadData<MyInvestigationsModel, dynamic>("SELECT Investigations.Id, ROW_NUMBER() OVER (ORDER BY Investigations.Id DESC) As SrNo, Investigations.EmpId, Investigations.ExaminationYear, Investigations.ExaminationTypeId, Investigations.TestResult, Investigations.RefRange, Investigations.Flag, Investigations.ResultUnit, ExaminationTypes.ExaminationType FROM Investigations Left JOIN ExaminationTypes ON Investigations.ExaminationTypeId = ExaminationTypes.Id Where Investigations.EmpId = @empId Order By Investigations.Id DESC", new { empId }, connectionStringName, false).ToList();
        }

        public void AddInvestigationDetails(MyInvestigationDetailsModel investDet)
        {
            db.SaveData("Insert Into Investigations (InvestigationId, ProcessCategoryId, ProcessNameId, TestResult, ResultUnit, RefRange, Flag, DateConducted, TimeReported, ConductedBy, Summary) Values (@InvestigationId, @ProcessCategoryId, @ProcessNameId, @TestResult, @ResultUnit, @RefRange, @Flag, @DateConducted, @TimeReported, @ConductedBy, @Summary)", new { investDet.InvestigationId, investDet.ProcessCategoryId, investDet.ProcessNameId, investDet.TestResult, investDet.ResultUnit, investDet.RefRange, investDet.Flag, investDet.DateConducted }, connectionStringName, false);
        }
        public List<MyInvestigationDetailsModel> AllInvestigationDetails()
        {
            return db.LoadData<MyInvestigationDetailsModel, dynamic>("Select Id, InvestigationId, ProcessCategoryId, ProcessNameId, TestResult, ResultUnit, RefRange, Flag, DateConducted, TimeReported, ConductedBy, Summary From InvestigationDetails Order By Id Desc ", new { }, connectionStringName, false).ToList();
        }
        public MyInvestigationsModel GetInvestigationDetails(int Id)
        {
            return db.LoadData<MyInvestigationsModel, dynamic>("SELECT Investigations.Id, Investigations.EmpId, Investigations.ExaminationYear, Investigations.ExaminationTypeId, Investigations.TestResult, Investigations.RefRange, Investigations.Flag, Investigations.ResultUnit, Investigations.Summary, ExaminationTypes.ExaminationType, ExaminationCategory.ExaminationCategory FROM Investigations INNER JOIN ExaminationTypes ON Investigations.ExaminationTypeId = ExaminationTypes.Id INNER JOIN ExaminationCategory ON Investigations.ExaminationCategoryId = ExaminationCategory.Id Where Investigations.Id = @Id Order By Investigations.Id DESC", new { Id }, connectionStringName, false).First();
        }

        //Examination
        public void AddExaminationCategory(MyExaminationCategoryModel examCat)
        {
            db.SaveData("Insert Into ExaminationCategory (ExaminationCategory, ShowOnPortal) Values (@ExaminationCategory, @ShowOnPortal)", new { examCat.ExaminationCategory, examCat.ShowOnPortal }, connectionStringName, false);
        }
        public List<MyExaminationCategoryModel> GetAllExaminationCategories()
        {
            return db.LoadData<MyExaminationCategoryModel, dynamic>("Select ROW_NUMBER() OVER (ORDER BY Id DESC) As SrNo, Id, ExaminationCategory, ShowOnPortal  From ExaminationCategory Order By Id Desc ", new { }, connectionStringName, false).ToList();
        }
        public MyExaminationCategoryModel GetExaminationCategory(int Id)
        {
            return db.LoadData<MyExaminationCategoryModel, dynamic>("Select Id, ExaminationCategory, ShowOnPortal  From ExaminationCategory Where Id = @Id", new { Id }, connectionStringName, false).FirstOrDefault();
        }
        public void UpdateExaminationCategory(MyExaminationCategoryModel examCat)
        {
            db.SaveData("Update ExaminationCategory Set ExaminationCategory = @ExaminationCategory, ShowOnPortal = @ShowOnPortal Where Id = @Id", new { examCat.Id, examCat.ExaminationCategory, examCat.ShowOnPortal }, connectionStringName, false);
        }
        public void UpdateExaminationType(MyExaminationTypeModel examType)
        {
            db.SaveData("Update ExaminationTypes Set ExaminationType = @ExaminationType Where Id = @Id", new { examType.ExaminationType, examType.Id }, connectionStringName, false);
        }
        public MyExaminationTypeModel GetExaminationType(int Id)
        {
            return db.LoadData<MyExaminationTypeModel, dynamic>("Select Id, ExaminationCategoryId, ExaminationType  From ExaminationTypes Where Id = @Id", new { Id }, connectionStringName, false).FirstOrDefault();
        }

        public void AddExaminationType(MyExaminationTypeModel examType)
        {
            db.SaveData("Insert Into ExaminationTypes (ExaminationCategoryId, ExaminationType) Values(@ExaminationCategoryId, @ExaminationType)", new { examType.ExaminationCategoryId, examType.ExaminationType }, connectionStringName, false);
        }
        public List<MyExaminationTypeModel> GetAllExaminationTypes(int examCatId)
        {
            return db.LoadData<MyExaminationTypeModel, dynamic>("Select ROW_NUMBER() OVER (ORDER BY Id DESC) As SrNo, Id, ExaminationCategoryId, ExaminationType From ExaminationTypes Where ExaminationCategoryId = @examCatId Order By Id Desc ", new { examCatId }, connectionStringName, false).ToList();
        }


        //Reports
        public List<MyMedicalReportModel> GetAllMedicalReports(int empId)
        {
            return db.LoadData<MyMedicalReportModel, dynamic>("Select ROW_NUMBER() OVER (ORDER BY Id DESC) As SrNo, EmpId, Id, ReportTitle, ExaminationYear, FileName From MedicalReport Where EmpId = @empId Order By Id DESC", new { empId }, connectionStringName, false).ToList();
        }

        //Requests
        public List<MyRequestModel> GetAllRequests()
        {
            return db.LoadData<MyRequestModel, dynamic>("Select ROW_NUMBER() OVER (ORDER BY Id DESC) As SrNo, Id, UserName, RequestedBy, RequestedFrom, RequestType, DateRequested From Requests Order By Id DESC", new { }, connectionStringName, false).ToList();
        }
        public MyRequestModel GetRequestDetails(int Id)
        {
            return db.LoadData<MyRequestModel, dynamic>("SELECT Requests.Id, Requests.InvestigationId, Requests.UserName, Requests.RequestType, Requests.ExaminationYear, Requests.ExaminationCategoryId, Requests.ExaminationTypeId, Requests.Result, Requests.ResultUnit, Requests.RefRange, Requests.Flag, Requests.DateConducted, Requests.TimeReportedOn, Requests.Summary, ExaminationCategory.ExaminationCategory, ExaminationTypes.ExaminationType FROM Requests LEFT JOIN ExaminationCategory ON Requests.ExaminationCategoryId = ExaminationCategory.Id LEFT JOIN ExaminationTypes ON Requests.ExaminationTypeId = ExaminationTypes.Id Where Requests.Id = @Id", new { Id }, connectionStringName, false).FirstOrDefault();
        }
    }
}
