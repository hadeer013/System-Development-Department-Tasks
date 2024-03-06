using System.ComponentModel.DataAnnotations.Schema;

namespace ProductOrderManagement.Models.ViewModels
{
	public class AddProductVM
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Price { get; set; }
		public string Description { get; set; }
		public IFormFile? Image { get; set; }

		public int CustID { get; set; }
	}
}
