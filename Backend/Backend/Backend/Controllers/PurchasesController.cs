using Backend.Managers;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PurchasesController : ControllerBase
    {
        PurchasesManager _manager = new PurchasesManager();
        
        // GET: api/<PurchasesController>
        [HttpGet(Name = "GetPurchases")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<Purchase>> Get()
        {

            if(_manager.getAll().Count == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(_manager.getAll());
            }
        }

        // GET api/<PurchasesController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Purchase> Get(int id)
        {
            Purchase result;
            try
            {
                result = _manager.getById(id);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
            return Ok(result);
        }

        // POST api/<PurchasesController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public ActionResult Add([FromBody] Purchase value)
        {
            try
            {
                _manager.create(value);
                return Ok("purchase created");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // POST api/<PurchasesController>/item
        [HttpPost("item")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public ActionResult Add([FromBody] Product value)
        {
            try
            {
                _manager.addItemToCurrentPurchase(value);
                return Ok("item added");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // DELETE api/<PurchasesController>/item
        [HttpDelete("item")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public ActionResult Delete([FromBody] Product value)
        {
            try
            {
                _manager.removeItemFromCurrentPurchase(value);
                return Ok("item removed");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<PurchasesController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public ActionResult Put([FromBody] Purchase value)
        {
            _manager.update(value);
            return Ok();
        }



        // DELETE api/<PurchasesController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult Delete(int id)
        {
            Purchase result = _manager.getById(id);
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
