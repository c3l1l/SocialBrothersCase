using SocialBrothersCase.Business.Abstract;
using SocialBrothersCase.DataAccess.Abstract;
using SocialBrothersCase.Entities.Dtos;
using SocialBrothersCase.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialBrothersCase.Business.Concrete
{
    public class PostManager : IPostService
    {
       private IPostRepository _postRepository;

        public PostManager(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public Post Add(Post post)
        {
           return _postRepository.Add(post);
        }

        public List<Post> GetAll()
        {
           return _postRepository.GetAll();
        }

        public Post GetById(int id)
        {
          return  _postRepository.GetById(id);
        }

        public void Remove(int id)
        {
            _postRepository.Remove(id);
        }

        public void Update(Post post)
        {
            _postRepository.Update(post);
        }
    }
}
