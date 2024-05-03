namespace CourseProject001;

class Program
{
    private static Guests guests;
    private static List<Reservation> reservations;
    private static List<GuestReservation> guestReservations;
    private static Guest authenticatedGuest;

    static void Main(string[] args)
    {
        Console.WriteLine("Initializing...");
        Initialize();
        Menu();
    }

    static void Initialize()
    {
        var c1 = new Guest
        {
            FirstName = "Chad",
            LastName = "LaBore",
            Username = "clab",
            Password = "1234"
        };

        var c2 = new Guest
        {
            FirstName = "first",
            LastName = "last",
            Username = "username",
            Password = "password"
        };

        var a1 = new Reservation();
        var a2 = new Reservation();
        var a3 = new Reservation();

        var ca1 = new GuestReservation(c1, a1);
        var ca2 = new GuestReservation(c1, a2);
        var ca3 = new GuestReservation(c2, a3);

        guests = new Guests();
        guests.guestList.Add(c1);
        guests.guestList.Add(c2);

        guestReservations = new List<GuestReservation>();
        guestReservations.Add(ca1);
        guestReservations.Add(ca2);
        guestReservations.Add(ca3);

        reservations = new List<Reservation>();
        reservations.Add(a1);
        reservations.Add(a2);
        reservations.Add(a3);

    }

    static void Menu()
    {
        bool done = false;

        while (!done)
        {
            Console.WriteLine("Options: Login: 1, Logout: 2, Sign Up: 3, Reservations: 4, Quit: q");
            Console.Write("Choice: ");
            string choice = Console.ReadLine();

            switch(choice)
            {
                case "1":
                    LoginMenu();
                    break;
                case "2":
                    LogOutMenu();
                    break;
                case "3":
                    SignUpMenu();
                    break;
                case "4":
                    AppointmentsMenu();
                    break;
                case "q":
                    done = true;
                    break;
                default:
                    Console.WriteLine("Invalid command!");
                    break;
            }

        }


    }

    static void LoginMenu()
    {
        if(authenticatedGuest == null)
        {
            Console.Write("Enter your username: ");
            string username = Console.ReadLine();
            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            authenticatedGuest = guests.Authenticate(username, password);
            if (authenticatedGuest != null)
            {
                Console.WriteLine($"Welcome {authenticatedGuest.FirstName}");
            }
            else
            {
                Console.WriteLine("Invalid username or password");
            }
        }


    }

    static void LogOutMenu()
    {
        authenticatedGuest = null;
        Console.WriteLine("Logged out!");
    }

    static void SignUpMenu()
    {
        Console.Write("First Name: ");
        string firstname = Console.ReadLine();
        Console.Write("Last Name: ");
        string lastname = Console.ReadLine();
        Console.Write("Username: ");
        string username = Console.ReadLine();
        Console.Write("Password: ");
        string password = Console.ReadLine();

        var newGuest = new Guest
        {
            FirstName = firstname,
            LastName = lastname,
            Username = username,
            Password = password
        };
        guests.guestList.Add(newGuest);
        Console.WriteLine("Profile created!");
        
    }

    static void AppointmentsMenu()
    {
        if (authenticatedGuest == null)
        {
            Console.WriteLine("Please log in first!");
            return;
        }

        var reservationList = guestReservations.Where(o => o.c.Username == authenticatedGuest.Username);

        if(reservationList.Count() == 0)
        {
            Console.WriteLine("0 reservations found.");
        }
        else
        {
            foreach(var reservation in reservationList)
            {
                Console.WriteLine(reservation.a.dateTime);
            }
        }
        
    }
}
