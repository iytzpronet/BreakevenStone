namespace LibraryApi.Entity;

public class Book
{
    public Guid Id { get; set; }
    public string title { get; set; }
    public string ISBN { get; set; }
    public DateTime publishDate { get; set; }
    public int totalPages { get; set; }
    public string authors { get; set; }
}
