using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class BlogRepo
    {
        public static List<Blog> AllBlogs { get; private set; } = new List<Blog>() 
        { 
            new("Fødselsdag", new DateOnly(2025, 02, 02), "Esti har fødselsdag", MemberRepo.FindMemberById(1)),
            new("Lønningsdag", new DateOnly(2025, 01, 26), "Der er løn i dag woop woop", MemberRepo.FindMemberById(3))
        };
        private static List<Blog> filteredBlogs = new List<Blog>();

        
        public static void AddBlog(Blog blog)
        {
            AllBlogs.Add(blog);
        }

        public static List<Blog> GetAllBlogs()
        {
            return AllBlogs;
        }

        public static Blog? GetBlogById(int id)
        {
            Blog? blog = null;
            foreach (Blog b in AllBlogs)
            {
                if (b.Id == id)
                {
                    return blog = b;
                }
            }
            if (blog == null)
            {
                string msg = $"Din søgning gav ingen resultater. Vi fandt ingen blog med det angivne ID";
                throw new NoSearhResultException(msg);
            }
            return blog;
        }

        public static List<Blog> GetBlogByName(string name)
        {
            foreach(Blog blog in AllBlogs)
            {
                if (blog.Title == name)
                {
                    filteredBlogs.Add(blog);
                    return filteredBlogs;
                }
            }
            if (filteredBlogs == null || filteredBlogs.Count <= 0)
            {
                string msg = $"Din søgning gav ingen resultater. Vi fandt ingen blog med det angivne titel";
                throw new NoSearhResultException(msg);
            }
            return filteredBlogs;
        }

      public static void UpdateBlog(Blog updadedBlog)
        {
            RemoveBlog(updadedBlog.Id);
            AddBlog(updadedBlog);
        }

        public static bool RemoveBlog(int id)
        {
            Blog blogToRemove = GetBlogById(id);
            if (blogToRemove != null)
            {
                AllBlogs.Remove(blogToRemove);
                return true;
            }
            return false;
        }

        public static string ReturnListAsString(List<Blog> allBlogs)
        {
            string s = "";
            foreach (Blog blog in AllBlogs)
            {
                s += blog.ToString() + "\n";
            }
            return s;
        }
    }
}
