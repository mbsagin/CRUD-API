using CRUD_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRUD_API.Controllers
{
    public class BlogPostsController : ApiController
    {
        static readonly IBlogPostRepository repository = new BlogPostRepository();

        public IEnumerable<BlogPost> GetAllBlogPosts()
        {
            return repository.GetAll();
        }
        public BlogPost GetBlogPost(int id)
        {
            BlogPost item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }
        public IEnumerable<BlogPost> GetBlogPostsByCategory(string category)
        {
            return repository.GetAll().Where(
                p => string.Equals(p.Category, category, StringComparison.OrdinalIgnoreCase));
        }
        public HttpResponseMessage PostBlogPost(BlogPost item)
        {
            item = repository.Add(item);
            var response = Request.CreateResponse<BlogPost>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }
        public void PutBlokPost(int id, BlogPost blogpost)
        {
            blogpost.Id = id;
            if (!repository.Update(blogpost))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
        public void DeleteBlogPost(int id)
        {
            BlogPost item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            repository.Remove(id);
        }
    }
}
