using System;
using System.Collections.Generic;

namespace web_api_base.Models.dbEcommer;

public partial class ProductVariant
{
    public int VariantId { get; set; }

    public int ProductId { get; set; }

    public string VariantName { get; set; } = null!;

    public decimal? AdditionalPrice { get; set; }

    public int Quantity { get; set; }

    public DateTime? CreatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual Product Product { get; set; } = null!;
}
