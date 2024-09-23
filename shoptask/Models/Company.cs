using System.ComponentModel.DataAnnotations;

namespace shoptask.Models
{
    public class Company
    {
        [Required]
        public string Name { get; set; }
        [Key]
        public int Id { get; set; }
    }
}
