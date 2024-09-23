using shoptask.Util;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shoptask.Models
{
    public class Product
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required (ErrorMessage ="you must enter the name of product")]
        [DeniedValues("AAA","BBB")]
        [Length(1,10)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        [Range(1000,10000)]
        [MaxPriceForComany(3000)]
        public float Price { get; set; }
        public bool EnableSize { get; set; }
        [Required]
        public int companyID { get; set; }
        [ForeignKey("companyID")]
        public Company? company { get; set; }
    }
}
