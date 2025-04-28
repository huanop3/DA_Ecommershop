using System;
using System.Collections.Generic;

namespace web_api_base.Models.dbEcommer;

public partial class PromotionProduct
{
    public int PromotionProductId { get; set; }

    public int PromotionId { get; set; }

    public int ProductId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Promotion Promotion { get; set; } = null!;
}
