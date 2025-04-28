using System;
using System.Collections.Generic;

namespace web_api_base.Models.dbEcommer;

public partial class SellerProfile
{
    public int SellerId { get; set; }

    public int UserId { get; set; }

    public string ShopName { get; set; } = null!;

    public string? Description { get; set; }

    public bool? IsVerified { get; set; }

    public decimal? Rating { get; set; }

    public DateTime? CreatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual User User { get; set; } = null!;
}
