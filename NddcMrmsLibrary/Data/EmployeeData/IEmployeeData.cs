using NddcMrmsLibrary.Model.Patient;

namespace NddcMrmsLibrary.Data.EmployeeData
{
    public interface IEmployeeData
    {
        List<EmployeeGridModel> GetAllEmployees(string name);
        int GetEmployeeCount();
        EmployeeModel GetEmployeeDetails(int EmpId);
    }
}