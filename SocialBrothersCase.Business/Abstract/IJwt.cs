using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialBrothersCase.Business.Abstract
{
    public interface IJwt
    {
        string Authenticate(string username, string password);
    }
}
