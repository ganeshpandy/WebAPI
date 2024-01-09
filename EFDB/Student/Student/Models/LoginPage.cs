using System;
using System.Collections.Generic;

namespace StudentDetails.Models;

public partial class LoginPage
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public long? Phno { get; set; }
}
