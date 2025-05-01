using Library;
using System;
using System.Threading.Channels;
using Library;

public static class ValueEventHandler
{
    static MemberRepo members = new();
    public static BoatRepo boatRepo1 = new BoatRepo();
    static BlogRepo blogs = new BlogRepo();
    static EventRepo events = new EventRepo();
    static BookingRepo bookings = new BookingRepo();
    //Handles logic for the values of the user input after key "List"/"se" is chosen to print out our lists of objects
    public static void KeyList(string value)
    {
        switch (value)
        {
            case "medlemmer":
                foreach (Member member in members.GetMembers())
                {
                    member.ToString();
                }
                break;
            case "både":
                foreach (Boat boat in boatRepo1.GetBoats())
                {
                    boat.ToString();
                }
                break;
            case "blogs":
                foreach (Blog blog in blogs.GetBlogs())
                {
                    blog.ToString();
                }
                break;
            case "begivenheder":
                foreach (Event e in events.GetEvents())
                {
                    e.ToString();
                }
                break;
            case "bookings":
                foreach (Booking booking in bookings.GetBookings())
                {
                    booking.ToString();
                }
                break;
        }
    }

    public static void KeyNew(string value)
    {
        switch (value.ToLower())
        {
            case "båd":
                CreateNewBoat();
                break;

            case "medlem":

                break;

            case "begivenhed":

                break;

            case "blog":

                break;
            case "reservartion":

                break;
        }
    }
    private static void CreateNewBoat()
    {
        Console.WriteLine("Navn");
        string name = Console.ReadLine();
        Console.WriteLine("Model");
        string model = Console.ReadLine();
        Console.WriteLine("Båd type");
        string type = Console.ReadLine();
        Console.WriteLine("Sejlnummer");
        int sailingNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("Byggeår");
        int year = int.Parse(Console.ReadLine());
        Console.WriteLine("Måned");
        int month = int.Parse(Console.ReadLine());
        Console.WriteLine("Dag");
        int day = int.Parse(Console.ReadLine());
        Console.WriteLine("Motornummer");
        string motorInformation = Console.ReadLine();
        Console.WriteLine("Længde");
        int measurement = int.Parse(Console.ReadLine());
        Console.WriteLine("Certificat krav\nLille båd = 1\nMellem båd = 2\nStor båd = 3");
        int minmumCertificationRequirement = int.Parse(Console.ReadLine());

        Boat boat1 = new Boat(name, model, type, new(year, month, day), sailingNumber, motorInformation, measurement, minmumCertificationRequirement);
    }
    public static void KeyDelete(string value)
    {
        switch (value)
        {

        }
    }
}