using SocialBrothersCase.DataAccess.Abstract;
using SocialBrothersCase.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialBrothersCase.DataAccess.Concrete
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDBContext _db;

        public CategoryRepository(ApplicationDBContext db)
        {
            _db = db;
        }

        public List<Category> GetAll()
        {
            return _db.Categories.ToList();
        }

        public Category Add(Category category)
        {
           _db.Categories.Add(category);
            _db.SaveChanges();
            return category;
        }
       

        public Category GetById(int id)
        {
            var category = _db.Categories.FirstOrDefault(cat => cat.CategoryId == id);
            return category;
        }

        public void Remove(int id)
        {
            var deletedCategory=GetById(id);
            _db.Categories.Remove(deletedCategory);
            _db.SaveChanges();
        }

        public void Update(Category category)
        {
            _db.Categories.Update(category);
            _db.SaveChanges();
        }
    }
}
