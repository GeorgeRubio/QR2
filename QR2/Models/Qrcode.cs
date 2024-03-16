using System;
using System.Collections.Generic;

namespace QR2.Models;

public partial class Qrcode
{
    public int QrcodeId { get; set; }

    public string Code { get; set; } = null!;

    public int? ProductId { get; set; }

    public virtual Product? Product { get; set; }
}
