using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement.Models
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public bool IsDeleted { get; set; } = false;

        public List<OrderDetail> OrderDetail { get; set; }
    }
}
