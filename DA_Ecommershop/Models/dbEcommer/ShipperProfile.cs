using System;
using System.Collections.Generic;

namespace web_api_base.Models.dbEcommer;

public partial class ShipperProfile
{
    public int ShipperId { get; set; }

    public int UserId { get; set; }

    public string? VehicleType { get; set; }

    public bool? IsAvailable { get; set; }

    public DateTime? CreatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();

    public virtual User User { get; set; } = null!;
}
