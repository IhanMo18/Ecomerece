using Ecommerce.Domain.Interface.Service;
using Ecommerce.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Areas.Client.Controllers;

public class ReviewController(ILogger<ReviewController> _logger,
    IReviewService reviewService) : Controller
{
   [HttpPost]
    public void SendReview(int productId, string message, int stars)
    {
        var review = new Reviews()
        {
            Date = DateTime.Now,
            ProductId = productId,
            Message = message,
            Stars = stars
        };
        reviewService.Update(review);
    }
}