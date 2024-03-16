using System;
using System.Collections.Generic;

namespace QR2.Models;

public partial class CarbonFootprintAudit
{
    public int AuditId { get; set; }

    public int? ProductId { get; set; }

    public double? PreviousFootprint { get; set; }

    public double? NewFootprint { get; set; }

    public string Action { get; set; } = null!;

    public DateTime AuditDate { get; set; }

    public int? UserId { get; set; }

    public virtual Product? Product { get; set; }
}
