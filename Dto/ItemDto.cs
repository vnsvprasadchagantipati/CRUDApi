using System.ComponentModel.DataAnnotations;

namespace CRUDApi.Dto
{
    public class ItemDto
    {
        public string? ItemCode { get; set; }
       
        public string? ItemDesc { get; set; }

        
        public double? ItemRate { get; set; }
    
        public string? SuplId { get; set; }
    }
}
