using shoptask.Util;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace shoptask.Models.DTO
{
    public class ProductDTO
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "you must enter the name of product")]
        [DeniedValues("AAA", "BBB")]
        [Length(1, 10)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        //[Required]
        //public int Quantity { get; set; }
        [Required]
        [Range(1000, 10000)]
        public float Price { get; set; }
        //public bool EnableSize { get; set; }
        [Required]
        public int companyID { get; set; }
        public Company? company { get; set; }
    }
}
