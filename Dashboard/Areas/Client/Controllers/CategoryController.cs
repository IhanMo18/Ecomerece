using Dashboard.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Areas.Client.Controllers;

[Area("Client")]
public class CategoryController : Controller
{
    public readonly ILogger<CategoryController> _logger;
    private readonly ICategoryRepository _categoryRepository;

    public CategoryController(ILogger<CategoryController> logger,ICategoryRepository categoryRepository)
    {
        _logger = logger;
        _categoryRepository = categoryRepository;
    }
    
    public IActionResult CreateCategory()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult CreateCategory(Category category)
    {
        if (ModelState.IsValid)
        {
            _categoryRepository.Update(category);
            return RedirectToAction("Index","Home");
        }
        
        return View();
    }
}