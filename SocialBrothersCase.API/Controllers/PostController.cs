using AutoMapper;
using AutoMapper.Configuration.Conventions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using SocialBrothersCase.Business.Abstract;
using SocialBrothersCase.Entities.Dtos;
using SocialBrothersCase.Entities.Models;

namespace SocialBrothersCase.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        private readonly IHostEnvironment _env;
        private readonly IJwt _jwt;
        public PostController(IPostService postService, IMapper mapper, ICategoryService categoryService, IHostEnvironment env, IJwt jwt)
        {
            _postService = postService;
            _mapper = mapper;
            _categoryService = categoryService;
            _env = env;
            _jwt = jwt;
        }

        
        [HttpGet]
        public IActionResult Get()
        {            
            if (_postService.GetAll == null)
            {
                return NotFound();
            }
            var posts = _postService.GetAll();
            foreach (var post in posts)
            {
                post.ImagePath = CreateImageUrl(post.ImagePath);
            }

            return Ok(posts);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var post = _postService.GetById(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(_postService.GetById(id));
        }

        [HttpGet("Search")]
        public IActionResult Get(string searchString)
        {
            var postList=_postService.GetAll().Where(p=>p.Content.Contains(searchString));
            
            if (postList.Count()==0)
            {
                return NotFound();
            }
            foreach (var post in postList)
            {
                post.ImagePath = CreateImageUrl(post.ImagePath);
            }
            return Ok(postList);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post([FromForm] PostDto postDto)
        {
            var post = GetPostFromPostDto(postDto);
            if (_categoryService.GetById((int)postDto.CategoryId) != null)
            {
                _postService.Add(post);
                return Ok();
            }
            return BadRequest();
        }

        [Authorize]
        [HttpPut()]
        public IActionResult Put([FromForm]PostDto postDto)
        {            
            var post = GetPostFromPostDto(postDto);
            _postService.Update(post);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var posts = _postService.GetAll();
            if (posts == null)
            {
                return NotFound();
            }
            _postService.Remove(id);
            return Ok();
        }
        /// <summary>
        /// This method creates image Url using to the ImagePath property in Post model.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        [NonAction]

        public string CreateImageUrl(string filePath)
        {
            var baseUri = $"{Request.Scheme}://{Request.Host}/";
            string imageurl = $"{baseUri}images/{filePath}";
            return imageurl;
        }
        /// <summary>
        /// This method gets PostDto model and maps to Post model.
        /// Sending image file renames and saves under wwwroot/images folder with new name.
        /// 
        /// </summary>
        /// <param name="postDto"></param>
        /// <returns></returns>
        [NonAction]
        public Post GetPostFromPostDto(PostDto postDto)
        {

            Post post = _mapper.Map<Post>(postDto);
            string strRootPath = _env.ContentRootPath;
            Guid guid = Guid.NewGuid();
            string strNewImageName = guid.ToString() + postDto.Image.FileName;
            string strImagePath = Path.Combine(strRootPath + "wwwroot/images/" + strNewImageName);

            using (FileStream fs = new FileStream(strImagePath, FileMode.Create))
            {
                post.Image.CopyToAsync(fs);
                fs.Close();
                post.ImagePath = strNewImageName;
            }
            return post;
        }

        [HttpPost("Control")]
        public IActionResult Control(UserDto user)
        {
            string token = _jwt.Authenticate(user.Name, user.Password);
            if (token == null)
            {
                return Unauthorized("Unauthorized Access...");
            }
            return Ok(token);
        }
    }
}
