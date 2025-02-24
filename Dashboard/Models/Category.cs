using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Dashboard.Models;

public class Category
{
    [Key][Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required][ValidateNever]
    public List<Products> ProductsList { get; set; }
}