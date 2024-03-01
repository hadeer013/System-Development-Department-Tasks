using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementAreaProj.Areas.Admin.Models
{
	public class Employee
	{
		public int EmployeeID { get; set; }
		public string Name { get; set; }
		public string Password { get; set; }
		public double Salary { get; set; }
		public DateOnly JoinDate { get; set; }
		public string Email { get; set; }
		public int PhoneNum { get; set; }

		[ForeignKey("Department")]
		public int DepartmentId {  get; set; }
		public virtual Department Department { get; set; }

	}
}
