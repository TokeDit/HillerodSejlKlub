using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class MemberRepo
    {
        private List<Member> allMembers;
        private List<Member> filteredMembers;
        public MemberRepo()
        {
            allMembers = new List<Member>();
            filteredMembers = new List<Member>();
        }
        public void AddMember(Member member) { allMembers.Add(member); }
        public bool DeleteMember(Member member) { return allMembers.Remove(member); }

        public void EditMember()
        {

        }

        //Filters the
        public List<Member> FindMemberById(int Id)
        {
            filteredMembers.Clear();
            foreach (Member m in allMembers)
            {
                if (m.Id.Equals(Id))
                {
                    filteredMembers.Add(m);

                }
            }
            return filteredMembers;
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
