using AutoMapper;
using Business.Extensions;
using Business.Services.UserService.Abstract;
using Entity.DTOs.Articles;
using Entity.DTOs.Users;
using Entity.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using WebAPP.ResultMessages;
using static WebAPP.ResultMessages.Messages;

namespace WebAPP.Areas.Admin.Controllers;
[Area("Admin")]
public class UserController : Controller
{
 
    private readonly RoleManager<AppRole> _roleManager;
    private readonly IMapper _mapper;
    private readonly IToastNotification _toast;
    private readonly IValidator<AppUser> _validator;
    private readonly IUserService _userService;

    public UserController( IMapper mapper, IToastNotification toast, IValidator<AppUser> validator, IUserService userService)
    {
        _mapper = mapper;
        _toast = toast;
        _validator = validator;
        _userService = userService;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _userService.GetAllUsersWithRoleAsync();
        return View(result);
    }

    [HttpGet]
    public async Task<IActionResult> Add()
    {
        var roles = await _userService.GetAllRolesAsync();
        return View(new UserAddDto { Roles = roles });
    }

    [HttpPost]
    public async Task<IActionResult> Add(UserAddDto userAddDto)
    {
        var map = _mapper.Map<AppUser>(userAddDto);
        var validator = await _validator.ValidateAsync(map);
        var roles = await _userService.GetAllRolesAsync();

        if (ModelState.IsValid)
        {
            var result = await _userService.CreateUserAsync(userAddDto);
            if (result.Succeeded)
            {
                _toast.AddSuccessToastMessage(Messages.User.Add(userAddDto.Email), new ToastrOptions { Title = "Başarı" });
                return RedirectToAction("Index", "User", new { Area = "Admin" });
            }
            else
            {
                //foreach (var item in result.Errors)
                //{
                //    ModelState.AddModelError("", item.Description);
                //}
                result.AddToIdentityModelState(this.ModelState);
                validator.AddToModelState(this.ModelState);
                return View(new UserAddDto { Roles = roles });
            }
        }
        return View(new UserAddDto { Roles = roles });
    }

    [HttpGet]
    public async Task<IActionResult> Update(Guid userId)
    {
        var user = await _userService.GetAppUserByIdAsync(userId);
        var roles = await _userService.GetAllRolesAsync();
        var map = _mapper.Map<UserUpdateDto>(user);
        map.Roles = roles;
        return View(map);
    }
    [HttpPost]
    public async Task<IActionResult> Update(UserUpdateDto userUpdateDto)
    {
        var user = await _userService.GetAppUserByIdAsync(userUpdateDto.Id);
        if (user != null)
        {

            var roles = await _roleManager.Roles.ToListAsync();
            if (ModelState.IsValid)
            {
                //user.FirstName = userUpdateDto.FirstName;
                //user.LastName = userUpdateDto.LastName;
                //user.Email = userUpdateDto.Email;
                var map = _mapper.Map(userUpdateDto, user);
                var validation = await _validator.ValidateAsync(map);
                if (validation!.IsValid)
                {

                    user.UserName = userUpdateDto.Email;
                    user.SecurityStamp = Guid.NewGuid().ToString();
                    var result = await _userService.UpdateUserAsync(userUpdateDto);
                    if (result.Succeeded)
                    {

                        _toast.AddSuccessToastMessage(Messages.User.Update(userUpdateDto.Email), new ToastrOptions { Title = "Başarı" });
                        return RedirectToAction("Index", "User", new { Area = "Admin" });
                    }
                    else
                    {
                        //foreach (var item in result.Errors)
                        //{
                        //    ModelState.AddModelError("", item.Description);
                        //}
                        result.AddToIdentityModelState(this.ModelState);//foreach döngüsü
                        validation.AddToModelState(this.ModelState);
                        return View(new UserUpdateDto { Roles = roles });
                    }
                }
                else
                {
                    validation.AddToModelState(this.ModelState);
                    return View(new UserUpdateDto { Roles = roles });
                }
            }
        }
        return NotFound();

    }

    public async Task<IActionResult> Delete(Guid userId)
    {
        var result = await _userService.DeleteUserAsync(userId);
        if (result.identityResult.Succeeded)
        {
            _toast.AddSuccessToastMessage(Messages.User.Delete(result.email), new ToastrOptions { Title = "Başarı" });
            return RedirectToAction("Index", "User", new { Area = "Admin" });
        }
        else
        {
            //foreach (var item in result.Errors)
            //{
            //    ModelState.AddModelError("", item.Description);
            //}
            result.identityResult.AddToIdentityModelState(this.ModelState);
        }
        return NotFound();

    }

    [HttpGet]
    public async Task<IActionResult> Profile()
    {
        var profile = await _userService.GetUserProfileAsync();

        return View(profile);
    }

    [HttpPost]
    public async Task<IActionResult> Profile(UserProfileDto userProfileDto)
    {
        if (ModelState.IsValid)
        {
            var result = await _userService.UserProfileUpdateAsync(userProfileDto);
            if (result)
            {
                _toast.AddSuccessToastMessage(Messages.User.ChangedPasswordAndProfile(), new ToastrOptions { Title = "Başarı" });
                return RedirectToAction("Index", "User", new { Area = "Admin" });
            }
            else
            {
                var profile = await _userService.GetUserProfileAsync();
                _toast.AddErrorToastMessage(Messages.User.ErrorChangedProfile(), new ToastrOptions { Title = "Hata !" });
                return View(profile);

            }
        }
        else
        {
            return NotFound();
        }
    }
}
