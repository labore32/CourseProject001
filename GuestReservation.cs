﻿namespace CourseProject001;

public class GuestReservation
{
    public Guest c {get; set;}
    public Reservation a {get; set;}

    public GuestReservation(Guest c, Reservation a)
    {
        this.c = c;
        this.a = a;
    }

}
