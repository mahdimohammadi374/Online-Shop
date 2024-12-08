﻿namespace Domain.Entities.Base;

public class BaseAuditableEntity : BaseEntity
{
    public DateTime CreateTime { get; set; }
    public long CreatedBy { get; set; }
    public DateTime? LastModifiedTime { get; set; }
    public long? LastModifiedBy { get; set; }
}