using SocialBrothersCase.DataAccess.Abstract;
using SocialBrothersCase.Entities.Dtos;
using SocialBrothersCase.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialBrothersCase.DataAccess.Concrete
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDBContext _db;
        public PostRepository(ApplicationDBContext db)
        {
           _db= db;
        }       

        public List<Post> GetAll()
        {
           
            return _db.Posts.ToList();
        }
        public Post Add(Post post)
        {
            _db.Posts.Add(post);
            _db.SaveChanges();
            return post;
        }

        public Post GetById(int id)
        {
            var post = _db.Posts.FirstOrDefault(post => post.Id == id);
            return post;
        }

        public void Remove(int id)
        {
            var deletedPost= GetById(id);
            _db.Posts.Remove(deletedPost);
            _db.SaveChanges();
        }

        public void Update(Post post)
        {
           
            _db.Posts.Update(post);
            _db.SaveChanges();            
        }
    }
}
