using Backend.Managers;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductsController : ControllerBase
    {
        public ProductsManager _manager = new ProductsManager();
        
        // GET: api/<ProductsController>
        [HttpGet(Name = "GetProducts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<Product>> Get()
        {

            if(ProductsManager._products.Count == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(_manager.getAll());
            }
        }

        // GET api/<ProductsController>/5
        [HttpGet("{barcode}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Product> Get(int barcode)
        {
            Product result;
            try
            {
                result = _manager.getByBarcode(barcode);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
            return Ok(result);
        }

        // POST api/<ProductsController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public ActionResult Add([FromBody] Product value)
        {
            try
            {
                _manager.add(value);
                return Ok("product created");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public ActionResult Put([FromBody] Product value)
        {
            _manager.update(value);
            return Ok();
        }
        // PUT api/<ProductsController>/increaseSupply/5
        [HttpPut("increaseSupply/{barcode}")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public ActionResult increase(int barcode, int amount)
        {
                Product result;
            
                result = _manager.getByBarcode(barcode);

                if(result != null) { 
                    _manager.increaseSupply(result, amount);
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            
            
        }


        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult Delete(int id)
        {
            Product result = _manager.getByBarcode(id);
            if(result == null)
            {
                return NotFound("Product not found");
            }
            else
            {
                _manager.delete(id);
                return Ok("Product deleted");
            }
        }
    }
}
