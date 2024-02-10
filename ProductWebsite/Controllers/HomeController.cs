using Microsoft.AspNetCore.Mvc;
using MainApp.Models;
using MainApp.DataAccess.Repository.IRepostiory;
using System.Diagnostics;

namespace ProductWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger,IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;

        }

        public IActionResult Index()
        {
            IEnumerable<Product> products = _unitOfWork.Product.GetAll();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create() {
            Product product = new Product();

            return View(product);
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(product);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(product);

        }
        [HttpGet]
        public IActionResult Update(int id) {
            Product product = _unitOfWork.Product.Get(u => u.Id == id);

            return View(product);
        }
        [HttpPost]
        public IActionResult Update(Product product)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(product);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(product);

        }
        [HttpGet]
        public IActionResult Delete(int id) {
            Product product = _unitOfWork.Product.Get(u => u.Id == id);

            return View(product);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult Delete(Product product)
        {

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
