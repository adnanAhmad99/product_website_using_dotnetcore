using Microsoft.AspNetCore.Mvc;
using MainApp.Models;
using MainApp.DataAccess.Repository.IRepostiory;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ProductWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(ILogger<HomeController> logger,IUnitOfWork unitOfWork,IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> products = _unitOfWork.Product.GetAll(includeDataPara:true);
            return View(products);
        }

        public IActionResult Details(int id)
        {
            Product product = _unitOfWork.Product.Get(u=>u.ProductId==id,includeDataPara:true);
            return View(product);
        }

        [HttpGet]
        public IActionResult Create() {
            Product product = new Product();

            IEnumerable<SelectListItem> categories = _unitOfWork.Category.GetAll().Select(u =>new SelectListItem
            {
                Text=u.CategoryName,
                Value=u.CategoryId.ToString(),
            });

            ViewBag.Categories = categories;

            return View(product);
        }
        [HttpPost]
        public IActionResult Create(Product product,IFormFile? ImageFile)
        {
            if (ModelState.IsValid)
            {
                if (ImageFile != null) {
                    string rootFolder = _webHostEnvironment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImageFile.FileName);
                    string ProductImagePath = @"images\products\" + fileName;

                    using(FileStream newFileStream = new FileStream(Path.Join(rootFolder, ProductImagePath), FileMode.Create))
                    {
                        ImageFile.CopyTo(newFileStream);
                    }

                    product.ImageUrl = @"/images/products/" + fileName;   

                }

                _unitOfWork.Product.Add(product);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            IEnumerable<SelectListItem> categories = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
            {
                Text = u.CategoryName,
                Value = u.CategoryId.ToString(),
            });

            ViewBag.Categories = categories;

            return View(product);

        }
        [HttpGet]
        public IActionResult Update(int id) {
            Product product = _unitOfWork.Product.Get(u => u.ProductId == id);
            IEnumerable<SelectListItem> categories = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
            {
                Text = u.CategoryName,
                Value = u.CategoryId.ToString(),
            });

            ViewBag.Categories = categories;
            return View(product);
        }
        [HttpPost]
        public IActionResult Update(Product product,IFormFile ImageFile)
        {
            if (ModelState.IsValid)
            {
                if (ImageFile != null)
                {
                    string rootFolder = _webHostEnvironment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImageFile.FileName);
                    string ProductImagePath = @"images\products\" + fileName;

                    using (FileStream newFileStream = new FileStream(Path.Join(rootFolder, ProductImagePath), FileMode.Create))
                    {
                        ImageFile.CopyTo(newFileStream);
                    }

                    product.ImageUrl = @"/images/products/" + fileName;

                }
                _unitOfWork.Product.Update(product);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(product);

        }
        [HttpGet]
        public IActionResult Delete(int id) {
            Product product = _unitOfWork.Product.Get(u => u.ProductId == id);

            return View(product);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult Delete(Product product)
        {
            if (!string.IsNullOrEmpty(product.ImageUrl)) {

                string productPath = product.ImageUrl.Replace("/", "\\").TrimStart('\\');
                string oldImagePath =System.IO.Path.Combine(_webHostEnvironment.WebRootPath, productPath);

                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
            }
            _unitOfWork.Product.Remove(product);
            _unitOfWork.Save();
                return RedirectToAction("Index");
                   }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #region
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Product> products = _unitOfWork.Product.GetAll();
            return Json(new { data=products});
        }

        #endregion
    }
}
