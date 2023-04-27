namespace LibraryApi.Entity;

public class User
{
    public Guid Id { get; private set; }
    public string name { get; set; }
    public string document { get; set; }

    public User()
    {
        Id = Guid.NewGuid();
    }
}
