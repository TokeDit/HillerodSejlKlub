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


    private bool m_run = true;



    public MainHandler()
    {
        while (m_run)
        {
            Console.WriteLine("Indtast en kommando (eller 'exit' for at afslutte):\n------------");
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
                continue;

            if (input.ToLower() == "hjælp") 
            {
                Console.WriteLine("Indtast en af følgend\n------------\nSe\nTilfoj\nRediger\nFjern\n------------\nEfterfulgt af følgende\n------------\nBåd\nMedlem\nBegivenhed\nBlog\nBooking\n------------");
                continue;
            }

            if (input.ToLower() == "exit")
            { 
                m_run = false;
                break;
            }
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
                    ValueEventHandler.KeyDelete(keyValuePair.Value);
                    break;
                case "hjælp":
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