using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Entities.Concrete;
using DevFramework.Northwind.MvcWebUI.Models;

namespace DevFramework.Northwind.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult Index()
        {
            var model = new ProductListViewModel
            {
                Products = _productService.GetAll()
            };
            return View(model);
        }

        public string Add()
        {
            _productService.Add(new Product
            {
                CategoryId = 1,
                ProductName = "Gsm",
                QuantityPerUnit = "1",
                UnitPrice = 21
            });
            return "Added";
        }

        public string AddUpdate()
        {
            //Aşağıdaki işlem Transaction işlemini yapar. Yani birinci işlem başarılı olup, ikinci işlem başarılı olursa iki işlemi de uygular. Ama birinci işlem başarılı olup da ikinci işlem başarısız olması halinde birinci işlemdeki ekleme operasyonunu geri alır.
            _productService.TransactionalOperation(new Product
            {
                CategoryId = 1,
                ProductName = "Asus Computer",
                QuantityPerUnit = "1",
                UnitPrice = 21
            }, new Product
            {
                CategoryId = 1,
                ProductName = "Hp Computer",
                QuantityPerUnit = "1",
                UnitPrice = 30,
                ProductId = 2
            });

            return "Done";
        }
    }
}