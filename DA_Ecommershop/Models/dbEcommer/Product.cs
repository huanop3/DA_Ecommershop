using System;
using System.Collections.Generic;

namespace web_api_base.Models.dbEcommer;

public partial class Product
{
    public int ProductId { get; set; }

    public int SellerId { get; set; }

    public int CategoryId { get; set; }

    public string ProductName { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public decimal? DiscountPrice { get; set; }

    public int Quantity { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? TotalSold { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();

    public virtual ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();

    public virtual ICollection<ProductVariant> ProductVariants { get; set; } = new List<ProductVariant>();

    public virtual ICollection<PromotionProduct> PromotionProducts { get; set; } = new List<PromotionProduct>();

    public virtual SellerProfile Seller { get; set; } = null!;
}
