﻿using SchoolSys.Domain.enums;

namespace SchoolSys.Domain.Entities;

public class StudentHistory : BaseEntity
{
    public int StudentId { get; set; }
    public DateTime ChangeDate { get; set; }
    public StudentStatus OldStatus { get; set; }
    public StudentStatus NewStatus { get; set; }
    public string Comment { get; set; }
    public virtual Student Student { get; set; }
}