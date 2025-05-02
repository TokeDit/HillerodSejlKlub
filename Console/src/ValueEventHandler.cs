using Library;
using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Channels;

#nullable disable


public static class ValueEventHandler
{

    public static BoatRepo boatRepo1 = new BoatRepo();
    public static BlogRepo blogRepo1 = new BlogRepo();
    public static BookingRepo bookingRepo1 = new BookingRepo();
    public static EventRepo eventRepo1 = new EventRepo();
    public static MemberRepo memberRepo1 = new MemberRepo();

    private static bool m_eventSuccess = false; 
    

    public static void KeyList(string value)
    {
        switch (value)
        {

        }
    }

    public static void KeyEdit(string value)
    {
        switch (value.ToLower())
        {
            case "båd":
                while (!m_eventSuccess)
                {
                    try
                    {
                        EditBoat();
                    }
                    catch (TargetException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                        break;
                    }
                }
                m_eventSuccess = false;
                break;
            case "medlem":
                EditMember();
                break;
        }
    }

    public static void KeyNew(string value)
    {
        switch (value.ToLower())
        {
            case "b�d":
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

    // Takes the boats and changes one value, input is taken from the console
    private static void EditBoat()
    {
        boatRepo1.AddBoat(new Boat("fewfwe", "jgewoi", "jgwoei", new DateOnly(2000, 2, 12), 1, "fw", 1, 1));
        if (boatRepo1.ToList().Count() == 0)
        {
            throw new ArgumentException("Der er ikke nogle både");
        }
        
        Console.WriteLine("--------------");
        foreach (var boat in boatRepo1.ToList())
        {
            Console.WriteLine($"Både: {boat.Id}\nnavn: {boat.Name}\n--------------");
        }
        Console.WriteLine("Vælg bådens Id:");

        int selectedId = int.Parse(Console.ReadLine());

        Boat? selectedBoat = null;

        bool idFound = false;

        foreach (var boat in boatRepo1.ToList())
        {
            if (boat.Id == selectedId)
            {
                Console.WriteLine(boat.ToString());
                selectedBoat = boat;
                idFound = true;
                break;
            }
        }

        if (!idFound)
        {
            throw new TargetException($"\nBåden med id'et {selectedId} blev ikke fundet");
        }

        Console.WriteLine("Vælg hvad du vil redigere og hvad det skal ændres til fx:\n\nnavn sommerfuglen:\n");
        string sToKeyValuePair = Console.ReadLine();
        Console.WriteLine();
        KeyValuePair<string, string> keyValuePair = CommonFunc.GetKeyValuePair(sToKeyValuePair);
        switch (keyValuePair.Key.ToLower())
        {
            case "navn":
                selectedBoat.Name = keyValuePair.Value;
                break;
            case "model":
                selectedBoat.Model = keyValuePair.Value;
                break;
            case "type":
                selectedBoat.Type = keyValuePair.Value;
                break;
            case "produktion":
                selectedBoat.ProductionDate = DateOnly.Parse(keyValuePair.Value);
                break;
            case "sejlnummer":
                selectedBoat.SailingNumber = int.Parse(keyValuePair.Value);
                break;
            case "motor":
                selectedBoat.MotorInformation = keyValuePair.Value;
                break;
            case "mål":
                selectedBoat.Measurement = int.Parse(keyValuePair.Value);
                break;
            case "minimum":
                selectedBoat.MinimumCertificationRequirement = int.Parse(keyValuePair.Value);
                break;
        }

        Console.WriteLine(selectedBoat.ToString());
        m_eventSuccess = true;
    }

    private static void EditMember()
    {

    }

    private static void CreateNewBoat()
    {
        Console.WriteLine( "Navn");
        string boatName = Console.ReadLine();
        
        Console.WriteLine("Model");
        string model = Console.ReadLine();
        
        Console.WriteLine("B�d type");
        string type = Console.ReadLine();
        
        Console.WriteLine("Sejlnummer");
        int sailingNumber = int.Parse(Console.ReadLine());

        Console.WriteLine("Bygge�r (dd-MM-����)");
        string creationInput = Console.ReadLine();
        DateOnly creationDateTime = DateOnly.ParseExact(creationInput, "dd-MM-yyyy", null);
       
        Console.WriteLine("Motornummer");
        string motorInformation = Console.ReadLine();
        
        Console.WriteLine("L�ngde");
        int measurement = int.Parse(Console.ReadLine());
        
        Console.WriteLine("Certificat krav\nLille b�d = 1\nMellem b�d = 2\nStor b�d = 3");
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
        
        Console.WriteLine("Certificat type\nLille b�d = 1\nMellem b�d = 2\nStor b�d = 3");
        Member.BoatSize boatSize = (Member.BoatSize)int.Parse(Console.ReadLine());
        

        Member member1 = new Member(Memebername, address, phoneNumber, email, boatSize, AccesLevel);
        memberRepo1.AddMember(member1);
    }
    private static void CreateNewEvent()
    {
        Console.WriteLine("Navn");
        string eventName = Console.ReadLine();
        
        Console.WriteLine("Indtast start dato og tid (dd-MM-���� HH:mm)");
        string startInput = Console.ReadLine();
        DateTime startDateTime = DateTime.ParseExact(startInput, "dd-MM-yyyy HH:mm", null);

        Console.WriteLine("Indtast slut dato og tid (dd-MM-���� HH:mm)");
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

        Console.WriteLine("Indtast oprettelses dato (dd-MM-����)");
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
        Console.WriteLine("hvilken b�d vil du booke?");
        int boatId = int.Parse(Console.ReadLine());
        Boat boat = boatRepo1.FindBoatById(boatId);

        Console.WriteLine("Hvem booker b�den?");
        int memberId = int.Parse(Console.ReadLine());
        Member member = memberRepo1.FindMemberById(memberId); 

        Console.WriteLine("Hvorn�r vil du booke b�den? (dd-MM-���� HH:mm)");
        string startInput = Console.ReadLine();
        DateTime startDateTime = DateTime.ParseExact(startInput, "dd-MM-yyyy HH:mm", null);

        Console.WriteLine("Hvorn�r vil du returnere b�den? (dd-MM-���� HH:mm)");
        string endInput = Console.ReadLine();
        DateTime endDateTime = DateTime.ParseExact(endInput, "dd-MM-yyyy HH:mm", null);

        Console.WriteLine("Skal andre med p� b�den? hvis ja s� skriv Navn og Adresse");
        string guests = Console.ReadLine();

        Booking booking1 = new Booking(startDateTime, endDateTime, member, boat, guests);
        bookingRepo1.AddBooking(booking1);
    }


}