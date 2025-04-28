using System;
using System.Collections.Generic;

namespace web_api_base.Models.dbEcommer;

public partial class Promotion
{
    public int PromotionId { get; set; }

    public string PromotionName { get; set; } = null!;

    public string? Description { get; set; }

    public string DiscountType { get; set; } = null!;

    public decimal DiscountValue { get; set; }

    public decimal? MinOrderValue { get; set; }

    public decimal? MaxDiscountAmount { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public bool? IsActive { get; set; }

    public bool? ApplyToAllProducts { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<PromotionProduct> PromotionProducts { get; set; } = new List<PromotionProduct>();
}
