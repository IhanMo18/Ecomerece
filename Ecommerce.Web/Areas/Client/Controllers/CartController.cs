using Ecommerce.Domain.Interface.Repository;
using Ecommerce.Domain.Interface.Service;
using Ecommerce.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Areas.Client.Controllers;

[Area("Client")]
public class CartController(ICartService cartService,IProductBaseRepository productBaseRepository) : Controller
{
   

    
    public async Task<IActionResult> Index()
    {
        if (!Request.Cookies.TryGetValue("SessionId", out string? sessionId))
        {
            return BadRequest("Session ID not found");
        }
        var cart = await cartService.SearchCartBySessionid(Request.Cookies["SessionId"]);
       
        if (cart == null) return View(new Cart() { ProductCart = new List<ProductCart>()});
        
        return View(cart);
    }
    
        public IActionResult AddToCart(int productId)
        {
            if(!Request.Cookies.TryGetValue("sessionId", out var sessionId)) return BadRequest();
            cartService.AddProductToCart(sessionId,productId,1);
            return  RedirectToAction("Index", "Home");
        }
        
        [HttpPost]
        public async Task<IActionResult> UpdateCartQuantity(int productId, int quantity, int change = 0)
        {
            if (!Request.Cookies.TryGetValue("sessionId", out var sessionId))
            {
                return BadRequest("No se encontró sessionId en la cookie.");
            }

            var cart = await cartService.SearchCartBySessionid(sessionId);
            
            var productCart = cart.ProductCart.FirstOrDefault(cp => cp.ProductId == productId);
            if (productCart == null)
            {
                return BadRequest("Producto no encontrado en el carrito.");
            }

            // Si se usaron los botones, se ajusta la cantidad
            if (change != 0)
            {
                quantity = productCart.Quantity + change;
            }
            
            productCart.Quantity = Math.Max(1, quantity);
            cartService.Save();

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> DeleteProductOnCart(int productId)
        {
            if (!Request.Cookies.TryGetValue("sessionId", out var sessionId)) return BadRequest("No se encontró sessionId en la cookie.");
            
            var cart = await cartService.SearchCartBySessionid(Request.Cookies["SessionId"]);
            var productCart = cart.ProductCart.FirstOrDefault(cp => cp.ProductId == productId);
            
            if (productCart == null) return BadRequest("No existe ese producto en el carrito");
            
            cartService.RemoveProductFromCart(productCart);
            cart.LastActionTime=DateTime.UtcNow;
            cartService.Update(cart);
            cartService.Save();
            return RedirectToAction("Index");
        }
}