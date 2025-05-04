using System;
using System.Buffers.Text;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using System.Text.Json.Serialization;
using Library;

public class MainHandler
{
    private static CustomDictionary<string, string> m_dictionary = new CustomDictionary<string, string>();






    public MainHandler()
    {
       BookingRepo.AddBooking(new Booking(new DateTime(2000, 12, 9), new DateTime(2000, 12, 9, 12, 4, 2),
        MemberRepo.FindMemberById(1), new Boat("fewifw", "gw", "gwef", new DateOnly(2423, 9, 21), 1, "jofew", 13, 1), "fjeoiw"));
        while (true)
        {
            Console.WriteLine("Indtast en kommando (eller 'exit' for at afslutte):");
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
                continue;

            if (input.ToLower() == "exit")
                break;

            FindKeyValuePair(input);
            FindKey();
        }
        //FindKeyValuePair(Console.ReadLine());
        //FindKey();
    }

    public static Member JSonRead(string filePath)
    {
        string text = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<Member>(text);
    }

    public void FindKey()
    {
        foreach (var keyValuePair in m_dictionary.ToList())
        {
            switch (keyValuePair.Key.ToLower())
            {
                case "se":
                    ValueEventHandler.KeyList(keyValuePair.Value);
                    break;
                case "tilfoj":
                    ValueEventHandler.KeyNew(keyValuePair.Value);
                    break;
                case "rediger":
                    ValueEventHandler.KeyEdit(keyValuePair.Value);
                    break;
                case "fjern":
                    break;
                case "ændr":
                    break;

            }
        }
        m_dictionary.ToList().Clear();
    }

    public void FindKeyValuePair(string input)
    {
        int keyStart = 0;
        int keyEnd = 0;
        int valueStart = 0;
        int valueEnd = 0;
        string key = "";
        string value = "";
        bool checkForValue = false;

        for (int i = 0; i < input.Count(); i++)
        {
            if (input.ElementAt(i) != ' ' && checkForValue == false)
            {
                keyStart = i;
                keyEnd = input.IndexOf(" ", keyStart);

                if (keyEnd == -1)
                {
                    break;
                }

                key = input.Substring(keyStart, keyEnd - keyStart);
                checkForValue = true;
                i = keyEnd;
            }

            if (input.ElementAt(i) != ' ' && checkForValue == true)
            {
                valueStart = i;
                valueEnd = input.IndexOf(" ", valueStart);

                if (valueEnd == -1)
                {
                    valueEnd = input.Count();
                }

                value = input.Substring(valueStart, valueEnd - valueStart);
                checkForValue = false;
                i = valueEnd;
                m_dictionary.Add(key, value);
            }
        }
    }
}