using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RiceTrader.Models
{
    public class PurchaseOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PoId { get; set; }

        [DataType(DataType.Date)]
        public string OrderDate { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalPrice { get; set; }

        public string Currency { get; set; } = "CAD";

        // Navigation property for FinalOrders
        public virtual ICollection<FinalOrder> FinalOrders { get; set; } = new HashSet<FinalOrder>();
    }

}
