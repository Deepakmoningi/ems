using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        [Key]
        public int Emp_Id { get; set; }

        public string? Emp_Name { get; set; }

        public int Annual_salary { get; set; }
        public int E_Dept_Id { get; set; }

    }
}
