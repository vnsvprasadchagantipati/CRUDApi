using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CRUDApi.Entities
{
    public class Item
    {
        [Key]
        [Required]
        [StringLength(20)]
        public string? ItemCode { get; set; }
        [Required]
        [StringLength(20)]
        public string? ItemDesc { get; set;}
        
        [Required]
        public double? ItemRate {  get; set; }
        [Required]
        

        public string? SuplId { get; set;}
        [ForeignKey("SuplId")]
        public Supplier? Supplier { get; set; }
    }
}
