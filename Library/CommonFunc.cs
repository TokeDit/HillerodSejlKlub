public static class CommonFunc
{
  public static KeyValuePair<string, string> GetKeyValuePair(string input)
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
            }
        }
        return new KeyValuePair<string, string>(key, value);
    }
}