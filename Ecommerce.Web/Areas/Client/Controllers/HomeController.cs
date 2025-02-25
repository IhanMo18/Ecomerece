using System.Diagnostics;
using Dashboard.Models;
using Ecommerce.Domain.Interface.Repository;
using Ecommerce.Domain.Interface.Service;
using Ecommerce.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Dashboard.Areas.Client.Controllers;

[Area("Client")]
public class HomeController(
    ILogger<HomeController> logger,
    IProductRepository productRepository,
    ICategoryRepository categoryRepository,
    IWebHostEnvironment webHostEnvironment,
    ICartService cartService)
    : Controller
{
    private readonly ILogger<HomeController> _logger = logger;

    public async Task<IActionResult> Index()
    {
        List<Products> productWhitCategoryList = new List<Products>();
        foreach (var product in await productRepository.GetAllAsync() )
        {
           var productWhitCategory = productRepository.GetProductsWhitCategory(product.Id);
           if (productWhitCategory!=null)productWhitCategoryList.Add(productWhitCategory);
        }
        
        return View(productWhitCategoryList);
    }
    
    [AutoValidateAntiforgeryToken]
    public async Task<IActionResult> Create()
    {
        var listCategories = await categoryRepository.GetAllAsync();
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
        cart.Products ??= new List<Products>();
        return View(productVm);

    }
    
    
    [HttpPost]
    public async Task<IActionResult> Create(ProductVm productsVm, IFormFile? file)
    {
        if (!ModelState.IsValid)
        {
            var listCategories = await categoryRepository.GetAllAsync();
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
        
        productRepository.Update(productsVm.Product);

        TempData["ProductAddSucces"] = true;
        
        return RedirectToAction("Index");
    }

    
    
    public async  Task<IActionResult> Details(int id)
    {
        if (ModelState.IsValid)
        {
            var product = await productRepository.GetAsync(id);
            var category = await categoryRepository.GetAllAsync();
            if (product!=null)
            {
                var productVm = new ProductVm()
                {
                    AllCategories = category,
                    Product = product
                };
                return View(productVm);
            }

            return NotFound();
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