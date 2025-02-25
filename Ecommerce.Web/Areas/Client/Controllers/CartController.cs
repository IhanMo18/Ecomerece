
using Ecommerce.Domain.Interface.Repository;
using Ecommerce.Domain.Interface.Service;
using Ecommerce.Domain.Models;
using Ecommerce.Services.CartService;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Areas.Client.Controllers;

[Area("Client")]
public class CartController(ICartService cartService,IProductRepository productRepository) : Controller
{
   

    
    public async Task<IActionResult> Index()
    {
        if (!Request.Cookies.TryGetValue("SessionId", out string? sessionId))
        {
            return BadRequest("Session ID not found");
        }
        var cart = await cartService.SearchCartBySessionid(Request.Cookies["SessionId"]);
        return View(cart.Products?.ToList());
    }
    
        public async Task<IActionResult> AddToCart(int productId)
        {
            // Obtener el sessionId de la cookie
            if (!Request.Cookies.TryGetValue("sessionId", out string? sessionId))
            {
                return BadRequest("No se encontró sessionId en la cookie.");
            }
            // Buscar o Crear el carrito para ese sessionId
            Cart? cart  = await cartService.SearchCartBySessionid(sessionId);
            
            // Obtener el producto que se desea agregar
            Products? product = productRepository.GetProductsWhitCategory(productId);
            if (product == null)
            {
                return NotFound("Producto no encontrado.");
            }
            if (cart != null && cart.Products != null)
            {
                // Crear la Lista de Productos en el carrito
                cart.Products.Add(product);
                cartService.Update(cart);
                TempData["AddToCart"] = true;
                return RedirectToAction("Index","Home");
            }

            return BadRequest("Error en agreegar a la lista de producctos");
        }

        public async Task<IActionResult> DeleteProductOnCart(int productId)
        {
            if (!Request.Cookies.TryGetValue("sessionId", out string? sessionId))
            {
                return BadRequest("No se encontró sessionId en la cookie.");
            }
            var cart = await cartService.SearchCartBySessionid(Request.Cookies["SessionId"]);
            
            var products = await productRepository.GetAsync(productId);
            if (cart.Products == null || !cart.Products.Contains(products)) return BadRequest("Ha Ocurrido un Error");
            
            cart.Products.Remove(products);
            cartService.Update(cart);
            return RedirectToAction("Index");
        }
}