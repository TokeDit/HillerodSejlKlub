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
        private static List<Blog> blogs;
        private static List<Blog> filteredBlogs;

        public BlogRepo() 
        { 
            blogs = new List<Blog>();
            filteredBlogs = new List<Blog>();
        }
        public List<Blog> GetBlogs() { return blogs; }
        // Method to add a blog
        public void AddBlog(Blog blog)
        {
            blogs.Add(blog);
        }

        public List<Blog> GetAllBlogs()
        {
            return blogs;
        }

        private Blog? GetBlogById(int id)
        {
            Blog? blog = null;
            foreach (Blog b in blogs)
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
            foreach(Blog blog in blogs)
            {
                if (blog.Name == name)
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
                blogs.Remove(blogToRemove);
                return true;
            }
            return false;
        }
    }
}
