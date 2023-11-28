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
	public class SqlPaitent
	{
		private readonly string connectionStringName = "SqlDb";
		private readonly ISqlDataAccess db;

		public SqlPaitent(ISqlDataAccess db)
        {
			this.db = db;
		}

		//Medical Bio
		public void AddMedicalBio(MyMedicalBioModel medicalBio)
		{
			db.SaveData("Insert Into MedicalBio (EmpId, Height, BloodGroup, Genotype, Weight, BMI, Disabilities, AddedBy, DateAdded) Values(@EmpId, @Height, @BloodGroup, @Genotype, @Weight, @BMI, @Disabilities, @AddedBy, @DateAdded)", new { medicalBio.EmpId, medicalBio.Height, medicalBio.BloodGroup, medicalBio.Genotype, medicalBio.Weight, medicalBio.BMI, medicalBio.Disabilities, medicalBio.AddedBy, medicalBio.DateAdded }, connectionStringName, false);
		}
		public MyMedicalBioModel GetMedicalBio(int empId)
		{
			return db.LoadData<MyMedicalBioModel, dynamic>("Select Height, BloodGroup, Genotype, Weight, BMI, Disabilities From MedicalBio Where EmpId = @empId", new { empId }, connectionStringName, false).FirstOrDefault();
		}

		//Vitals
		public void AddVitals(MyVitalsModel vitals)
		{
			db.SaveData("Insert Into MedicalBio (EmpId, Temp, Pulse, Oxygen, Systolic, Diastolic, DateAdded, AddedBy) Values (@EmpId, @Temp, @Pulse, @Oxygen, @Systolic, @Diastolic, @DateAdded, @AddedBy)", new { vitals.EmpId, vitals.Temp, vitals.Pulse, vitals.Oxygen, vitals.Systolic, vitals.Diastolic, vitals.DateAdded, vitals.AddedBy }, connectionStringName, false);
		}
		public MyVitalsModel GetVitals(int empId)
		{
			return db.LoadData<MyVitalsModel, dynamic>("Select EmpId, Temp, Pulse, Oxygen, Systolic, Diastolic, DateAdded, AddedBy From Vitals Where EmpId = empId", new { empId }, connectionStringName, false).FirstOrDefault();
		}

		//Investigations
		public void AddInvestigation(MyInvestigationsModel invest)
		{
			db.SaveData("Insert Into Investigations (EmpId, TestDescription, ConductedBy, DateConducted) Values (@EmpId, @TestDescription, @ConductedBy, @DateConducted)", new { invest.EmpId, invest.TestDescription, invest.ConductedBy, invest.DateConducted }, connectionStringName, false);
		}
		public List<MyInvestigationsModel> AllInvestigations()
		{
			return db.LoadData<MyInvestigationsModel, dynamic>("Select Id, EmpId, TestDescription, ConductedBy, DateConducted From Investigations Order By Id Desc ", new { }, connectionStringName, false).ToList();
		}

		public void AddInvestigationDetails(MyInvestigationDetailsModel investDet)
		{
			db.SaveData("Insert Into Investigations (InvestigationId, ProcessCategoryId, ProcessNameId, TestResult, ResultUnit, RefRange, Flag, DateConducted, TimeReported, ConductedBy, Summary) Values (@InvestigationId, @ProcessCategoryId, @ProcessNameId, @TestResult, @ResultUnit, @RefRange, @Flag, @DateConducted, @TimeReported, @ConductedBy, @Summary)", new { investDet.InvestigationId, investDet.ProcessCategoryId, investDet.ProcessNameId, investDet.TestResult, investDet.ResultUnit, investDet.RefRange, investDet.Flag, investDet.DateConducted }, connectionStringName, false);
		}
		public List<MyInvestigationDetailsModel> AllInvestigationDetails()
		{
			return db.LoadData<MyInvestigationDetailsModel, dynamic>("Select Id, InvestigationId, ProcessCategoryId, ProcessNameId, TestResult, ResultUnit, RefRange, Flag, DateConducted, TimeReported, ConductedBy, Summary From InvestigationDetails Order By Id Desc ", new { }, connectionStringName, false).ToList();
		}
		//public MyInvestigationDetailsModel InvestigationDetail(int investigationId)
		//{
		//	return db.LoadData<MyInvestigationDetailsModel, dynamic>("Select EmpId, Temp, Pulse, Oxygen, Systolic, Diastolic, DateAdded, AddedBy From Vitals Where EmpId = empId", new { empId }, connectionStringName, false).FirstOrDefault();
		//}
	}
}
