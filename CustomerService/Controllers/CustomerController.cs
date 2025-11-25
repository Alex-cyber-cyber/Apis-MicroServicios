using Microsoft.AspNetCore.Mvc;
using CustomerService.Models;

namespace CustomerService.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomersController : ControllerBase
{
    private static readonly List<Customer> Customers = new()
    {
        new Customer { Id = 1, Name = "Juan Pérez", Email = "juan@example.com" },
        new Customer { Id = 2, Name = "María López", Email = "maria@example.com" }
    };

    // GET /customers
    [HttpGet]
    public ActionResult<IEnumerable<Customer>> GetAll()
    {
        return Ok(Customers);
    }

    // GET /customers/{id}
    [HttpGet("{id:int}")]
    public ActionResult<Customer> GetById(int id)
    {
        var customer = Customers.FirstOrDefault(c => c.Id == id);
        if (customer is null) return NotFound();

        return Ok(customer);
    }
}
