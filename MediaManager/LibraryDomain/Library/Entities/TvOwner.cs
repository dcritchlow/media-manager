namespace MediaManager.Domain.Library.Entities
{
  public class TvOwner
  {
    public virtual TvShow TvShow { get; set; }
    public virtual Owner Owner { get; set; }
  }
}