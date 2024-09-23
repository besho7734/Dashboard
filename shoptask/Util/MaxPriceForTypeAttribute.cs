using shoptask.Models;
using System.ComponentModel.DataAnnotations;

namespace shoptask.Util
{
    public class MaxPriceForTypeAttribute : ValidationAttribute
    {
        private readonly int _maxPrice;
        public MaxPriceForTypeAttribute(int price)
        {
            _maxPrice = price;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            Blog b = (Blog)validationContext.ObjectInstance;
            int price;
            if(!int.TryParse(value.ToString(),out price))
            {
                return new ValidationResult("enter int value");
            }
            else if (b.typeID == 1 && price > _maxPrice)
            {
                return new ValidationResult("comedy proce less than "+_maxPrice.ToString());
            }
            return ValidationResult.Success;
        }
    }
}
