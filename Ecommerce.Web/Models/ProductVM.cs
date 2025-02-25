using Ecommerce.Domain.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Dashboard.Models;

public class ProductVm
{

    [ValidateNever]
    public Ecommerce.Domain.Models.Products Product { get; set; }
    
    [ValidateNever]
    public IEnumerable<SelectListItem> Categories { get; set; }
    
    
    [ValidateNever]
    public IEnumerable<Category> AllCategories { get; set; }
    
    [ValidateNever]
    
    public Reviews Reviews { get; set; }
    
}