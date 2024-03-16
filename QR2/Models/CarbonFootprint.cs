using System;
using System.Collections.Generic;

namespace QR2.Models;

public partial class CarbonFootprint
{
    public int CarbonFootprintId { get; set; }

    public int? ProductId { get; set; }

    public DateOnly CalculationDate { get; set; }

    public double Footprint { get; set; }

    public virtual Product? Product { get; set; }
}
