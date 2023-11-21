using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace CRUDApi.Entities
{
    public class User
    {
        [Key]
        [Required]
        [StringLength(20)]
        [Column("User",TypeName="varchar")]
        public string? UserId { get; set; }
        [Required]
        [StringLength(30)]
        [Column("UserName", TypeName = "varchar")]
        public string? UserName { get; set; }
        [Required]
        [StringLength(20)]
        public string? UserEmail { get; set; }

        [Required]
        public string? Password { get; set; }

        public string? Role { get; set; }
        
        


    }
}
