using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class BookingRepo
    {
        private static List<Booking> allBookings;
        private static List<Booking> filteredBookings;
        
        public BookingRepo()
        {
            allBookings = new List<Booking>();
            filteredBookings = new List<Booking>();
           
        }

        public List<Booking> GetBookings() { return allBookings; }
        public void AddBooking(Booking booking) { allBookings.Add(booking); }
       

        public bool DelteBooking(int id)
        {
            foreach (Booking m in allBookings)
            {
                if (m.Id.Equals(id))
                {
                    return allBookings.Remove(m);
                }
            }
            return false;
        }


        //Filters the List by the Unique Id given to a Booking
        public Booking? FilterBookingById(int Id)
        {
            Booking? booking = null;
            foreach (Booking b in allBookings)
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
        
        public List<Booking> FilterBookingByBoatName(string name)
        {
            filteredBookings.Clear();
            foreach (Booking b in allBookings)
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
        public string ReturnListAsString(List<Booking> booking)
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

