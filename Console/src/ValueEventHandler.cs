using System;
using System.Threading.Channels;
using Library;

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
}