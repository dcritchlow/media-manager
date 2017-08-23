namespace MediaManager.Domain.Library.Entities
{
  public class MovieOwner
  {
    public virtual Movie Movie { get; set; }
    public virtual Owner Owner { get; set; }
  }
}