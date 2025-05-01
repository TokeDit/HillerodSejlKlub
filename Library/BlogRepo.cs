using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class BlogRepo
    {
        private List<Blog> blogs;

        public BlogRepo() 
        { 
            blogs = new List<Blog>();
        }

        // Method to add a blog
        public void AddBlog(Blog blog)
        {
            blogs.Add(blog);
        }

        public List<Blog> GetAllBlogs()
        {
            return blogs;
        }


        private Blog GetBlogById(int id)
        {
            foreach (Blog blog in blogs)
            {
                if (blog.Id == id)
                {
                    return blog;
                }
            }
            return null;
        }

        public Blog GetBlogByName(string name)
        {
            foreach(Blog blog in blogs)
            {
                if (blog.Name == name)
                {
                    return blog;
                }
            }
            return null;
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
