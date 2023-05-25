using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controller.Request;

public class CreateUserRequest
{
    public bool validate ()
    {
        if (Name.Length < 3)
            return false;
        return true;
    } 
    public string Name { get; set; }
    public string Document { get; set; }
}