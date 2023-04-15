using BlogApplication.WebSite.Interfaces;
using BlogApplication.WebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogApplication.WebSite.Controllers
{
    public class ProductController : Controller
    {
        private IProductsRepository _productsRepository;

        public ProductController()
        {
            _productsRepository = new ProductsRepository();
        }
        //// GET: Product
        //public ActionResult Index()
        //{

        //    ProductViewModel model = new ProductViewModel();
        //    model.Products=_productsRepository.GetPageOfProducts(2, 1, null);
        //    return View(model);
        //}
        // GET: Product       
        public ActionResult Index(ProductViewModel inputModel)
        {
            ProductViewModel model = new ProductViewModel();
            if (inputModel.RowsPerPage==0)
            {
                model.RowsPerPage = 2;
                model.Page = 1;
                model.TextFilter = "";
            }
            else
            {
                model.RowsPerPage=inputModel.RowsPerPage;
                model.Page=inputModel.Page;
                model.TextFilter = inputModel.TextFilter;
            }
            model.Products = _productsRepository.GetPageOfProducts(model.RowsPerPage, model.Page, model.TextFilter);
            return View(model);
        }
        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(ProductModel inputModel)
        {
            ProductModel model = new ProductModel();
            //ModelState.AddModelError("error", new InvalidOperationException());
            if (ModelState.IsValid)
            {
                model.ValidationMessage = "Success";
            }
            else
            {
                model.ValidationMessage = "Error adding product";
            }            
            //try
            //{
            //    // TODO: Add insert logic here

            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View(model);
            //}
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateAjax(ProductModel inputModel)
        {
            ProductModel model = new ProductModel();
            //ModelState.AddModelError("error", new InvalidOperationException());
            //requires manual validation for each field
            if (ModelState.IsValid)
            {
                model.ValidationMessage = "Success";
            }
            else
            {
                model.ValidationMessage = "Error adding product";
            }
            //try
            //{
            //    // TODO: Add insert logic here

            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View(model);
            //}
            
            return Json(new { model, JsonRequestBehavior.AllowGet });
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProductModel inputModel)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
