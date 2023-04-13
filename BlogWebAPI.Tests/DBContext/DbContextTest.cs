using BlogWebAPI.DAO;
using BlogWebAPI.DataModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlogWebAPI.Tests.DBContext
{
    [TestClass]
    public class DbContextTest
    {
        [TestMethod]
        public void WriteAndReadData()
        {
            using (var db = new BloggingContext())
            {
                // Create and save a new Blog
                Console.Write("new Blog: ");
                var name = "new blog";

                var blog = new Blog { Name = name };
                db.Blogs.Add(blog);
                db.SaveChanges();

                // Display all Blogs from the database
                //var query = from b in db.Blogs
                //            orderby b.Name
                //            select b;
                List<Blog> blogs = db.Blogs.ToList();

                Console.WriteLine("All blogs in the database:");
                foreach (var item in blogs)
                {
                    Console.WriteLine(item.Name);
                }

                Console.WriteLine("Press any key to exit...");
                
            }
        }
    }
}
