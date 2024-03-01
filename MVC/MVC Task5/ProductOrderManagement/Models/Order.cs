using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductOrderManagement.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }


        [ForeignKey("Customer")]
        public int CustID { get; set; }
        public Customer Customer { get; set; }
        
    }
}
