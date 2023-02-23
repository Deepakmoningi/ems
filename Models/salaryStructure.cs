using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class salaryStructure
    {
        [Key]
        public int Dept_Id { get; set; }
        public double basic_pay { get; set; }
        public double hra { get; set; }
        public double ma { get; set; }
        public double ppf { get; set; }
        public double IT { get; set; }
    }
}
