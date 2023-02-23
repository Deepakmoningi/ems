using EmployeeManagement.Models;

namespace EmployeeManagement.Repositories
{
    public interface IEmployeeRepo
    {
        string insertEmployee(Employee empObj);
        string updateEmployee(Employee empObj);
        
        string deleteEmployee(int id);
        //List<MonthlySlaryDistribution> GetMonthlySalarybyId(int Emp_ID, DateTime month_year);
        List<MonthlySlaryDistribution> GetMonthlySalarybyId(SalaryDTO salaryObj);
        string GetMonthlySalary(int Emp_ID, DateTime month_year);

        List<Attendance> calculateWorkingHours(AttendaceDTO attendaceObj);

        bool GetEmployeeData(int id);
        bool CheckDate(DateTime Date);
        bool checkEmpinAttendace(int id);
        bool checkdateinAttendace(DateTime Date);

        List<Employee> getAllEmployees();

        
        List<Attendance> getempAttendancebyid(int id);

        List<Employee> getEmployeebyId(int id);

    }
}
