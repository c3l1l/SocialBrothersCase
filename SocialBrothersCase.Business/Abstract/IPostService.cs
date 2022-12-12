using SocialBrothersCase.Entities.Dtos;
using SocialBrothersCase.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialBrothersCase.Business.Abstract
{
    public interface IPostService
    {
        List<Post> GetAll();
        Post GetById(int id);
        Post Add(Post post);
        void Update(Post post);
        void Remove(int id);
    }
}
