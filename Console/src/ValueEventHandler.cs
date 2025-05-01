using System;
using System.Threading.Channels;
using Library;

#nullable disable
public static class ValueEventHandler
{

    public static BoatRepo boatRepo1 = new BoatRepo();
    public static MemberRepo memberRepo1 = new MemberRepo();
    public static EventRepo eventRepo1 = new EventRepo();
    public static BlogRepo blogRepo1 = new BlogRepo();
    public static BookingRepo bookingRepo1 = new BookingRepo();
    

    public static void KeyList(string value)
    {
        switch (value)
        {

        }
    }

    public static void KeyNew(string value)
    {
        switch (value.ToLower())
        {
            case "bÂd":
                CreateNewBoat();
                break;

            case "medlem":
                CreateNewMember();
                break;

            case "begivenhed":
                CreateNewEvent();
                break;

            case "blog":
                CreateNewBlog();
                break;
            case "reservation":
                CreateNewBooking();
                break;
        }
    }

   



    private static void CreateNewBoat()
    {
        Console.WriteLine( "Navn");
        string boatName = Console.ReadLine();
        
        Console.WriteLine("Model");
        string model = Console.ReadLine();
        
        Console.WriteLine("BÂd type");
        string type = Console.ReadLine();
        
        Console.WriteLine("Sejlnummer");
        int sailingNumber = int.Parse(Console.ReadLine());

        Console.WriteLine("ByggeÂr (dd-MM-≈≈≈≈)");
        string creationInput = Console.ReadLine();
        DateOnly creationDateTime = DateOnly.ParseExact(creationInput, "dd-MM-yyyy", null);
       
        Console.WriteLine("Motornummer");
        string motorInformation = Console.ReadLine();
        
        Console.WriteLine("LÊngde");
        int measurement = int.Parse(Console.ReadLine());
        
        Console.WriteLine("Certificat krav\nLille bÂd = 1\nMellem bÂd = 2\nStor bÂd = 3");
        int minmumCertificationRequirement = int.Parse(Console.ReadLine());

        Boat boat1 = new Boat(boatName, model, type, creationDateTime, sailingNumber, motorInformation, measurement, minmumCertificationRequirement);
        boatRepo1.AddBoat(boat1);
    }
    private static void CreateNewMember()
    {
        Console.WriteLine("Navn");
        string Memebername = Console.ReadLine();
        
        Console.WriteLine("Adresse");
        string address = Console.ReadLine();
        
        Console.WriteLine("Telefonnummer");
        string phoneNumber = Console.ReadLine();
        
        Console.WriteLine("Email");
        string email = Console.ReadLine();
        
        Console.WriteLine("Adgangs niveau\nAdmin = 1\nMedlem = 2");
        Member.Acceslevel AccesLevel = (Member.Acceslevel)int.Parse(Console.ReadLine());
        
        Console.WriteLine("Certificat type\nLille bÂd = 1\nMellem bÂd = 2\nStor bÂd = 3");
        Member.BoatSize boatSize = (Member.BoatSize)int.Parse(Console.ReadLine());
        

        Member member1 = new Member(Memebername, address, phoneNumber, email, boatSize, AccesLevel);
        memberRepo1.AddMember(member1);
    }
    private static void CreateNewEvent()
    {
        Console.WriteLine("Navn");
        string eventName = Console.ReadLine();
        
        Console.WriteLine("Indtast start dato og tid (dd-MM-≈≈≈≈ HH:mm)");
        string startInput = Console.ReadLine();
        DateTime startDateTime = DateTime.ParseExact(startInput, "dd-MM-yyyy HH:mm", null);

        Console.WriteLine("Indtast slut dato og tid (dd-MM-≈≈≈≈ HH:mm)");
        string endInput = Console.ReadLine();
        DateTime endDateTime = DateTime.ParseExact(endInput, "dd-MM-yyyy HH:mm", null);

        Console.WriteLine("Event organisator");
        int organisatorId = int.Parse(Console.ReadLine());
        Member eventOrganisator = memberRepo1.FindMemberById(organisatorId);

        Event event1 = new Event(eventName, startDateTime, endDateTime, eventOrganisator);
        eventRepo1.AddEvent(event1);

    }
    private static void CreateNewBlog()
    {
        Console.WriteLine("Navn");
        string blogTitle = Console.ReadLine();

        Console.WriteLine("Indtast oprettelses dato (dd-MM-≈≈≈≈)");
        string creationInput = Console.ReadLine();
        DateOnly creationDateOnly = DateOnly.ParseExact(creationInput, "dd-MM-yyyy", null);

        Console.WriteLine("Beskrivelse");
        string description = Console.ReadLine();

        Console.WriteLine("Skribent");
        string blogWriterName = Console.ReadLine();
        Member blogWriter = memberRepo1.FindMemberById(int.Parse(blogWriterName));

        Console.WriteLine("Event");
        string eventInput = Console.ReadLine();
        Event? blogEvent = null;

        if (!string.IsNullOrEmpty(eventInput))
        {
            int eventId = int.Parse(eventInput);
            blogEvent = eventRepo1.GetEventById(eventId);
        }

        Blog blog1 = new Blog(blogTitle, creationDateOnly, description, blogWriter);

        if (blogEvent != null)
        {
            blog1.RelatedEvent = blogEvent;
        }
        blogRepo1.AddBlog(blog1);
    }
    private static void CreateNewBooking()
    {
        Console.WriteLine("hvilken bÂd vil du booke?");
        int boatId = int.Parse(Console.ReadLine());
        Boat boat = boatRepo1.FindBoatById(boatId);

        Console.WriteLine("Hvem booker bÂden?");
        int memberId = int.Parse(Console.ReadLine());
        Member member = memberRepo1.FindMemberById(memberId); 

        Console.WriteLine("HvornÂr vil du booke bÂden? (dd-MM-≈≈≈≈ HH:mm)");
        string startInput = Console.ReadLine();
        DateTime startDateTime = DateTime.ParseExact(startInput, "dd-MM-yyyy HH:mm", null);

        Console.WriteLine("HvornÂr vil du returnere bÂden? (dd-MM-≈≈≈≈ HH:mm)");
        string endInput = Console.ReadLine();
        DateTime endDateTime = DateTime.ParseExact(endInput, "dd-MM-yyyy HH:mm", null);

        Console.WriteLine("Skal andre med pÂ bÂden? hvis ja sÂ skriv Navn og Adresse");
        string guests = Console.ReadLine();

        Booking booking1 = new Booking(startDateTime, endDateTime, member, boat, guests);

    }


}