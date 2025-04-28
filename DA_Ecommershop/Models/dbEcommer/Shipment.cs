using System;
using System.Collections.Generic;

namespace web_api_base.Models.dbEcommer;

public partial class Shipment
{
    public int ShipmentId { get; set; }

    public int OrderId { get; set; }

    public int? ShipperId { get; set; }

    public string? TrackingNumber { get; set; }

    public string ShipmentStatus { get; set; } = null!;

    public DateTime? EstimatedDeliveryDate { get; set; }

    public DateTime? ActualDeliveryDate { get; set; }

    public DateTime? CreatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual ShipperProfile? Shipper { get; set; }
}
