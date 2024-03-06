using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductOrderManagement.Models.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
        [Required]
        public int CustID { get; set; }
    }
}
