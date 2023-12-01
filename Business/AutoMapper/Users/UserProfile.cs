using AutoMapper;
using Entity.DTOs.Users;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper.Users;
public class UserProfile:Profile
{
    public UserProfile()
    {
        CreateMap<UserDto,AppUser>().ReverseMap();
        CreateMap<UserAddDto,AppUser>().ReverseMap();
        CreateMap<UserUpdateDto,AppUser>().ReverseMap();
    }
}
