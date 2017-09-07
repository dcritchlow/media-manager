using System;

namespace MediaManager.SharedKernel
{
  public sealed class AuditInfo
  {
    public DateTime? CreatedAt { get; private set; }
    public DateTime? ModifiedAt { get; private set; }
    public string CreatedBy { get; private set; }
    public string ModifiedBy { get; private set; }

    public static AuditInfo CreateNew(string userId)
    {
      var newAuditInfo = new AuditInfo
      {
        CreatedAt = DateTime.Now,
        CreatedBy = userId,
        ModifiedAt = null,
        ModifiedBy = null
      };

      return newAuditInfo;
    }

    public static AuditInfo Modify(string userId, AuditInfo oldAuditInfo)
    {
      var newAuditInfo = new AuditInfo
      {
        CreatedAt = oldAuditInfo.CreatedAt,
        CreatedBy = oldAuditInfo.CreatedBy,
        ModifiedAt = DateTime.Now,
        ModifiedBy = userId
      };

      return newAuditInfo;
    }
  }
}