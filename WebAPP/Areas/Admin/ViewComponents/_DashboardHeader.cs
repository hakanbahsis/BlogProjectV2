using AutoMapper;
using Entity.DTOs.Users;
using Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebAPP.Areas.Admin.ViewComponents;

public class _DashboardHeader:ViewComponent
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;

    public _DashboardHeader(UserManager<AppUser> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var loggedInUser=await _userManager.GetUserAsync(HttpContext.User);
        var map=_mapper.Map<UserDto>(loggedInUser);
        var role=string.Join("",await _userManager.GetRolesAsync(loggedInUser));
        map.Role = role;
        return View(map);
    }
}
