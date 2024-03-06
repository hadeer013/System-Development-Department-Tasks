using Day6Demo_SD44.Models;
using ProductOrderManagement.Helper;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ProductOrderManagement.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string phoneNum { get; set; }
        public ICollection<Order>? Orders { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
