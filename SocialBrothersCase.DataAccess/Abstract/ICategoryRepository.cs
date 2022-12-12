using SocialBrothersCase.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialBrothersCase.DataAccess.Abstract
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        Category GetById(int id);
        Category Add(Category category);
        void Update(Category category);
        void Remove(int id);
    }
}
