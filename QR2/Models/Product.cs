using System;
using System.Collections.Generic;

namespace QR2.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public int? CompanyId { get; set; }

    public virtual ICollection<CarbonFootprintAudit> CarbonFootprintAudits { get; set; } = new List<CarbonFootprintAudit>();

    public virtual ICollection<CarbonFootprint> CarbonFootprints { get; set; } = new List<CarbonFootprint>();

    public virtual Company? Company { get; set; }

    public virtual ICollection<Qrcode> Qrcodes { get; set; } = new List<Qrcode>();
}
