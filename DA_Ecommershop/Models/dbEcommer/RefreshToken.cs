using System;
using System.Collections.Generic;

namespace web_api_base.Models.dbEcommer;

public partial class RefreshToken
{
    public int TokenId { get; set; }

    public int UserId { get; set; }

    public int ClientId { get; set; }

    public string Token { get; set; } = null!;

    public string? DeviceName { get; set; }

    public string? DeviceId { get; set; }

    public string? DeviceOs { get; set; }

    public string? Ipaddress { get; set; }

    public DateTime ExpiresAt { get; set; }

    public bool? IsRevoked { get; set; }

    public DateTime? CreatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
