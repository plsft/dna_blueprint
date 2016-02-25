using System;
using System.Linq;
using Blue.Data.Constants;
using Blue.Data.Controllers;
using Blue.Data.Models;
using Blue.General;
using Blue.Library.Responses;

namespace Blue.Library.Services
{
    public sealed class UserServices
    {
        private readonly ControllerContainer.UserObjectController _userController;
        private readonly ControllerContainer.UserRolesController _userRolesController;
        private readonly ControllerContainer.RolesController _roleController;

        public UserServices()
        {
            _userController = new ControllerContainer.UserObjectController();
            _userRolesController = new ControllerContainer.UserRolesController();
            _roleController = new ControllerContainer.RolesController();
        }

        public AuthDataResponse Login(string username, string pwd)
        {
            var user = _userController.Select("where u_logon_name=@0 and u_user_security_password = @1", username, pwd)?.FirstOrDefault();

            if (user == null)
            {
                return new AuthDataResponse
                {
                    Success = false,
                    Message = "Invalid username or password.",
                };
            }

            var roles = _userRolesController.Select("where UserID=@0", user.g_user_id).ToList();

            if (!roles.Any())
            {
                user.Roles = new Role[1];
                user.Roles[0] = new Role { RoleID = 1, RoleName = "Users" };
            }
            else
                user.Roles = _roleController.Select($"where RoleID in ({string.Join(",", roles.Select(r => r.RoleId).ToArray())})").ToArray();

            var result = new AuthDataResponse(user)
            {
                Success = true
            };

            result.Message = result.AuthResult.User.PwdExpired ? "Your password has expired." : BlueConstants.SUCCESS;

            return result;
        }
        public AuthDataResponse Login(string g_user_id)
        {
            var user = _userController.Select("where g_user_id=@0", g_user_id)?.FirstOrDefault();

            if (user == null)
            {
                return new AuthDataResponse
                {
                    Success = false,
                    Message = "Invalid user identifier.",
                };
            }

            var roles = _userRolesController.Select("where UserID=@0", user.g_user_id).ToList();

            if (!roles.Any())
            {
                user.Roles = new Role[1];
                user.Roles[0] = new Role { RoleID = 1, RoleName = "Users" };
            }
            else
                user.Roles = _roleController.Select($"where RoleID in ({string.Join(",", roles.Select(r => r.RoleId).ToArray())})").ToArray();

            var result = new AuthDataResponse(user)
            {
                Success = true
            };

            result.Message = result.AuthResult.User.PwdExpired ? "Your password has expired." : BlueConstants.SUCCESS;

            return result;
        }


/*        public AuthDataResponse Register(User user)
        {
            throw new Exception("Registration is not possible.");
            var usr = _userController.Select("where u_logon_name=@0", user.Username).FirstOrDefault();

            if (usr != null)
            {
                return new AuthDataResponse(usr)
                {
                    Success = true,
                    Message = BlueConstants.SUCCESS
                };
            }

            user.Password = Crypto.HashString(user.Password);
            user.Expires = DateTime.Now.AddDays(90);

            var g_user_id = _userController.Save(user, true);
            _userRolesController.Save(new UserRoles
            {
                RoleId = (int) Data.Enums.UserRoles.User,
                UserId = g_user_id
            });

            var u = _userController.Select(userId);
            var roles = _userRolesController.Select("where userId=@0", userId).ToList();

            if (!roles.Any())
            {
                user.Roles = new Role[1];
                user.Roles[0] = new Role {ID = 1, RoleName = "Users"};
            }
            else
                user.Roles = _roleController.Select($"where ID in ({string.Join(",", roles.Select(r => r.RoleId).ToArray())})").ToArray();

            return new AuthDataResponse(u)
            {
                Success = true,
                Message = BlueConstants.SUCCESS
            };
        } */
    }
}
