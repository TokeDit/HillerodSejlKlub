using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Channels;
using Library;

public static class ValueEventHandler
{

    public static BoatRepo boatRepo1 = new BoatRepo();

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

                break;

            case "begivenhed":

                break;

            case "blog":

                break;
            case "reservartion":

                break;
        }
    }

    // Takes the boats and changes one value, input is taken from the console
    private static void EditBoat()
    {
        // boatRepo1.AddBoat(new Boat("fewfwe", "jgewoi", "jgwoei", new DateOnly(2000, 2, 12), 1, "fw", 1, 1));
        if (boatRepo1.ToList().Count() == 0)
        {
            Console.WriteLine("Der er ikke nogle både");
            return;
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