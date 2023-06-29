namespace LibraryApi.Controller.Request;

public class CreateBookRequest
{
    public string Title { get; set; }
    public string ISBN { get; set; }
    public DateTime PublishDate { get; set; }
    public int TotalPages { get; set; }
    public string Authors { get; set; }
    public int ExemplaryBooks { get; set; }
}