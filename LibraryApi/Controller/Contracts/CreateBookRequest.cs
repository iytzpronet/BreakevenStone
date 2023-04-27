namespace LibraryApi.Controller.Request;

public class CreateBookRequest
{
    public string title { get; set; }
    public string ISBN { get; set; }
    public DateTime publishDate { get; set; }
    public int totalPages { get; set; }
    public string authors { get; set; }
}