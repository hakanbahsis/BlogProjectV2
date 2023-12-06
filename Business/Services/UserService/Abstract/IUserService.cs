using Entity.DTOs.Users;
using Entity.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.UserService.Abstract;
public interface IUserService
{
    Task<List<UserDto>> GetAllUsersWithRoleAsync();
    Task<List<AppRole>> GetAllRolesAsync();
    Task<IdentityResult> CreateUserAsync(UserAddDto userAddDto);
    Task<IdentityResult> UpdateUserAsync(UserUpdateDto userUpdateDto);
    Task<(IdentityResult identityResult,string? email)> DeleteUserAsync(Guid userId);
    Task<AppUser> GetAppUserByIdAsync(Guid userId);
    Task<string> GetUserRoleAsync(AppUser appUser);
    Task<UserProfileDto> GetUserProfileAsync();
    Task<bool> UserProfileUpdateAsync(UserProfileDto userProfileDto);
}
