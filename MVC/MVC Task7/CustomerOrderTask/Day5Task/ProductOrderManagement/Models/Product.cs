using System.ComponentModel.DataAnnotations.Schema;

namespace ProductOrderManagement.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        [ForeignKey("Customer")]
        public int CustID { get; set; }
        public Customer? Customer { get; set; }

    }
}
