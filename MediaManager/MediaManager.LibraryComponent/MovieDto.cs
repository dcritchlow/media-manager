using System.Collections.Generic;

namespace MediaManager.LibraryComponent
{
  public class MovieDto
  {
    public Format Format { get; set; }
    public string Title { get; set; }
    public string Year { get; set; }
    public string ImdbId { get; set; }
    public ICollection<string> Owners { get; set; }
    public string IntendToBuy { get; set; }
  }
}