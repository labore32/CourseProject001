namespace CourseProject001;

public class Reservation
{
    
    private static int autoIncrement;
    public int Id {get;}
    public DateTime dateTime {get; set;}

    public Reservation()
    {
        autoIncrement++;
        Id = autoIncrement;
    }


}
