namespace MediaManager.LibraryComponent
{
  public class MovieInformationDto
  {
    public string Title { get; set; }
    public string Released { get; set; }
    public string Year { get; set; }
    public string Rated { get; set; }
    public string Plot { get; set; }
    public string Response { get; set; }
    public string Error { get; set; }
    public string Poster { get; set; }
    public string imdbID { set; get; }
    public Format Format { get; set; }
    public bool Valid { get; set; }
    public string OriginalTitle { get; set; }
  }
}