using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_API.Models
{
    public interface IBlogPostRepository
    {
        IEnumerable<BlogPost> GetAll();
        BlogPost Get(int id);
        BlogPost Add(BlogPost item);
        void Remove(int id);
        bool Update(BlogPost item);
    }


}
