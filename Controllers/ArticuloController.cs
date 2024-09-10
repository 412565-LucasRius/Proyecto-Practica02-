using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Practica02_.Data;
using Proyecto_Practica02_.Models;

namespace Proyecto_Practica02_.Controllers
  {
  [Route("api/[controller]")]
  [ApiController]
  public class ArticuloController : Controller
    {

    private readonly DataBaseContext _dataBaseContext;

    public ArticuloController(DataBaseContext dataBaseContext)
      {
      _dataBaseContext = dataBaseContext;
      }

    [HttpGet]
    [Route("Get")]
    public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
      {
      var products = await _dataBaseContext.Products.ToListAsync();
      return Ok(products);
      }

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> PostProduct(Product articulo)
      {
      await _dataBaseContext.Products.AddAsync(articulo);
      await _dataBaseContext.SaveChangesAsync();

      return Ok();
      }

    [HttpGet]
    [Route("GetOne")]
    public async Task<IActionResult> GetProductById(int id)
      {
      Product product = await _dataBaseContext.Products.FindAsync(id);

      if (product == null)
        {
        return NotFound();
        }
      return Ok(product);
      }

    [HttpPut]
    [Route("Update")]
    public async Task<IActionResult> UpdateProduct(int id, Product product)
      {
      Product product1 = await _dataBaseContext.Products.FindAsync(id);

      if (product1 == null)
        {
        return NotFound();
        }

      product1!.PName = product.PName;
      product1!.Price = product.Price;
      product1.Available = product.Available;

      await _dataBaseContext.SaveChangesAsync();

      return Ok();
      }

    [HttpDelete]
    [Route("Delete")]
    public async Task<IActionResult> DeleteProduct(int id)
      {
      Product product = await _dataBaseContext.Products.FindAsync(id);

      if (product == null)
        {
        return NotFound();
        }

      _dataBaseContext.Products.Remove(product);
      await _dataBaseContext.SaveChangesAsync();

      return Ok();
      }
    }
  }
