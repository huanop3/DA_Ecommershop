using System;
using System.Collections.Generic;

namespace web_api_base.Models.dbEcommer;

public partial class OrderItem
{
    public int OrderItemId { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public int? VariantId { get; set; }

    public int SellerId { get; set; }

    public string ProductName { get; set; } = null!;

    public string? VariantName { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal FinalPrice { get; set; }

    public DateTime? CreatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual SellerProfile Seller { get; set; } = null!;

    public virtual ProductVariant? Variant { get; set; }
}
