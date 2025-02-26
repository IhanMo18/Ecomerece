using System.Diagnostics;
using Dashboard.Models;
using Ecommerce.Domain.Interface.Service;
using Ecommerce.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Dashboard.Areas.Client.Controllers;

[Area("Client")]
public class HomeController(
    ILogger<HomeController> logger,
    IProductService productService,
    ICategoryService categoryService,
    IWebHostEnvironment webHostEnvironment,
    ICartService cartService)
    : Controller
{
    private readonly ILogger<HomeController> _logger = logger;

    public async Task<IActionResult> Index()
    {
        List<Products> productWhitCategoryList = new List<Products>();
        foreach (var product in await productService.GetAllAsync() )
        {
           var productWhitCategory = productService.GetProductsWithCategory(product.Id);
           if (productWhitCategory!=null)productWhitCategoryList.Add(productWhitCategory);
        }
        
        return View(productWhitCategoryList);
    }
    
    [AutoValidateAntiforgeryToken]
    public async Task<IActionResult> Create()
    {
        var listCategories = await categoryService.GetAllAsync();
        var productVm = new ProductVm()
        {
            Categories = listCategories.Select(category => new SelectListItem()
            {
                Text = category.Name,
                Value = category.Id.ToString()
            }),
            Product = new Products()
        };
        var sessionId = Request.Cookies["SessionId"];
        if (sessionId == null) return BadRequest("Error,session Id sin establecer");
        var cart = await cartService.SearchCartBySessionid(sessionId);
        
        if (cart == null) return View(productVm);
        
        cart.Products = new List<Products>();
        return View(productVm);
    }
    
    
    [HttpPost]
    public async Task<IActionResult> Create(ProductVm productsVm, IFormFile? file)
    {
        if (!ModelState.IsValid)
        {
            var listCategories = await categoryService.GetAllAsync();
            TempData["Error"] = true;

            IEnumerable<SelectListItem> categories = listCategories.Select(category =>
                new SelectListItem()
                {
                    Text = category.Name,
                    Value = category.Id.ToString()
                });
            productsVm.Categories = categories;
            return View(productsVm);
        }

        string wwwRootPath = webHostEnvironment.WebRootPath;
        Console.WriteLine("wwwRootPath: " + wwwRootPath);

        // Si no hay archivo,Guardar el producto
        if (file != null)
        {
            var extension = Path.GetExtension(file.FileName);
            var fileName = Guid.NewGuid().ToString() + extension;
            var productPath = Path.Combine(wwwRootPath, "img", "product");
            if (!Directory.Exists(productPath))
            {
                Directory.CreateDirectory(productPath);
            }
            var filePath = Path.Combine(productPath, fileName);

            // Elimina la imagen anterior si existe
            if (!string.IsNullOrEmpty(productsVm.Product.ImgUrl))
            {
                string pathOldImg = Path.Combine(wwwRootPath, productsVm.Product.ImgUrl.TrimStart('/'));
                if (System.IO.File.Exists(pathOldImg))
                {
                    System.IO.File.Delete(pathOldImg);
                }
            }

            // Guarda la nueva imagen
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
        
            // Asigna la nueva URL de la imagen antes de guardar en BD
            productsVm.Product.ImgUrl = "/img/product/" + fileName;
        }
        
        productService.Update(productsVm.Product);

        TempData["ProductAddSucces"] = true;
        
        return RedirectToAction("Index");
    }

    
    
    public IActionResult Details(int productId)
    {
        if (ModelState.IsValid)
        {
            var productWhitAllReviews = productService.GetProductsWithAllReviews(productId);
            var productWhitCategory =   productService.GetProductsWithCategory(productId);

            if (productWhitCategory == null && productWhitAllReviews == null) return BadRequest();
           
            var productVm = new ProductVm()
            {
                Category = productWhitCategory.Category,
                AllReviews = productWhitAllReviews?.reviews,
                Product = productWhitCategory
            }; return View(productVm);
        }
        return View();
    }
    
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}