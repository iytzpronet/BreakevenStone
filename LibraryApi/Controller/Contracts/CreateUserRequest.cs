using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controller.Request;

public class CreateUserRequest
{
    public bool Validate()
    {
        return Name.Length >= 3;
    } 
    public string Name { get; set; }
    public string Document { get; set; }
}