using System;
using System.Collections.Generic;

namespace web_api_base.Models.dbEcommer;

public partial class Order
{
    public int OrderId { get; set; }

    public int UserId { get; set; }

    public string OrderNumber { get; set; } = null!;

    public int StatusId { get; set; }

    public decimal TotalAmount { get; set; }

    public decimal ShippingFee { get; set; }

    public decimal? Discount { get; set; }

    public decimal FinalAmount { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public string PaymentStatus { get; set; } = null!;

    public int ShippingAddressId { get; set; }

    public string? Note { get; set; }

    public DateTime? CreatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();

    public virtual Address ShippingAddress { get; set; } = null!;

    public virtual OrderStatus Status { get; set; } = null!;

    public virtual User User { get; set; } = null!;

    public virtual ICollection<UserCoupon> UserCoupons { get; set; } = new List<UserCoupon>();
}
