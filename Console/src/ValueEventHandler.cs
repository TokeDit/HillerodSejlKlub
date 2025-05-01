using Library;
using System;

public static class ValueEventHandler
{
    static MemberRepo members = new();
    public static void KeyList(string value)
    {
        switch (value)
        {
            case "medlemmer":
                foreach (Member member in members.GetMembers())
                {

                }
                break;
            case "både":
                break;
            case "blogs":
                break;
            case "begivenheder":
                break;
            case "bookings":
                break;
        }
    }

    public static void KeyNew(string value)
    {
        switch (value)
        {
            
        }
    }
    public static void KeyDelete(string value)
    {
        switch (value)
        {

        }
    }
}