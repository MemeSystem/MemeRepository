namespace MemeSystem.Entities;

public class User
{
    public string Email { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Photo { get; set; } = null!;

    public override string ToString() =>
        $"{Email};{UserName};{Password};{FullName};{Description};{Photo};";
}