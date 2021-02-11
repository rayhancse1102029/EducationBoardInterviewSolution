using DynamicSideBar.Areas.Auth.Models;
using DynamicSideBar.Data.Entity;
using DynamicSideBar.Data.Entity.Auth;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DynamicSideBar.Sevices.AuthServices.Interfaces
{
    public interface IUserInfoes
    {
        Task<ApplicationUser> GetUserBasicInfoes(string userName);
        //Task<int> GetMaxUserId();
        Task<IEnumerable<ApplicationUser>> GetAllUser();
        Task<ApplicationUser> GetUserInfoByUserEmail(string email);

        #region

        Task<int> SaveRole(RolesViewModel  rolesViewModel);
        Task<IEnumerable<IdentityRole>> GetAllRoles();
        Task<string> GetRoleIdByUserId(string userId);
        //Task<int> DeleteRole();

        #endregion
    }
}
