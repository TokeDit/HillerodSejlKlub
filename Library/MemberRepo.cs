using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library 
{
    public class MemberRepo
    {
        private static List<Member> allMembers;
        private static List<Member> filteredMembers;
        public MemberRepo()
        {
            allMembers = new List<Member>();
            filteredMembers = new List<Member>();
        }
        public void AddMember(Member member) { allMembers.Add(member); }
        //public bool DeleteMember(int) { return allMembers.Remove(int); }

        public bool DeleteMember(int id)
        {
            foreach (Member m in allMembers)
            {
                if (m.Id.Equals(id))
                {
                    return allMembers.Remove(m);
                }
            }
            return false;
        }

        //Filters the List by the Unique Id given to a Member
        public Member? FindMemberById(int Id)
        {
            Member? member = null;
            foreach (Member m in allMembers)
            {
                if (m.Id.Equals(Id))
                {
                    return member = m;
                }
            }
            if (member == null)
            {
                string msg = $"Din søgning gav ingen resultater. Vi fandt ingen medlemmer med det angivne ID";
                throw new NoSearhResultException(msg);
            }
            return member;
           
        }
        //Filters the list by the argument given in this case Name
        public List<Member> FindMemberByName(string Name)
        {
            filteredMembers.Clear();
            foreach (Member m in allMembers)
            {
                if (m.Name.ToLower().Equals(Name.ToLower()))
                {
                    filteredMembers.Add(m);
                  
                }
            }
            if (filteredMembers == null || filteredMembers.Count <= 0)
            {
                string msg = $"Din søgning gav ingen resultater. Vi fandt ingen medlemmer med det angivne navn";
                throw new NoSearhResultException(msg);
            }
            return filteredMembers;
        }
        //Returns a given list from the repo as a string.
        public string ReturnListAsString(List<Member> members)
        {
            string s = "";
            foreach (Member m in members)
            {
                s += m.ToString() +"\n";
            }
            return s;
        }
    }
}
