using ProductOrderManagement.ApplicationContext;
using ProductOrderManagement.Models;
using System.ComponentModel.DataAnnotations;

namespace Day6Demo_SD44.Models
{
    public class UniqueEmail : ValidationAttribute
    {
        public UniqueEmail()
        {
            
        }

        protected override ValidationResult? IsValid(object? obj, ValidationContext validationContext)
        {
            if (obj is null)
            {
                return new ValidationResult("Email Can't be Null");
            }
            else
            {
                if (obj is string)
                {
                    string suppliedValue = (string)obj;


                    CustomerOrderContext context = new CustomerOrderContext();
                    bool EmailExist = context.Customers.Any(std => std.Email == suppliedValue
                    && ((Customer)validationContext.ObjectInstance).Id != std.Id);

                    if (EmailExist == false)
                    {
                        return ValidationResult.Success;
                    }
                    else
                    {
                        return new ValidationResult("Email " + suppliedValue + " is Already Taken!!!"); 
                    }
                }
                else
                {
                    return new ValidationResult("Email Should be String Value..."); 
                }
            }
        }
    }
}
