using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class Attendance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Attendance_Id { get; set; }
        public int Emp_Id { get; set; }
        public DateTime Check_In_Time { get; set; }
        public DateTime Check_Out_Time { get; set; }
        public int working_Hours { get; set; }
    }
}
