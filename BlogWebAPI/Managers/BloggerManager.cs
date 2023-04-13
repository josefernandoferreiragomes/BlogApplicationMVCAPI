using BlogWebAPI.DataModels;
using BlogWebAPI.Interfaces;
using LoanManagement.Platform.Container;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BlogWebAPI.Managers
{
    public class BloggerManager : IBloggerManager
    {
        private IBloggerRepository _bloggerRepository;

        public BloggerManager()
        {
            _bloggerRepository = ApplicationContainer.Resolve<IBloggerRepository>();
        }

        public BloggerManager(IBloggerRepository bloggerRepository)
        {
            _bloggerRepository = bloggerRepository;
        }

        public List<Blog> GetBlogs()
        {
            List<Blog> blogs = new List<Blog>();
            try
            {
                blogs = _bloggerRepository.GetAllBlogs();
            }
            catch (Exception ex)
            {
                //log exception
                throw ex;
            }
            finally
            {

            }
            return blogs;
        }

        public async Task<Blog> AddBlog (Blog blog)
        {
            Blog blogOutput = await _bloggerRepository.AddBlog(blog).ConfigureAwait(false);
            return blogOutput;
        }

        public async Task<Blog> UpdateBlog(int id, Blog blog)
        {
            Blog blogOutput = await _bloggerRepository.UpdateBlog(id, blog).ConfigureAwait(false);
            return blogOutput;
        }
    }
}