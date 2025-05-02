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
    public class BlogRepo
    {
        public static List<Blog> AllBlogs { get; private set; }
        private static List<Blog> filteredBlogs;

        public BlogRepo() 
        { 
            AllBlogs = new List<Blog>();
            filteredBlogs = new List<Blog>();
        }
        
        public void AddBlog(Blog blog)
        {
            AllBlogs.Add(blog);
        }

        public List<Blog> GetAllBlogs()
        {
            return AllBlogs;
        }

        private Blog? GetBlogById(int id)
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

        public List<Blog> GetBlogByName(string name)
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

      public void UpdateBlog(Blog updadedBlog)
        {
            RemoveBlog(updadedBlog.Id);
            AddBlog(updadedBlog);
        }

        public bool RemoveBlog(int id)
        {
            Blog blogToRemove = GetBlogById(id);
            if (blogToRemove != null)
            {
                AllBlogs.Remove(blogToRemove);
                return true;
            }
            return false;
        }

        public string ReturnListAsString(List<Blog> allBlogs)
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
