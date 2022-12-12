using SocialBrothersCase.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialBrothersCase.DataAccess.Abstract
{
    public interface IPostRepository
    {
        List<Post> GetAll();
        Post GetById(int id);
        Post Add(Post post);
        void Update(Post post);
        void Remove(int id);
    }
}
