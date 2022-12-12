using AutoMapper;
using SocialBrothersCase.Entities.Dtos;
using SocialBrothersCase.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialBrothersCase.DataAccess.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Post, PostDto>().ReverseMap();
        }
    }
}
