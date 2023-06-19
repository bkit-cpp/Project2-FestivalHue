using FestivalHue.Core.Interfaces;
using FestivalHue.ViewModel.Categories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FestivalHue_BEApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cate = await _categoryService.GetAllAsync();
            return Ok(cate);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetById(int id)
        {
            var cate = await _categoryService.GetById(id);
            return Ok(cate);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CategoryCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var categoryId = await _categoryService.Create(request);
            if (categoryId == 0)
                return null;
            var category = await _categoryService.GetById(categoryId);
            return CreatedAtAction(nameof(GetById), new { id = categoryId }, category);
        }
        [HttpPut ("[action]")]
        public async Task<IActionResult> Update([BindRequired] int id)
        {
            var result = await _categoryService.Update(id);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
