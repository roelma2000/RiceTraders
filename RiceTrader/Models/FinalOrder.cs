using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RiceTrader.Models
{
    public class FinalOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FinalOrderId { get; set; }

        public int VendorId { get; set; }
        public string VendorName { get; set; } = string.Empty;
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductSize { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Currency { get; set; } = string.Empty;
        public int Quantity { get; set; }

        public int PoId { get; set; }  // Foreign key to PurchaseOrder

        // Navigation property for PurchaseOrder
        public virtual PurchaseOrder? PurchaseOrder { get; set; }
    }
}
