using EmployeeManagementAreaProj.Areas.Admin.Models;
using EmployeeManagementAreaProj.Areas.Finance.Models;
using EmployeeManagementAreaProj.Areas.HR.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAreaProj.ApplicationContext
{
	public class EmployeeManagementContext : DbContext
	{
		public EmployeeManagementContext(DbContextOptions options) : base(options)
		{
		}

		public EmployeeManagementContext() : base()
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=DESKTOP-0054Q2J\\SQLEXPRESS;database=EmployeeManagementmvcDay4;trusted_connection=true;MultipleActiveResultSets=true;TrustServerCertificate=True;");
			base.OnConfiguring(optionsBuilder);
		}
		public virtual DbSet<Employee> Employees { get; set; }
		public virtual DbSet<Department> Departments { get; set; }	
		public virtual DbSet<HRDept> HRDepts { get; set; }
		public virtual DbSet<FinancialSector> FinancialSectors { get; set; }
	}
}
