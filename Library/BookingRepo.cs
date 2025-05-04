using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class BookingRepo
    {
        public static List<Booking> AllBookings { get; private set; } = new List<Booking>()
        {
            new(new DateTime(2025, 10, 10, 10, 00, 00), new DateTime(2025, 10, 10, 15, 00, 00), MemberRepo.FindMemberById(2), BoatRepo.FindBoatById(1), "Bent"),
            new(new DateTime(2025, 10, 10, 10, 00, 00), new DateTime(2025, 10, 10, 15, 00, 00), MemberRepo.FindMemberById(3), BoatRepo.FindBoatById(2), "Gert")
        };
        private static List<Booking> filteredBookings = new List<Booking>();
        
     
        public static void AddBooking(Booking booking) { AllBookings.Add(booking); }
       

        public static bool DeleteBooking(int id)
        {
            foreach (Booking m in AllBookings)
            {
                if (m.Id.Equals(id))
                {
                    return AllBookings.Remove(m);
                }
            }
            return false;
        }


        //Filters the List by the Unique Id given to a Booking
        public static Booking? GetBookingById(int Id)
        {
            Booking? booking = null;
            foreach (Booking b in AllBookings)
            {
                if (b.Id.Equals(Id))
                {
                    return booking = b;

                }
            }
            if (booking == null)
            {
                string msg = $"Din søgning gav ingen resultater. Vi fandt ingen booking med det angivne ID";
                throw new NoSearhResultException(msg);
            }
            return booking;
        }
        
        public static List<Booking> FilterBookingByBoatName(string name)
        {
            filteredBookings.Clear();
            foreach (Booking b in AllBookings)
            {
                if (b.Boat.Name.ToLower().Equals(name))
                {
                    filteredBookings.Add(b);
                }
            }
            if (filteredBookings == null || filteredBookings.Count <= 0)
            {
                string msg = $"Din søgning gav ingen resultater. Vi fandt ingen booking med det angivne navn";
                throw new NoSearhResultException(msg);
            }
            return filteredBookings;
        }
        
        //Returns list as a string.
        public static string ReturnListAsString(List<Booking> booking)
        {
            string s = "";
            foreach (Booking m in booking)
            {
                s += m.ToString() + "\n";
            }
            return s;
        }
    }
}

