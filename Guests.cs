namespace CourseProject001;

    public class Guests
    {
        public List<Guest> guestList { get; set; }

        public Guests()
        {
            guestList = new List<Guest>();
        }

        public Guest Authenticate(string username, string password)
        {
            var c = guestList.Where(o => (o.Username == username) && (o.Password == password));

            if(c.Count() > 0)
            {
                return c.First();
            }
            else
            {
                return null;
            }
        }
    }
