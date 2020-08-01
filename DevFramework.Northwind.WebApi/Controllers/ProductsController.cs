using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DevFramework.Northwind.WebApi.Controllers
{
    public class ProductsController : ApiController
    {
        //Web api katmanında aşağıdaki dependency injection'un sağlanması için packaga managerdan WebApiContrib.IOC.Ninject'i kurman gerekiyor. Bu paketi kurunca Ninject de otomantik olarak eklenecektir. Diğer katmanlardaki indirilen sürümlerle aynı mı kontrol et.
        //Ayrıca Ninject.MVC5'i de kur. Ve Ninject.Web.Common ve Ninject.Web.Common.WebHost'u en son sürüme çek.
        //Bu işlemleri yapınca App_Start'ın altına NinjectWebCommon diye bir startup sınıfı eklenecektir.

        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public List<Product> Get()
        {
            return _productService.GetAll();
        }
    }
}
