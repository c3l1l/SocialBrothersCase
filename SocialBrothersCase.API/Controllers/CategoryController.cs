using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialBrothersCase.Business.Abstract;
using SocialBrothersCase.Entities.Dtos;
using SocialBrothersCase.Entities.Models;

namespace SocialBrothersCase.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        IMapper _mapper;
        ICategoryService _categoryService;

        public CategoryController(IMapper mapper, ICategoryService categoryService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            if (_categoryService.GetAll == null)
            {
                return NotFound();
            }
            return Ok(_categoryService.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var category = _categoryService.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(_categoryService.GetById(id));
        }
        [HttpPost]
        public IActionResult Post(Category category)
        {                         
                return Ok(_categoryService.Add(category));            

        }
        [HttpPut()]
        public IActionResult Put(Category category)
        {           
            _categoryService.Update(category);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var categories = _categoryService.GetAll();
            if (categories == null)
            {
                return NotFound();
            }
            _categoryService.Remove(id);
            return Ok();
        }
    }
}
