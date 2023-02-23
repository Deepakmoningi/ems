using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Models
{
    public class MonthlySlaryDistribution
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int E_Id_Indexer { get; set; }
        public int E_Id { get; set; }

        public int D_Id { get; set; }
        public string? E_Name { get; set; }
        public double basic_pay { get; set; }
        public double hra { get; set; }
        public double ma { get; set; }
        public double ppf { get; set; }
        public double IT { get; set; }
        public int Monthly_Salary { get; set; }

        public int Annual_salary { get; set; }

        public DateTime Month_Year { get; set; }

    }
}
