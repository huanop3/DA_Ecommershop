using System;
using System.Collections.Generic;

namespace web_api_base.Models.dbEcommer;

public partial class ProductImage
{
    public int ImageId { get; set; }

    public int ProductId { get; set; }

    public string ImageUrl { get; set; } = null!;

    public bool? IsDefault { get; set; }

    public DateTime? CreatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual Product Product { get; set; } = null!;
}
