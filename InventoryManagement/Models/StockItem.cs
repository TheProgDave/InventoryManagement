using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement.Models
{
    [Table("StockItem")]
    public class StockItem
    {
        [Key]
        public int ProductId { get; set; }
        
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public required string Description { get; set; }

        [Display(Name = "Stock Amount")]
        public int StockAmount { get; set; }

        [Display(Name = "Safe Stock Amount")]
        public int SafeStockAmount { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
    }
}