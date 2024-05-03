namespace CourseProject001;

public class Guest
{
    private static int autoIncrement;
    public int Id { get; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Guest()
    {
        autoIncrement++;
        Id = autoIncrement;
    }



}