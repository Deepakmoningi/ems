using EmployeeManagement.Data;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace EmployeeManagement.Repositories
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly EmpDbContext _context;
        public string? Action;
        public EmployeeRepo(EmpDbContext empdbcontext)
        {
            _context = empdbcontext;
        }

        public List<Employee> getEmployeebyId(int id)
        {
            var checkEmpdata = _context.employees.Where(x => x.Emp_Id == id).FirstOrDefault();
            var data = _context.employees.Where(x => x.Emp_Id == id).ToList();
            if (checkEmpdata != null)
            {
                return data;
            }
            else 
            {
                return null;
            }
        }

        public List<Attendance> calculateWorkingHours(AttendaceDTO attendaceObj)
        {
            var data = _context.employees.Where(x => x.Emp_Id == attendaceObj.Emp_Id).FirstOrDefault();
            if (data == null)
            {
                return null;
            }
            else
            {
                _context.Database.ExecuteSql($"execute spcalculateWorkingHours {attendaceObj.Emp_Id},{attendaceObj.Check_In_Time},{attendaceObj.Check_Out_Time}");
                var empattendacelist = _context.entries.Where(x => x.Emp_Id == attendaceObj.Emp_Id && x.Check_In_Time == attendaceObj.Check_In_Time).ToList();
                return empattendacelist;
            }
            //throw new NotImplementedException();
        }

        public List<MonthlySlaryDistribution> GetMonthlySalarybyId(SalaryDTO salaryObj)
        {
            var data = _context.employees.Where(x => x.Emp_Id == salaryObj.Emp_ID).FirstOrDefault();
            if (data == null)
            {
                return null;
            }
            else
            {
                string date_str = salaryObj.month_year.ToString("dd/MM/yyyy");
                //_context.Database.ExecuteSql($"execute spMonthlySalaryDistribution {salaryObj.Emp_ID},{date_str}");
                _context.Database.ExecuteSql($"execute spMonthlySalaryDistribution {salaryObj.Emp_ID},{salaryObj.month_year}");

                string test = salaryObj.month_year.ToString("yyyy/dd/MM");
                //DateTime.ParseExact(this.Text, "dd/MM/yyyy", null);
                //DateTime enteredDate = DateTime.Parse(test);
                DateTime enteredDate = DateTime.ParseExact(test, "yyyy/dd/MM", null);
                var empData = _context.distributions.Where(x => x.E_Id == salaryObj.Emp_ID && x.Month_Year == enteredDate).ToList();
                return empData;
            }

        }

        public bool CheckDate(DateTime Date)
        {
            string test = Date.ToString("yyyy/dd/MM");
            DateTime enteredDate = DateTime.Parse(test);
            var data = _context.distributions.Where(x => x.Month_Year == enteredDate).FirstOrDefault();
            if (data == null)
            {
                return true;
            }
            else
            {
                return false;
            }
            // throw new NotImplementedException();
        }

        //public string deleteEmployee(Employee empObj)
        //{
        //    var data = _context.employees.Where(x => x.Emp_Id == empObj.Emp_Id).FirstOrDefault();
        //    if (data == null)
        //    {
        //        return null;
        //    }
        //    else
        //    {
        //        _context.Database.ExecuteSql($"execute spMasterProcedure {empObj.Emp_Id},{empObj.Emp_Name},{empObj.Annual_salary},{empObj.E_Dept_Id},{Action = "delete"}");
        //        return "success";
        //    }
        //    //throw new NotImplementedException();
        //}

        public string deleteEmployee(int id)
        {
            var data = _context.employees.Where(x => x.Emp_Id == id).FirstOrDefault();
            if (data == null)
            {
                return null;
            }
            else
            {
                _context.Database.ExecuteSql($"execute spMasterProcedure {data.Emp_Id},{data.Emp_Name},{data.Annual_salary},{data.E_Dept_Id},{Action = "delete"}");
                return "success";
            }
            //throw new NotImplementedException();
        }

        public bool GetEmployeeData(int id)
        {
            var data = _context.distributions.Where(x => x.E_Id == id).FirstOrDefault();
            if (data == null)
            {
                return true;
            }
            else
            {
                return false;
            }
            //throw new NotImplementedException();
        }

        public string GetMonthlySalary(int Emp_ID, DateTime month_year)
        {
            var data = _context.employees.Where(x => x.Emp_Id == Emp_ID).FirstOrDefault();
            if (data == null)
            {
                return null;
            }
            else
            {
                bool CheckId = GetEmployeeData(Emp_ID);
                bool checkdate = CheckDate(month_year);
                if (CheckId || checkdate)
                {
                    string date_str = month_year.ToString("dd/MM/yyyy");
                    _context.Database.ExecuteSql($"execute spMonthlySalaryDistribution {Emp_ID},{date_str}");
                    return "Success";
                }
                else
                {
                    return "failure";
                }
            }
            //throw new NotImplementedException();
        }

        

        public string insertEmployee(Employee empObj)
        {
            if (empObj != null)
            {
                _context.Database.ExecuteSql($"execute spMasterProcedure {empObj.Emp_Id},{empObj.Emp_Name},{empObj.Annual_salary},{empObj.E_Dept_Id},{Action = "insert"}");
                return "success";

            }
            else
            {
                return null;
            }
           
            //throw new NotImplementedException();
        }

        

        public string updateEmployee(Employee empObj)
        {
            var data = _context.employees.Where(x => x.Emp_Id == empObj.Emp_Id).FirstOrDefault();
            if (data == null)
            {
                return null;
            }
            else
            {
                _context.Database.ExecuteSql($"execute spMasterProcedure {empObj.Emp_Id},{empObj.Emp_Name},{empObj.Annual_salary},{empObj.E_Dept_Id},{Action = "update"}");
                return "success";
            }
            
            //throw new NotImplementedException();
        }

        public bool checkEmpinAttendace(int id)
        {
            var data = _context.entries.Where(x => x.Emp_Id == id).FirstOrDefault();
            if (data == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool checkdateinAttendace(DateTime Date)
        {
            //string test = Date.ToString("dd/MM/yyyy HH:mm");
            //DateTime enteredDate = DateTime.Parse(test);
            var data = _context.entries.Where(x => x.Check_In_Time == Date).FirstOrDefault();
            if (data == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Employee> getAllEmployees()
        {
            var list = _context.employees.ToList();
            return list;
        }

        public List<Attendance> getempAttendancebyid(int id)
        {
            var data = _context.entries.Where(x => x.Emp_Id == id).ToList();
            return data;
        }
    }
}
