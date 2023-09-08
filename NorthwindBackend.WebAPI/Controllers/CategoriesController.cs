using Microsoft.AspNetCore.Mvc;
using NorthwindBackend.Business.Abstract;

namespace NorthwindBackend.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("getAll")]
        public IActionResult GetList() { 
            var result = _categoryService.GetList();

            if (result.IsSuccess)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }
    }
}
