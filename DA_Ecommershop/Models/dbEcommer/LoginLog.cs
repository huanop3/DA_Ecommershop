using System;
using System.Collections.Generic;

namespace web_api_base.Models.dbEcommer;

public partial class LoginLog
{
    public int LogId { get; set; }

    public int UserId { get; set; }

    public int? ClientId { get; set; }

    public string? Username { get; set; }

    public string? Ipaddress { get; set; }

    public DateTime? LoginTime { get; set; }

    public bool? IsSuccessful { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Client? Client { get; set; }

    public virtual User User { get; set; } = null!;
}
