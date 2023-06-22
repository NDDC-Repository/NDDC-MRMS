using NddcMrmsLibrary.Databases;
using NddcMrmsLibrary.Model.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NddcMrmsLibrary.Data.EmployeeData
{
    public class SQLEmployee : IEmployeeData
    {
        private readonly ISqlDataAccess db;

        private const string connectionStringName = "PayrollDB";

        public SQLEmployee(ISqlDataAccess db)
        {
            this.db = db;

        }

        public List<EmployeeGridModel> GetAllEmployees(string name)
        {
            string SQL = "SELECT Top 20 ROW_NUMBER() OVER (ORDER BY Employees.Id DESC) As SrNo, Employees.Id, Employees.EmployeeCode, Employees.Gender, Employees.FirstName, Employees.LastName, Employees.Email, Employees.Phone, Employees.Category, Employees.Archived, Employees.ExitCondition, Employees.ExitDate, GradeLevel.GradeLevel, Departments.DepartmentName, JobTitles.Description FROM Employees LEFT JOIN GradeLevel ON Employees.GradeLevelId = GradeLevel.Id LEFT JOIN Departments ON Employees.DepartmentId = Departments.Id LEFT JOIN JobTitles ON Employees.JobTitleId = JobTitles.Id Where Employees.FirstName Like @Name Or Departments.DepartmentName Like @Name Or Employees.LastName Like @Name Or GradeLevel.GradeLevel Like @Name Or EmployeeCode Like @Name ORDER BY Employees.Id DESC";
            return db.LoadData<EmployeeGridModel, dynamic>(SQL, new { Name = "%" + name + "%" }, connectionStringName, false).ToList();
        }
        public EmployeeModel GetEmployeeDetails(int EmpId)
        {
            //string SQL2 = "SELECT Employees.EmployeeCode, Employees.Gender, Employees.MaritalStatus, Employees.FirstName, Employees.LastName, Employees.OtherNames, Employees.SpouseName, Employees.Email, Employees.Phone, Employees.DateOfBirth, Employees.Address, Employees.City, Employees.SID, Employees.Passport, Employees.EmploymentStatus, Employees.DateEngaged, Employees.ContactName, Employees.ContactPhone, Employees.Category, GradeLevel.GradeLevel, Departments.DepartmentName, JobTitles.Description FROM Employees LEFT JOIN GradeLevel ON Employees.GradeLevelId = GradeLevel.Id LEFT JOIN Departments ON Employees.DepartmentId = Departments.Id LEFT JOIN JobTitles ON Employees.JobTitleId = JobTitles.Id Where Id = @Id";
            string SQL = "SELECT Id, EmployeeCode, Gender, MaritalStatus, FirstName, LastName, OtherNames, SpouseName, Email, Phone, DateOfBirth, Address, City, SID, Passport, EmploymentStatus, DateEngaged, ContactName, ContactPhone from Employees Where Id = @Id";
            return db.LoadData<EmployeeModel, dynamic>(SQL, new { Id = EmpId }, connectionStringName, false).First();
        }
        public int GetEmployeeCount()
        {
            //string check = db.LoadData<string, dynamic>("Select Count(Id) As EmpCount from Employees Where Archived = 0", new {  }, connectionStringName, false).FirstOrDefault();
            //if (check is null)
            //{
            //    return 0;
            //}
            string SQL = "Select Count(Id) As EmpCount from Employees Where Archived = 0";
            return db.LoadData<int, dynamic>(SQL, new { }, connectionStringName, false).FirstOrDefault();
        }
    }
}
