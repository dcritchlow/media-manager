using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace MediaManager.LibraryComponent.Exceptions
{
  [Serializable]
  public class DataNotFoundException : Exception
  {
    public string ResourceReferenceProperty { get; set; }

    public DataNotFoundException()
    {
    }

    public DataNotFoundException(string message)
      : base(message)
    {
    }

    public DataNotFoundException(string message, Exception inner)
      : base(message, inner)
    {
    }

    protected DataNotFoundException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
      ResourceReferenceProperty = info.GetString("ResourceReferenceProperty");
    }

    [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      if(info == null)
        throw new ArgumentNullException(nameof(info));
      info.AddValue("ResourceReferenceProperty", ResourceReferenceProperty);
      base.GetObjectData(info, context);
    }
  }
}