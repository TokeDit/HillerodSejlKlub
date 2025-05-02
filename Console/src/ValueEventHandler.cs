using System;
using System.Threading.Channels;
using System.Xml.Linq;
using Library;
using static Library.Member;

public static class ValueEventHandler
{
    public static BoatRepo boatRepo1 = new BoatRepo();
    
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
            case "b�d":
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
        Console.WriteLine("B�d type");
        string type = Console.ReadLine();
        Console.WriteLine("Sejlnummer");
        int sailingNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("Bygge�r");
        int year = int.Parse(Console.ReadLine());
        Console.WriteLine("M�ned");
        int month = int.Parse(Console.ReadLine());
        Console.WriteLine("Dag");
        int day = int.Parse(Console.ReadLine());
        Console.WriteLine("Motornummer");
        string motorInformation = Console.ReadLine();
        Console.WriteLine("L�ngde");
        int measurement = int.Parse(Console.ReadLine());
        Console.WriteLine("Certificat krav\nLille b�d = 1\nMellem b�d = 2\nStor b�d = 3");
        int minmumCertificationRequirement = int.Parse(Console.ReadLine());

        Boat boat1 = new Boat(name, model, type, new(year, month, day), sailingNumber, motorInformation, measurement, minmumCertificationRequirement);
    }

    public static void KeyDelete(string value)
    {
        switch (value.ToLower())
        {
            case "b�d":
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

        Console.WriteLine("B�d type");
        string type = Console.ReadLine();

        Console.WriteLine("Sejlnummer");
        int sailingNummer = int.Parse(Console.ReadLine()); //What is Parse? And what is it funktion?

        Console.WriteLine("Bygge�r");
        int year = int.Parse(Console.ReadLine());

        Console.WriteLine("M�ned");
        int month = int.Parse(Console.ReadLine());

        Console.WriteLine("Dag");
        int day = int.Parse(Console.ReadLine());

        Console.WriteLine("Motornummeer");
        string motorInformation = Console.ReadLine();

        Console.WriteLine("L�ngde");
        int measurement = int.Parse(Console.ReadLine());

        Console.WriteLine("\"Certificat krav\\nLille b�d = 1\\nMellem b�d = 2\\nStor b�d = 3");
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

        Console.WriteLine("B�d certificat");
        string memberCertification = Console.ReadLine();

        Console.WriteLine("Medlems niveau");
        string memberAcceslevel = Console.ReadLine();
    }

    private static void DelteBooking()
    {
        Console.WriteLine("B�d navn");
        string Boat.Name = Console.ReadLine();

        Console.WriteLine("Medlem");
        string Member.Name = Console.ReadLine();

        Console.WriteLine("Start dato");
        int DateTime = int.Parse(Console.ReadLine());

        Console.WriteLine("Slut dato");
        int EndDate = int.Parse(Console.ReadLine());

        Console.WriteLine("G�ster");
        string Guests = Console.ReadLine();
    }

    private static void DeleteBoat()
    {
        Console.WriteLine("Indtast b�dens ID for at slette den:");
        int boatId = int.Parse(Console.ReadLine());
        Boat boat = boatRepo1.FindBoatById(boatId);
        BoatRepo.AllBoats.Remove(boat);
    }
}