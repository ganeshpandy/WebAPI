using System;
using System.Collections.Generic;

namespace StudentDetails.Models;

public partial class Student
{
    public int Id { get; set; }

    public string? StudName { get; set; }

    public string? Address { get; set; }

    public DateTime? Dob { get; set; }
}
