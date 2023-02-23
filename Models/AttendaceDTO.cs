using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class AttendaceDTO
    {
        [Key]
        public int Emp_Id { get; set; }
        public DateTime Check_In_Time { get; set; }
        public DateTime Check_Out_Time { get; set; }
    }
}
