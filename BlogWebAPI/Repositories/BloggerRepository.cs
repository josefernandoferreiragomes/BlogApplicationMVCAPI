using BlogWebAPI.DAO;
using BlogWebAPI.DataModels;
using BlogWebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Web;

namespace BlogWebAPI.Repositories
{
    public class BloggerRepository : IBloggerRepository
    {
        BloggingContext _bloggingContext;

        public BloggerRepository()
        {
            _bloggingContext = new BloggingContext();
        }

        public List<Blog> GetAllBlogs()
        {
            
            List<Blog> blogs = _bloggingContext.Blogs.ToList();
            return blogs;

        }
        public async Task<Blog> AddBlog( Blog blog)
        {
            _bloggingContext.Blogs.Add(blog);
            await _bloggingContext.SaveChangesAsync();
            
            var query = from b in _bloggingContext.Blogs
                        where b.Name == blog.Name
                        select b;
            Blog blogItem = query.FirstOrDefault();
            return blogItem;
        }

        public async Task<Blog> UpdateBlog(int id, Blog blog)
        {

            _bloggingContext.Blogs.AddOrUpdate(blog);
            await _bloggingContext.SaveChangesAsync();

            var query = from b in _bloggingContext.Blogs
                        where b.Name == blog.Name
                        select b;
            Blog blogItem = query.FirstOrDefault();
            return blogItem;
        }
    }
}