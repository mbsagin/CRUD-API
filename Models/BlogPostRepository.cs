using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_API.Models
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private List<BlogPost> BlogPosts = new List<BlogPost>();
        private int _nextId = 1;

        public BlogPostRepository()
        {
            Add(new BlogPost { Title = "Tomato soup", Category = "Groceries", Author = "John Doe", Content = " " });
            Add(new BlogPost { Title = "Yo-yo", Category = "Toys", Author = "John Doe", Content = " " });
            Add(new BlogPost { Title = "Hammer", Category = "Hardware", Author = "John Doe", Content = " " });
        }

        public IEnumerable<BlogPost> GetAll()
        {
            return BlogPosts;
        }

        public BlogPost Get(int id)
        {
            return BlogPosts.Find(p => p.Id == id);
        }

        public BlogPost Add(BlogPost item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.Id = _nextId++;
            BlogPosts.Add(item);
            return item;
        }

        public void Remove(int id)
        {
            BlogPosts.RemoveAll(p => p.Id == id);
        }

        public bool Update(BlogPost item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = BlogPosts.FindIndex(p => p.Id == item.Id);
            if (index == -1)
            {
                return false;
            }
            BlogPosts.RemoveAt(index);
            BlogPosts.Add(item);
            return true;
        }
    }
}