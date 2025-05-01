using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class BookingRepo
    {
        private List<Booking> allBookings;
        private List<Booking> filteredBookings;
        
        public BookingRepo()
        {
            allBookings = new List<Booking>();
            filteredBookings = new List<Booking>();
           
        }
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
        public Booking FilterBookingById(int Id)
        {
            foreach (Booking m in allBookings)
            {
                if (m.Id.Equals(Id))
                {
                    return m;

                }
            }
            return null;
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

