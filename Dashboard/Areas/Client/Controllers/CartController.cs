using Dashboard.Models;
using Dashboard.Repository;
using Dashboard.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Dashboard.Areas.Client.Controllers;

[Area("Client")]
public class CartController(ICartRepository cartRepository,IProductRepository productRepository) : Controller
{
   

    
    public IActionResult Index()
    {
        if (!Request.Cookies.TryGetValue("SessionId", out string? sessionId))
        {
            return BadRequest("Session ID not found");
        }
        
        Cart? cart =  cartRepository.SearchCartBySessionid(Request.Cookies["SessionId"]);
        if (cart!=null)
        {
            return View(cart.Products?.ToList());
        }
        return NotFound();
        
    }
    
        public IActionResult AddToCart(int productId)
        {
            // Obtener el sessionId de la cookie
            if (!Request.Cookies.TryGetValue("sessionId", out string? sessionId))
            {
                return BadRequest("No se encontró sessionId en la cookie.");
            }
            // Buscar o Crear el carrito para ese sessionId
            Cart? cart  = cartRepository.SearchCartBySessionid(sessionId);
            if (cart == null)
            {
                // Si no existe el carrito, se crea uno 
                cart = new Cart()
                {
                    SessionId = sessionId
                };
                cartRepository.Update(cart);
            }
            // Obtener el producto que se desea agregar
            Products? product = productRepository.GetProductsWhitCategory(productId);
            if (product == null)
            {
                return NotFound("Producto no encontrado.");
            }
            if (cart.Products != null)
            {
                // Crear la Lista de Productos en el carrito
                cart.Products.Add(product);
                cartRepository.Update(cart);
                TempData["AddToCart"] = true;
                return RedirectToAction("Index","Home");
            }

            return BadRequest("Error en agreegar a la lista de producctos");
        }

        public IActionResult DeleteProductOnCart(int productId)
        {
            if (!Request.Cookies.TryGetValue("sessionId", out string? sessionId))
            {
                return BadRequest("No se encontró sessionId en la cookie.");
            }
            Cart? cart = cartRepository.SearchCartBySessionid(Request.Cookies["SessionId"]);
            Products? products = productRepository.Get(productId);
            if (cart != null && cart.Products != null && cart.Products.Contains(products))
            {
                cart.Products.Remove(products);
                cartRepository.Update(cart);
                return RedirectToAction("Index");
            }
            return BadRequest("Ha Ocurrido un Error");
        }
}