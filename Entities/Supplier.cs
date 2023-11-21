using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDApi.Entities
{
    public class Supplier
    {
        [Key]
        [Required]
        [StringLength(20)]
        public string? SuplNo { get; set; }
        [Required]
        [StringLength(20)]  
        public string? SuplName { get; set; }
       
        [Required]
       
        public string? SuplAddress { get; set; }
        [Required]
        public  string? UserId { get; set; }

        [ForeignKey("UserId")]
       public User? User { get; set; }
    }
}
