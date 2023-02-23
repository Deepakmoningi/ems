using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Data
{
    public class EmpDbContext:DbContext
    {
        public EmpDbContext(DbContextOptions<EmpDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> employees { get; set; }

        public DbSet<salaryStructure> structure { get; set; }

        public DbSet<MonthlySlaryDistribution> distributions { get; set; }

        public DbSet<Attendance> entries { get; set; }

        public DbSet<AttendaceDTO> attendaceDTOs { get; set; }

        public DbSet<Signup> signups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("tbl_employee");

            modelBuilder.Entity<salaryStructure>().ToTable("tbl_salary_structure");

            modelBuilder.Entity<MonthlySlaryDistribution>().ToTable("tbl_monthly_salary_distribution");

            modelBuilder.Entity<Attendance>().ToTable("tbl_attendancetracker");

            modelBuilder.Entity<Signup>().ToTable("tbl_empSignups");

        }
    }
}
