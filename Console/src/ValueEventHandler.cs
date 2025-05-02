using Library;
using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Channels;
using System.Xml.Linq;
using Library;
using static Library.Member;



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
            case "både":
                Console.WriteLine(boatRepo1.ReturnListAsString(BoatRepo.AllBoats));
                break;
            case "medlemmer":
                Console.WriteLine(memberRepo1.ReturnListAsString(MemberRepo.AllMembers));
                break;
            case "blogs":
                Console.WriteLine(blogRepo1.ReturnListAsString(BlogRepo.AllBlogs));
                break;
            case "begivenheder":
                Console.WriteLine(boatRepo1.ReturnListAsString(BoatRepo.AllBoats));
                break;
            case "bookings":
                Console.WriteLine(boatRepo1.ReturnListAsString(BoatRepo.AllBoats));
                break;

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
            case "båd":
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
        if (BoatRepo.AllBoats.Count() == 0)
        {
            throw new ArgumentException("Der er ikke nogle både");
        }
        
        Console.WriteLine("--------------");
        foreach (var boat in BoatRepo.AllBoats)
        {
            Console.WriteLine($"Både: {boat.Id}\nnavn: {boat.Name}\n--------------");
        }
        Console.WriteLine("Vælg bådens Id:");

        int selectedId = int.Parse(Console.ReadLine());

        Boat? selectedBoat = null;

        bool idFound = false;

        foreach (var boat in BoatRepo.AllBoats)
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
        
        Console.WriteLine("Båd type");
        string type = Console.ReadLine();
        
        Console.WriteLine("Sejlnummer");
        int sailingNumber = int.Parse(Console.ReadLine());

        Console.WriteLine("Byggeår (dd-MM-ÅÅÅÅ)");
        string creationInput = Console.ReadLine();
        DateOnly creationDateTime = DateOnly.ParseExact(creationInput, "dd-MM-yyyy", null);
       
        Console.WriteLine("Motornummer");
        string motorInformation = Console.ReadLine();
        
        Console.WriteLine("Længde");
        int measurement = int.Parse(Console.ReadLine());
        
        Console.WriteLine("Certificat krav\nLille båd = 1\nMellem båd = 2\nStor båd = 3");
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
        
        Console.WriteLine("Certificat type\nLille båd = 1\nMellem båd = 2\nStor båd = 3");
        Member.BoatSize boatSize = (Member.BoatSize)int.Parse(Console.ReadLine());
        

        Member member1 = new Member(Memebername, address, phoneNumber, email, boatSize, AccesLevel);
        memberRepo1.AddMember(member1);
    }
    private static void CreateNewEvent()
    {
        Console.WriteLine("Navn");
        string eventName = Console.ReadLine();
        
        Console.WriteLine("Indtast start dato og tid (dd-MM-ÅÅÅÅ HH:mm)");
        string startInput = Console.ReadLine();
        DateTime startDateTime = DateTime.ParseExact(startInput, "dd-MM-yyyy HH:mm", null);

        Console.WriteLine("Indtast slut dato og tid (dd-MM-ÅÅÅÅ HH:mm)");
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

        Console.WriteLine("Indtast oprettelses dato (dd-MM-ÅÅÅÅ)");
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
        Console.WriteLine("hvilken båd vil du booke?");
        int boatId = int.Parse(Console.ReadLine());
        Boat boat = boatRepo1.FindBoatById(boatId);

        Console.WriteLine("Hvem booker båden?");
        int memberId = int.Parse(Console.ReadLine());
        Member member = memberRepo1.FindMemberById(memberId); 

        Console.WriteLine("Hvornår vil du booke båden? (dd-MM-ÅÅÅÅ HH:mm)");
        string startInput = Console.ReadLine();
        DateTime startDateTime = DateTime.ParseExact(startInput, "dd-MM-yyyy HH:mm", null);

        Console.WriteLine("Hvornår vil du returnere b�den? (dd-MM-ÅÅÅÅ HH:mm)");
        string endInput = Console.ReadLine();
        DateTime endDateTime = DateTime.ParseExact(endInput, "dd-MM-yyyy HH:mm", null);

        Console.WriteLine("Skal andre med på båden? hvis ja så skriv Navn og Adresse");
        string guests = Console.ReadLine();

        Booking booking1 = new Booking(startDateTime, endDateTime, member, boat, guests);
        bookingRepo1.AddBooking(booking1);
    }

    public static void KeyDelete(string value)
    {
        switch (value.ToLower())
        {
            case "båd":
                DeleteBoat();
                break;

            case "medlem":
                DeleteMember();
                break;

            case "begivenhed":
                RemoveEvent();
                break;

            case "blog":
                RemoveBlog();
                break;
            case "reservartion":
                DelteBooking();
                break;
        }
    }

    private static void DeleteBoat() 
    {
        Console.WriteLine("Navn");
        string name = Console.ReadLine();

        Console.WriteLine("Model");
        string model = Console.ReadLine();

        Console.WriteLine("Båd type");
        string type = Console.ReadLine();

        Console.WriteLine("Sejlnummer");
        int sailingNummer = int.Parse(Console.ReadLine()); //What is Parse? And what is it funktion?

        Console.WriteLine("Byggeår");
        int year = int.Parse(Console.ReadLine());

        Console.WriteLine("Måned");
        int month = int.Parse(Console.ReadLine());

        Console.WriteLine("Dag");
        int day = int.Parse(Console.ReadLine());

        Console.WriteLine("Motornummeer");
        string motorInformation = Console.ReadLine();

        Console.WriteLine("Længde");
        int measurement = int.Parse(Console.ReadLine());

        Console.WriteLine("\"Certificat krav\\nLille båd = 1\\nMellem båd = 2\\nStor båd = 3");
        int minmumCertificationRewuirement = int.Parse(Console.ReadLine());
    }

    private static void RemoveBlog()
    {
        Console.WriteLine("Navn");
        string name = Console.ReadLine();

        Console.WriteLine("Start dato");
        int DateTime = int.Parse(Console.ReadLine());

        Console.WriteLine("Beskrivelse");
        string Description = Console.ReadLine();

        Console.WriteLine("Begivenhed");
        string Event = Console.ReadLine();

        Console.WriteLine("Medlemmer");
        string Writer = Console.ReadLine();
    }

    private static void RemoveEvent()
    {
        Console.WriteLine("Navn");
        string name = Console.ReadLine();

        Console.WriteLine("Start dato");
        int DateTime = int.Parse(Console.ReadLine());

        Console.WriteLine("Slut dato");
        int EndDate = int.Parse(Console.ReadLine());

        Console.WriteLine("Members");
        string Members = Console.ReadLine();

        Console.WriteLine("Koordinator");
        string CordCoordinator = Console.ReadLine();
    }

    private static void DeleteMember()
    {
        Console.WriteLine("Navn");
        string name = Console.ReadLine();

        Console.WriteLine("Medlem Id");
        int Id = int.Parse(Console.ReadLine());

        Console.WriteLine("Adresse");
        string Address = Console.ReadLine();

        Console.WriteLine("Telephone number");
        int TelephoneNumber = int.Parse(Console.ReadLine());

        Console.WriteLine("Email");
        string Email = Console.ReadLine();

        Console.WriteLine("Båd certificat");
        string memberCertification = Console.ReadLine();

        Console.WriteLine("Medlems niveau");
        string memberAcceslevel = Console.ReadLine();
    }

    private static void DelteBooking()
    {
        Console.WriteLine("Båd navn");
        string Boat.Name = Console.ReadLine();

        Console.WriteLine("Medlem");
        string Member.Name = Console.ReadLine();

        Console.WriteLine("Start dato");
        int DateTime = int.Parse(Console.ReadLine());

        Console.WriteLine("Slut dato");
        int EndDate = int.Parse(Console.ReadLine());

        Console.WriteLine("Gæster");
        string Guests = Console.ReadLine();
    }

    private static void DeleteBoat()
    {
        Console.WriteLine("Indtast bådens ID for at slette den:");
        int boatId = int.Parse(Console.ReadLine());
        Boat boat = boatRepo1.FindBoatById(boatId);
        BoatRepo.AllBoats.Remove(boat);
    }
}