using System;
using System.Collections.Generic;
using QR2.Models;

namespace QR2.Utilities;

public partial class Qrcode
{
    public int QrcodeId { get; set; }

    public string Code { get; set; } = null!;

    public int? ProductId { get; set; }

    public virtual Product? Product { get; set; }
}
