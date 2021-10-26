using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TracingSystem.Helper;
using TracingSystem.Models;

namespace TracingSystem.Service
{
    public class AuthorityService : IAuthorityService
    {

        private readonly SystemTrackingDBContext _db;

        public AuthorityService(SystemTrackingDBContext db)
        {
            _db = db;
        }
        public ServiceResult Login(string account, string pd)
        {

            if (string.IsNullOrEmpty(account) || string.IsNullOrEmpty(pd))
            {
                return ServiceResult.Fail("請輸入帳號和密碼");
            }
            else
            {
                // 登入驗證
                var loginAdmin = ValidateLogin(account, pd);
                if (loginAdmin == null)
                {
                    return ServiceResult.Fail("帳號或密碼錯誤");
                }

                var permission = GetPermission(loginAdmin.UserRole);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, account),
                    new Claim("FullName", loginAdmin.UserName),
                    new Claim("UserId", loginAdmin.Id.ToString()),
                    new Claim("UserRole", loginAdmin.UserRole.ToString()),
                    new Claim("ResolveIssue", permission.ResolveIssue.ToString()),
                    new Claim("CreateIssue", permission.CreateIssue.ToString()),
                    new Claim("UpdateIssue", permission.UpdateIssue.ToString()),
                    new Claim("DeleteIssue", permission.DeleteIssue.ToString()),
                };
               
                return ServiceResult.Success("登入成功",claims);
            }
        }

        /// <summary>
        /// 登入驗證
        /// </summary>
        /// <param name = "account" ></ param >
        /// < param name="pd"></param>
        /// <returns></returns>
        private TrackingUser ValidateLogin(string account, string pd)
        {
            TrackingUser user = _db.TrackingUsers.FirstOrDefault(x => x.Account == account);

            if(user == null)
            {
                return null;
            }
            bool result = HashHelper.Verify(pd, user.Password);

            if(result)
            {
               return user;
            }
            else
            {
                return null;
            }
            

        }
        private RolePermission GetPermission(int userRole)
        {
            RolePermission permission = _db.RolePermissions.FirstOrDefault(x => x.Id == userRole);
            return permission;
        }
    }
}
