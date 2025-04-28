using System;
using System.Collections.Generic;

namespace web_api_base.Models.dbEcommer;

public partial class UserCoupon
{
    public int UserCouponId { get; set; }

    public int UserId { get; set; }

    public int CouponId { get; set; }

    public bool? IsUsed { get; set; }

    public DateTime? UsedAt { get; set; }

    public int? OrderId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual Coupon Coupon { get; set; } = null!;

    public virtual Order? Order { get; set; }

    public virtual User User { get; set; } = null!;
}
