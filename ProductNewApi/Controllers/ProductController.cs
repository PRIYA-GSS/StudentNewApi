using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StudentNewApi.Controllers
{
    [Route("api/Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        [Route("GetProduct")]
        public async Task<IActionResult> GetAll()
        {
     
        //    var products = await _service.GetAllAsync();
            return Ok("products");
        }
        [HttpGet("GetProducts/{id}")]
        public async Task<IActionResult> GetProductById(int idd)
        {
            //    var products = await _service.GetAllAsync();
            return Ok("products");
        }
    }
}
