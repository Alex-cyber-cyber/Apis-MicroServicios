using Microsoft.AspNetCore.Mvc;
using ProductService.Models;

namespace ProductService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private static readonly List<Product> Products = new()
    {
        new Product { Id = 1, Name = "Laptop", Price = 1200m },
        new Product { Id = 2, Name = "Mouse", Price = 25m },
        new Product { Id = 3, Name = "Keyboard", Price = 45m }
    };

    // GET /products
    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetAll()
    {
        return Ok(Products);
    }

    // GET /products/{id}
    [HttpGet("{id:int}")]
    public ActionResult<Product> GetById(int id)
    {
        var product = Products.FirstOrDefault(p => p.Id == id);
        if (product is null) return NotFound();

        return Ok(product);
    }
}
