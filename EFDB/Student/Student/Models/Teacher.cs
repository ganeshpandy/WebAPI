using System;
using System.Collections.Generic;

namespace StudentDetails.Models;

public partial class Teacher
{
    public int? TeacherId { get; set; }

    public string? TeacherName { get; set; }

    public virtual Student? TeacherNavigation { get; set; }
}
