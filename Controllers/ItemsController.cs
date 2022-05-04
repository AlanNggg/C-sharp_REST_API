using Catalog.Entities;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers
{
  // GET /items
  [ApiController]
  [Route("[controller]")] //  use controller name
  public class ItemsController : ControllerBase
  {
    private readonly InMemItemsRepository repository;

    public ItemsController()
    {
      repository = new InMemItemsRepository();
    }

    // Get /items
    [HttpGet]
    public IEnumerable<Item> GetItems()
    {
      var items = repository.GetItems();
      return items;
    }

    // GET /items/{id}
    [HttpGet("{id}")]
    public ActionResult<Item> GetItem(Guid id)
    {
      var item = repository.GetItem(id);

      if (item is null)
      {
        return NotFound();
      }

      return Ok(item);
    }
  }
}