using System;
using System.Collections.Generic;

namespace QR2.Models;

public partial class UserAccount
{
    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;
}
