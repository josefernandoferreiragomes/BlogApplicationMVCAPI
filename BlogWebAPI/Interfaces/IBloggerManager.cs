using BlogWebAPI.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BlogWebAPI.Interfaces
{
    public interface IBloggerManager
    {
        List<Blog> GetBlogs();
        Task<Blog> AddBlog(Blog blog);
        Task<Blog> UpdateBlog(int id, Blog blog);
    }
}