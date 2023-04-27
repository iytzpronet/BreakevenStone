namespace LibraryApi.Entity;

public class Book
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string ISBN { get; set; }
    public DateTime PublishDate { get; set; }
    public int TotalPages { get; set; }
    public string Authors { get; set; }
}
