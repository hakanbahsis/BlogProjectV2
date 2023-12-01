﻿using AutoMapper;
using Business.Extensions;
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
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<AppRole> _roleManager;
    private readonly IMapper _mapper;
    private readonly IToastNotification _toast;
    private readonly IValidator<AppUser> _validator;

    public UserController(UserManager<AppUser> userManager, IMapper mapper, RoleManager<AppRole> roleManager, IToastNotification toast, IValidator<AppUser> validator)
    {
        _userManager = userManager;
        _mapper = mapper;
        _roleManager = roleManager;
        _toast = toast;
        _validator = validator;
    }

    public async Task<IActionResult> Index()
    {
        var users = await _userManager.Users.ToListAsync();
        var map = _mapper.Map<List<UserDto>>(users);
        foreach (var item in map)
        {
            var findUser = await _userManager.FindByIdAsync(item.Id.ToString());
            var role = string.Join("", await _userManager.GetRolesAsync(findUser));

            item.Role = role;
        }
        return View(map);
    }

    [HttpGet]
    public async Task<IActionResult> Add()
    {
        var roles = await _roleManager.Roles.ToListAsync();
        return View(new UserAddDto { Roles = roles });
    }

    [HttpPost]
    public async Task<IActionResult> Add(UserAddDto userAddDto)
    {
        var map = _mapper.Map<AppUser>(userAddDto);
        var validator = await _validator.ValidateAsync(map);
        var roles = await _roleManager.Roles.ToListAsync();

        if (ModelState.IsValid)
        {
            map.UserName = userAddDto.Email;
            var result = await _userManager.CreateAsync(map, string.IsNullOrEmpty(userAddDto.Password) ? "" : userAddDto.Password);
            if (result.Succeeded)
            {
                var findRole = await _roleManager.FindByIdAsync(userAddDto.RoleId.ToString());
                await _userManager.AddToRoleAsync(map, findRole.ToString());
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
        var user = await _userManager.FindByIdAsync(userId.ToString());
        var roles = await _roleManager.Roles.ToListAsync();
        var map = _mapper.Map<UserUpdateDto>(user);
        map.Roles = roles;
        return View(map);
    }
    [HttpPost]
    public async Task<IActionResult> Update(UserUpdateDto userUpdateDto)
    {
        var user = await _userManager.FindByIdAsync(userUpdateDto.Id.ToString());
        if (user != null)
        {
            var userRole = string.Join("", await _userManager.GetRolesAsync(user));
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
                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        await _userManager.RemoveFromRoleAsync(user, userRole);
                        var findRole = await _roleManager.FindByIdAsync(userUpdateDto.RoleId.ToString());
                        await _userManager.AddToRoleAsync(user, findRole.Name);
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
        var user = await _userManager.FindByIdAsync(userId.ToString());
        var result = await _userManager.DeleteAsync(user);
        if (result.Succeeded)
        {
            _toast.AddSuccessToastMessage(Messages.User.Delete(user.Email), new ToastrOptions { Title = "Başarı" });
            return RedirectToAction("Index", "User", new { Area = "Admin" });
        }
        else
        {
            //foreach (var item in result.Errors)
            //{
            //    ModelState.AddModelError("", item.Description);
            //}
            result.AddToIdentityModelState(this.ModelState);
        }
        return NotFound();

    }
}
