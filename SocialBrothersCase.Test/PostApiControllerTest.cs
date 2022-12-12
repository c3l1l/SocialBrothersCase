using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SocialBrothersCase.API.Controllers;
using SocialBrothersCase.Business.Abstract;
using SocialBrothersCase.DataAccess.Mapping;
using SocialBrothersCase.Entities.Dtos;
using SocialBrothersCase.Entities.Models;

namespace SocialBrothersCase.Test
{
    public class PostApiControllerTest
    {
        private readonly Mock<IPostService> _mockService;
        
        private readonly PostController _postController;
       

        public PostApiControllerTest()
        {

            _mockService = new Mock<IPostService>();
            _postController = new PostController(_mockService.Object, null, null );
            
        }
       
        [Fact]
        public void Get_ActionExecute_ReturnActionResult()
        {
            var posts = GetPostData();
            _mockService.Setup(m => m.GetAll()).Returns(posts);

            IActionResult result = _postController.Get();   
            
            Assert.IsAssignableFrom<IActionResult>(result);
            Assert.IsType<OkObjectResult>(result);

          
        }
        [Theory]
        [InlineData(2)]
        public void GetById_ActionExecute_ReturnOkResult(int id)
        {
            var post = GetPostData().First(p => p.Id == id);
            _mockService.Setup(m => m.GetById(id)).Returns(post);
            var actionResult = _postController.GetById(id);
            var okObjectResult = actionResult as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var model = okObjectResult.Value as Post;
            Assert.NotNull(model);
            Assert.Equal(id, model.Id);
        }
        [Theory]
        [InlineData(2)]
        public void GetById_IdInValid_ReturnNull(int id)
        {
            Post post = null;
            _mockService.Setup(m => m.GetById(id)).Returns(post);
            var result = _postController.GetById(id);
            Assert.IsType<NotFoundResult>(result);
        }
        //[Theory]
        //[InlineData(1)]
        //public void Put_ActionExecute_ReturnOkResult(int postId)
        //{
        //    var post = GetPostData().First(p => p.Id == postId);
        //    PostDto postDto = new PostDto();
        //    postDto.Id = post.Id;
        //    postDto.Title = post.Title;
        //    postDto.Content = post.Content;
        //    postDto.CategoryId = post.CategoryId;
        //    var result = _postController.Put(postDto);           
        //    _mockService.Setup(m => m.Update(post));
        //    Assert.IsType<OkObjectResult>(result);

        //}

        //[Fact]
        //public void Post_ActionExecute_ReturnOkResultWithPost()
        //{
        //    //var post = GetPostData().First(p => p.Id == 1);
        //    var postDto = GetPostDtoData().First();
        //    _mockService.Setup(m => m.Add(postDto)).Returns(postDto);
        //    //var mockMapper = new MapperConfiguration(cfg =>
        //    //{
        //    //    cfg.AddProfile(new MapProfile());
        //    //});
        //    //var mapper = mockMapper.CreateMapper();
        //    //mapper.Map<Post>(postDto);

        //    var result = _postController.Post(postDto);
        //    Assert.IsAssignableFrom<IActionResult>(result);
        //    Assert.IsType<OkObjectResult>(result);

        //}



        /*SEED DATA*/
        private List<Post> GetPostData()
        {
            List<Post> postData = new List<Post>()
            {
                new Post{ Id=1, Title="Test title 1", Content="Test Content 1", CategoryId=1, CreatedDate=DateTime.Now},
                new Post{ Id=2, Title="Test title 2", Content="Test Content 2", CategoryId=1, CreatedDate=DateTime.Now},
                new Post{ Id=3, Title="Test title 3", Content="Test Content 3", CategoryId=2, CreatedDate=DateTime.Now},
                new Post{ Id=4, Title="Test title 4", Content="Test Content 4", CategoryId=3, CreatedDate=DateTime.Now},
                new Post{ Id=5, Title="Test title 5", Content="Test Content 5", CategoryId=2, CreatedDate=DateTime.Now},
            };
            return postData;
        }
        private List<Post> GetPostDtoData()
        {
            List<Post> postDtoData = new List<Post>()
            {
                new Post{ Id=1, Title="Test title 1", Content="Test Content 1", CategoryId=1},
                new Post{ Id=2, Title="Test title 2", Content="Test Content 2", CategoryId=1},
                new Post{ Id=3, Title="Test title 3", Content="Test Content 3", CategoryId=2},
                new Post{ Id=4, Title="Test title 4", Content="Test Content 4", CategoryId=3},
                new Post{ Id=5, Title="Test title 5", Content="Test Content 5", CategoryId=2},            };
            return postDtoData;
        }

    }
}