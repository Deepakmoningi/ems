using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class Signup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeSignUp_Id { get; set; }
        public int Emp_Id { get; set; }
        public string? Email { get; set; }

        public string? Password { get; set; }
        public string? Role { get; set; }

    }
}
