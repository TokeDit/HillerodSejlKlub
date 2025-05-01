using System;
using System.Buffers.Text;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using Library;

public class MainHandler
{
    private static CustomDictionary<string, string> m_dictionary = new CustomDictionary<string, string>();

    public MainHandler()
    {
        
        // ({
        //     return 1;
        // });
    }

    public static string JSonRead(string filePath)
    {
        string text = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<string>(text);        
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

        foreach (var s in m_dictionary.GetList())
        {
            Console.WriteLine(s);
        }
    }
}