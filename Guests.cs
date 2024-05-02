namespace CourseProject001;

    public class Guests
    {
        public List<Guest> guests { get; set; }

        public Guests()
        {
            guests = new List<Guest>();
        }

        public Guest Authenticate(string username, string password)
        {
            var c = guestsList.Where(o => (o.Username == username) && (o.Password == password));

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
