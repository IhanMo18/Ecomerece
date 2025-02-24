using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Dashboard.Models.ViewModel;

public class ProductVm
{

    [ValidateNever]
    public Products Product { get; set; }
    
    [ValidateNever]
    public IEnumerable<SelectListItem> Categories { get; set; }
    
    
    [ValidateNever]
    public IEnumerable<Category> AllCategories { get; set; }
    
    [ValidateNever]
    
    public Reviews Reviews { get; set; }
    
}