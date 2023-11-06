using Microsoft.AspNetCore.Mvc;
using P04WeatherForecastAPI.Client.Models;
using P06Shop.Shared;
using P06Shop.Shared.Services.ProductService;
using P06Shop.Shared.Shop;
using System.ComponentModel.DataAnnotations;

namespace P05Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoeController : Controller
    {
        private readonly IShoeService _shoeService;
        private readonly int MAX_CAPACITY=100;
        private int currentShoeNum = 0;

        public ShoeController(IShoeService productService)
        {
            _shoeService = productService;
        }

        [HttpGet("getShoe")]
        public async Task<ActionResult<ServiceResponse<Shoe>>> GetAsync(int id)
        {

            if (id < 1 || id > MAX_CAPACITY)
            {
                return StatusCode(404, $"This shoe doesn't exist");
            }
            var result = await _shoeService.GetProductsAsync();
            if (result.Success)
                return Ok(result.Data[id - 1]);
            else
                return StatusCode(500, $"Internal server error {result.Message}");

        }

        [HttpGet("allShoes")]
        public async Task<ActionResult<ServiceResponse<List<Shoe>>>> GetAllShoes()
        {

            var result = await _shoeService.GetProductsAsync();

            if (result.Success)
                return Ok(result);
            else
                return  StatusCode(500, $"Internal server error {result.Message}");
        }

        [HttpPost]
        public string addShoe([FromBody] Shoe shoe)
        {
            return
                $"shoe details :{shoe.ToString}";
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShoe(long id, Shoe shoe)
        {
            if (id != shoe.Id)
            {
                return BadRequest();
            }

            if (id > currentShoeNum) return NoContent();

            return Ok($"Shoe wiht id: {id} has been updated");
        }

        [HttpPost("addShoe")]
        public IActionResult addingShoe([FromBody] Shoe shoe)
        {


            if (shoe == null)
                return BadRequest();


            if (currentShoeNum >= MAX_CAPACITY)
            {
                return StatusCode(500);
            }

            int id = ++currentShoeNum;
            return Created($"https://localhost:7230/api/shoeStore/GetShoe/{id}", shoe);
        }

        [HttpDelete("deleteBook")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id > MAX_CAPACITY)
            {
                return BadRequest("Wrong index");
            }
            return Ok($"Shoe with id : {id} has been deleted");
        }






    }
}
