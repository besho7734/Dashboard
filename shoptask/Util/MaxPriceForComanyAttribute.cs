using shoptask.Models;
using System.ComponentModel.DataAnnotations;

namespace shoptask.Util
{
    public class MaxPriceForComanyAttribute : ValidationAttribute
    {
        private readonly int _maxPrice;
        public MaxPriceForComanyAttribute(int price)
        {
            _maxPrice= price;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            Product p=(Product)validationContext.ObjectInstance;
            int price;
            if(!int.TryParse(value.ToString(),out price))
            {
                return new ValidationResult("enter int value");
            }
            if (p.companyID == 1 && price > _maxPrice)
            {
                return new ValidationResult("Niki price less than"+ _maxPrice.ToString());
            }
            return ValidationResult.Success;
        }
    }
}
