using System;
using System.Collections.Generic;

namespace web_api_base.Models.dbEcommer;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
