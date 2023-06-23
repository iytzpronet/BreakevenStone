namespace LibraryApi.Entity;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Document { get; set; }

    public User()
    {
        Id = Guid.NewGuid();
    }
}
