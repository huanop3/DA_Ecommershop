﻿using System;
using System.Collections.Generic;

namespace web_api_base.Models.dbEcommer;

public partial class UserRole
{
    public int UserRoleId { get; set; }

    public int UserId { get; set; }

    public int RoleId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
