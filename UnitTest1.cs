using EmployeeManagement.Controllers;
using EmployeeManagement.Models;
using EmployeeManagement.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace EmployeeTest
{
    public class Tests
    {
        private EmpController controllerObj;
        private Mock<IEmployeeRepo> _repo;
        [SetUp]
        public void Setup()
        {
            _repo = new Mock<IEmployeeRepo>();
            controllerObj = new EmpController(_repo.Object);
            
        }
        [Test]
        public void EmployeeInsertSuccess()
        {
            Employee empObj = new Employee(){
                Emp_Id = 123,
                Emp_Name = "Qwerty",
                Annual_salary = 450000,
                E_Dept_Id = 1
            };
            _repo.Setup(p => p.insertEmployee(empObj)).Returns("success");
            var result = controllerObj.insertEmployee(empObj) as ObjectResult;
            Assert.AreEqual(200, result.StatusCode);
        }
        [Test]
        public void EmployeeInsertFailure()
        {
            Employee empObj = new Employee();
            string expected = null;
            _repo.Setup(p => p.insertEmployee(empObj)).Returns(expected);
            var result = controllerObj.insertEmployee(empObj) as BadRequestResult;
            Assert.AreEqual(400,result.StatusCode);
        }

        [Test]
        public void EmployeeupdateSuccess()
        {
            Employee empObj = new Employee()
            {
                Emp_Id = 12,
                Emp_Name = "Qwert",
                Annual_salary = 45000,
                E_Dept_Id = 1
            };
            _repo.Setup(p => p.updateEmployee(empObj)).Returns("success");
            var result = controllerObj.updateEmployee(empObj) as ObjectResult;
            Assert.AreEqual(200, result.StatusCode);
        }
        [Test]
        public void EmployeeUpdateFailure()
        {
            Employee empObj = new Employee();
            string expected = null;
            _repo.Setup(p => p.updateEmployee(empObj)).Returns(expected);
            var result = controllerObj.updateEmployee(empObj) as ObjectResult;
            Assert.AreEqual(400, result.StatusCode);
        }

        [Test]
        public void EmployeeDeleteSuccess()
        {
            int id=123;
            _repo.Setup(p => p.deleteEmployee(id)).Returns("success");
            var result = controllerObj.deleteEmployee(id) as ObjectResult;
            Assert.AreEqual(200, result.StatusCode);
        }
        [Test]
        public void EmployeeDeleteFailure()
        {
            int id=123;
            string expected = null;
            _repo.Setup(p => p.deleteEmployee(id)).Returns(expected);
            var result = controllerObj.deleteEmployee(id) as ObjectResult;
            Assert.AreEqual(400, result.StatusCode);
        }

        [Test]
        public void GetAllEmployeeSuccess()
        {
            List<Employee> empDataList = new List<Employee>() { new Employee { Emp_Id = 12,Emp_Name = "Qwerty",Annual_salary = 45000,E_Dept_Id = 1} };
            _repo.Setup(p => p.getAllEmployees()).Returns(empDataList);
            var result = controllerObj.getEmployees();
            int resultCount = result.Count;
            Assert.AreEqual(1,resultCount);
        }
        [Test]
        public void GetAllEmployeeFailure()
        {
            List<Employee> emptyList = new List<Employee>();
            _repo.Setup(p => p.getAllEmployees()).Returns(emptyList);
            var result = controllerObj.getEmployees();
            int resultCount = result.Count;
            Assert.AreEqual(0, resultCount);
        }

        [Test]
        public void GetEmployeeByIdSuccess()
        {
            int id = 123;
            List<Employee> empDataList = new List<Employee>() { new Employee { Emp_Id = 12, Emp_Name = "Qwerty", Annual_salary = 45000, E_Dept_Id = 1 } };
            _repo.Setup(p => p.getEmployeebyId(id)).Returns(empDataList);
            var result = controllerObj.getEmployee(id);
            int resultCount = result.Count;
            Assert.AreEqual(1, resultCount);
        }
        [Test]
        public void GetEmployeeByIdFailure()
        {
            int id = 123;
            List<Employee> emptyList = new List<Employee>();
            _repo.Setup(p => p.getEmployeebyId(id)).Returns(emptyList);
            var result = controllerObj.getEmployee(id);
            int resultCount = result.Count;
            Assert.AreEqual(0, resultCount);
        }

        [Test]
        public void GetMonthlySalarybyIdSuccess()
        {
            SalaryDTO myObj = new SalaryDTO()
            {
                Emp_ID = 123,
                month_year = new DateTime()
            };
            List<MonthlySlaryDistribution> empSalaryList = new List<MonthlySlaryDistribution>() { new MonthlySlaryDistribution { E_Id_Indexer = 1, E_Id = 1, D_Id = 1, E_Name = "qwerty", basic_pay=10, hra=10, ma=10, ppf=10, IT=10, Monthly_Salary=100, Annual_salary=1000, Month_Year =new DateTime()} };
            _repo.Setup(p => p.GetMonthlySalarybyId(myObj)).Returns(empSalaryList);
            var result = controllerObj.GetMonthlySalarybyId(myObj);
            int resultCount = result.Count;
            Assert.AreEqual(1, resultCount);
        }
        [Test]
        public void GetMonthlySalarybyIdFailure()
        {
            SalaryDTO myObj = new SalaryDTO();
            List<MonthlySlaryDistribution> emptyList = new List<MonthlySlaryDistribution>();
            _repo.Setup(p => p.GetMonthlySalarybyId(myObj)).Returns(emptyList);
            var result = controllerObj.GetMonthlySalarybyId(myObj);
            int resultCount = result.Count;
            Assert.AreEqual(0, resultCount);
        }

        [Test]
        public void GetAttendancebyIdSuccess()
        {
            int id = 123;
            List<Attendance> empAttendanceList = new List<Attendance>() { new Attendance { Attendance_Id = 1, Emp_Id = 1, Check_In_Time = new DateTime(), Check_Out_Time = new DateTime(), working_Hours=10 } };
            _repo.Setup(p => p.getempAttendancebyid(id)).Returns(empAttendanceList);
            var result = controllerObj.getAttendance(id);
            int resultCount = result.Count;
            Assert.AreEqual(1, resultCount);
        }
        [Test]
        public void GetAttendanceIdFailure()
        {
            int id = 123;
            List<Attendance> emptyList = new List<Attendance>();
            _repo.Setup(p => p.getempAttendancebyid(id)).Returns(emptyList);
            var result = controllerObj.getAttendance(id);
            int resultCount = result.Count;
            Assert.AreEqual(0, resultCount);
        }

        [Test]
        public void calculateWorkingHoursSuccess()
        {
            AttendaceDTO myObj = new AttendaceDTO()
            {
                Emp_Id = 1,
                Check_In_Time = new DateTime(),
               Check_Out_Time = new DateTime()
            };
            List<Attendance> empAttendanceList = new List<Attendance>() { new Attendance { Attendance_Id = 1, Emp_Id = 1, Check_In_Time = new DateTime(), Check_Out_Time = new DateTime(), working_Hours = 10 } };
            _repo.Setup(p => p.calculateWorkingHours(myObj)).Returns(empAttendanceList);
            var result = controllerObj.calculateWorkingHours(myObj) as ObjectResult;
            Assert.AreEqual(200, result.StatusCode);
        }
        [Test]
        public void calculateWorkingHoursFailure()
        {
            AttendaceDTO myObj = new AttendaceDTO();
            List<Attendance> emptyList = new List<Attendance>();
            _repo.Setup(p => p.calculateWorkingHours(myObj)).Returns(emptyList);
            var result = controllerObj.calculateWorkingHours(myObj) as BadRequestResult;
            Assert.AreEqual(null, result);
        
        }
    }
}