using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CRUDApi.Dto
{
    public class UserDto
    {
        public string? UserId { get; set; }
        
        public string? UserName { get; set; }
        
        public string? UserEmail { get; set; }

       
        public string? Password { get; set; }

        public string? Role { get; set; }
    }
}
