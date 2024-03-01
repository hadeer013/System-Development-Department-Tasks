namespace EmployeeManagementAreaProj.Areas.Admin.Models
{
	public class Department
	{
		public int DepartmentId { get; set; }	
		public string Name { get; set; }	
		public string Description { get; set; }	
		public virtual ICollection<Employee> Employees { get; set; }=new HashSet<Employee>();

	}
}
