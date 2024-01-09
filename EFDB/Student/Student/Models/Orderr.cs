using System;
using System.Collections.Generic;

namespace StudentDetails.Models;

public partial class Orderr
{
    public long? OrderId { get; set; }

    public string? CustomerName { get; set; }

    public string? OrderName { get; set; }

    public DateTime? OrderDate { get; set; }

    public int? Phno { get; set; }
}
