using SocialBrothersCase.Business.Abstract;
using SocialBrothersCase.DataAccess.Abstract;
using SocialBrothersCase.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialBrothersCase.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Category Add(Category category)
        {
            return _categoryRepository.Add(category);
        }

        public List<Category> GetAll()
        {
           return _categoryRepository.GetAll();
        }

        public Category GetById(int id)
        {
            return _categoryRepository.GetById(id);
        }

        public void Remove(int id)
        {
             _categoryRepository.Remove(id);
        }

        public void Update(Category category)
        {
            _categoryRepository.Update(category);
        }
    }
}
