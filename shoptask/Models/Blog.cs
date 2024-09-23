using shoptask.Util;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shoptask.Models
{
    public class Blog
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage ="you must enter the name of blog")]

        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public int typeID { get; set; }
        [ForeignKey("typeID")]
        public Typeb? type { get; set; }
    }
}
