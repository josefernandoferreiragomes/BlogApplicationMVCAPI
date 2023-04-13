using BlogWebAPI.DataModels;
using BlogWebAPI.Interfaces;
using LoanManagement.Platform.Container;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace BlogWebAPI.Controllers
{
    public class BlogController : ApiController
    {
        IBloggerManager _BloggerManager;

        public BlogController()
        {
            _BloggerManager = ApplicationContainer.Resolve<IBloggerManager>();
        }

        public BlogController(IBloggerManager bloggerManager)
        {
            _BloggerManager = bloggerManager;
        }

        

        // GET api/values
        public IEnumerable<Blog> Get()
        {
            List<Blog> blogs;
            blogs = _BloggerManager.GetBlogs();
            return blogs;
        }


        // POST api/values
        public async Task<Blog> Post([FromBody] Blog blog)
        {
            Blog blogItem = await _BloggerManager.AddBlog(blog).ConfigureAwait(false);
            return blogItem;
        }

        // PUT api/values/5
        public async Task<Blog> Put(int id, [FromBody] Blog blog)
        {
            Blog blogItem = await _BloggerManager.UpdateBlog(id, blog).ConfigureAwait(false);
            return blogItem;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
