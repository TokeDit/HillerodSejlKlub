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

        // Add blogs to the repository
        public Blog blog1 = new Blog("Boat trip", new DateTime(2025, 05, 06, 12, 00, 00), new DateTime(2025, 05, 06, 18, 00, 00), "Boat trip to check boat functionality.", "Alice");
        public Blog blog2 = new Blog("Boat party", new DateTime(2025, 05, 18, 12, 00, 00), new DateTime(2025, 05, 18, 18, 00, 00), "Bob’s birthday party.", "Bob");

        // Method to add a blog
        public void AddBlog(Blog blog)
        {
            blogs.Add(blog);
        }

        public List<Blog> GetAllBlogs()
        {
            return blogs;
        }

       //?? public List<Blog> GetEventById(int id)
       // {
       //     return blogs;
       // }

        public void RemoveBlog(int id)
        {
            Blog blogToRemove = GetBlogById(id);
            if (blogToRemove != null)
            {
                blogs.Remove(blogToRemove);
            }
        }

        private Blog GetBlogById(int id)
        {
            throw new NotImplementedException();
        }

        // Method to edit a blog
        public bool EditBlog(int id, string newName, string newDescription, string newWriter)
        {
            Blog blogToEdit= GetBlogById(id); 
            if (blogToEdit != null)
            {
                blogToEdit.Name = newName;
                blogToEdit.Description = newDescription;
                blogToEdit.Writer = newWriter;
                return true; // Successful edit
            }
            return false; // Blog with the given ID not found
        }
    }
}
