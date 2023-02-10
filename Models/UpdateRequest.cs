namespace UniversityApp.Models;

public class UpdateRequest
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? User { get; set; }
    public string? Password { get; set; }
    public string? Nickname { get; set; }
    public string? Phone { get; set; }

}