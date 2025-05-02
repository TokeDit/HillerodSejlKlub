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

    private static bool m_eventSuccess = false; 
    

    public static void KeyList(string value)
    {
        switch (value)
        {
            case "båd":
                Console.WriteLine(BoatRepo.ReturnListAsString(BoatRepo.AllBoats));
                break;
            case "medlem":
                Console.WriteLine(MemberRepo.ReturnListAsString(MemberRepo.AllMembers));
                break;
            case "blog":
                Console.WriteLine(BlogRepo.ReturnListAsString(BlogRepo.AllBlogs));
                break;
            case "begivenhed":
                Console.WriteLine(EventRepo.ReturnListAsString(EventRepo.AllEvents));
                break;
            case "booking":
                Console.WriteLine(BookingRepo.ReturnListAsString(BookingRepo.AllBookings));
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
        BoatRepo.AddBoat(new Boat("fewfwe", "jgewoi", "jgwoei", new DateOnly(2000, 2, 12), 1, "fw", 1, 1));
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
        BoatRepo.AddBoat(boat1);
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
        MemberRepo.AddMember(member1);
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
        Member eventOrganisator = MemberRepo.FindMemberById(organisatorId);

        Event event1 = new Event(eventName, startDateTime, endDateTime, eventOrganisator);
        EventRepo.AddEvent(event1);

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
        Member blogWriter = MemberRepo.FindMemberById(int.Parse(blogWriterName));

        Console.WriteLine("Event");
        string eventInput = Console.ReadLine();
        Event? blogEvent = null;

        if (!string.IsNullOrEmpty(eventInput))
        {
            int eventId = int.Parse(eventInput);
            blogEvent = EventRepo.GetEventById(eventId);
        }

        Blog blog1 = new Blog(blogTitle, creationDateOnly, description, blogWriter);

        if (blogEvent != null)
        {
            blog1.RelatedEvent = blogEvent;
        }
        BlogRepo.AddBlog(blog1);
    }
    private static void CreateNewBooking()
    {
        Console.WriteLine("hvilken båd vil du booke?");
        int boatId = int.Parse(Console.ReadLine());
        Boat boat = BoatRepo.FindBoatById(boatId);

        Console.WriteLine("Hvem booker båden?");
        int memberId = int.Parse(Console.ReadLine());
        Member member = MemberRepo.FindMemberById(memberId); 

        Console.WriteLine("Hvornår vil du booke båden? (dd-MM-ÅÅÅÅ HH:mm)");
        string startInput = Console.ReadLine();
        DateTime startDateTime = DateTime.ParseExact(startInput, "dd-MM-yyyy HH:mm", null);

        Console.WriteLine("Hvornår vil du returnere b�den? (dd-MM-ÅÅÅÅ HH:mm)");
        string endInput = Console.ReadLine();
        DateTime endDateTime = DateTime.ParseExact(endInput, "dd-MM-yyyy HH:mm", null);

        Console.WriteLine("Skal andre med på båden? hvis ja så skriv Navn og Adresse");
        string guests = Console.ReadLine();

        Booking booking1 = new Booking(startDateTime, endDateTime, member, boat, guests);
        BookingRepo.AddBooking(booking1);
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
        Console.WriteLine(BoatRepo.ReturnListAsString(BoatRepo.AllBoats)+"\n" );
        Console.WriteLine("Hvilken båd vil du slette? Intast bådens ID");
        m_eventSuccess = false;
        Boat boat = null;
        while (!m_eventSuccess)
        {
            string input = Console.ReadLine();
            if (input == "fortryd")
            {
                break;
            }
            try
            {
                boat = BoatRepo.FindBoatById(Int32.Parse(input));
                m_eventSuccess = true;
                Console.WriteLine("\nEr du sikker på at du vil slette denne båd? (ja/nej) ");
                Console.WriteLine("\n"+boat);
                input = Console.ReadLine();
                switch (input)
                {
                    case "ja":
                        BoatRepo.DeleteBoat(boat);
                        Console.WriteLine("Båden er fjernet");
                        break;
                    case "nej":
                        break;
                }
            }
            catch (NoSearhResultException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("prov igen, eller skriv fortryd");
            }
        }
                
       
    }

    private static void RemoveBlog()
    {
        Console.WriteLine(BlogRepo.ReturnListAsString(BlogRepo.AllBlogs) + "\n");
        Console.WriteLine("Hvilken blog vil du slette? Intast bloggens ID");
        m_eventSuccess = false;
        Blog blog = null;
        while (!m_eventSuccess)
        {
            string input = Console.ReadLine();
            if (input == "fortryd")
            {
                break;
            }
            try
            {
                blog = BlogRepo.GetBlogById(Int32.Parse(input));
                m_eventSuccess = true;
                Console.WriteLine("\nEr du sikker på at du vil slette denne blog? (ja/nej) ");
                Console.WriteLine("\n" + blog);
                input = Console.ReadLine();
                switch (input)
                {
                    case "ja":
                        BlogRepo.RemoveBlog(blog.Id);
                        Console.WriteLine("Bloggen er fjernet");
                        break;
                    case "nej":
                        break;
                }
            }
            catch (NoSearhResultException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("prov igen, eller skriv fortryd");
            }
        }
        
    }

    private static void RemoveEvent()
    {
        Console.WriteLine(EventRepo.ReturnListAsString(EventRepo.AllEvents) + "\n");
        Console.WriteLine("Hvilken begivenhed vil du slette? Intast begivenhedens ID");
        m_eventSuccess = false;
        Event e = null;
        while (!m_eventSuccess)
        {
            string input = Console.ReadLine();
            if (input == "fortryd")
            {
                break;
            }
            try
            {
                e = EventRepo.GetEventById(Int32.Parse(input));
                m_eventSuccess = true;
                Console.WriteLine("\nEr du sikker på at du vil slette denne begivenhed? (ja/nej) ");
                Console.WriteLine("\n" + e);
                input = Console.ReadLine();
                switch (input)
                {
                    case "ja":
                        BlogRepo.RemoveBlog(e.Id);
                        Console.WriteLine("Begivenheden er fjernet");
                        break;
                    case "nej":
                        break;
                }
            }
            catch (NoSearhResultException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("prov igen, eller skriv fortryd");
            }
        }
    }

    private static void DeleteMember()
    {
        Console.WriteLine(MemberRepo.ReturnListAsString(MemberRepo.AllMembers) + "\n");
        Console.WriteLine("Hvilket medlem vil du slette? Intast medlemmets ID");
        m_eventSuccess = false;
        Member member = null;
        while (!m_eventSuccess)
        {
            string input = Console.ReadLine();
            if (input == "fortryd")
            {
                break;
            }
            try
            {
                member = MemberRepo.FindMemberById(Int32.Parse(input));
                m_eventSuccess = true;
                Console.WriteLine("\nEr du sikker på at du vil slette dette medlem? (ja/nej) ");
                Console.WriteLine("\n" + member);
                input = Console.ReadLine();
                switch (input)
                {
                    case "ja":
                        MemberRepo.DeleteMember(member.Id);
                        Console.WriteLine("Medlemmet er fjernet");
                        break;
                    case "nej":
                        break;
                }
            }
            catch (NoSearhResultException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("prov igen, eller skriv fortryd");
            }
        }
    }

    private static void DelteBooking()
    {
        Console.WriteLine(BookingRepo.ReturnListAsString(BookingRepo.AllBookings) + "\n");
        Console.WriteLine("Hvilken booking vil du slette? Intast medlemmets ID");
        m_eventSuccess = false;
        Booking booking = null;
        while (!m_eventSuccess)
        {
            string input = Console.ReadLine();
            if (input == "fortryd")
            {
                break;
            }
            try
            {
                booking = BookingRepo.GetBookingById(Int32.Parse(input));
                m_eventSuccess = true;
                Console.WriteLine("\nEr du sikker på at du vil slette denne booking? (ja/nej) ");
                Console.WriteLine("\n" + booking);
                input = Console.ReadLine();
                switch (input)
                {
                    case "ja":
                        BookingRepo.DeleteBooking(booking.Id);
                        Console.WriteLine("Bookingen er fjernet");
                        break;
                    case "nej":
                        break;
                }
            }
            catch (NoSearhResultException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("prov igen, eller skriv fortryd");
            }
        }
    }

}