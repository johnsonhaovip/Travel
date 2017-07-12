using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Model;
using Travel.DAL;

namespace Travel.BLL
{
   public class UserBusiness
    {
        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        public static List<Tab_user> GetAllUsers()
        {

            return DAL.UserAccess.GetAllUsers();
        }

       /// <summary>
       /// 添加用户
       /// </summary>
       /// <param name="tab_user"></param>
       /// <returns></returns>
        public static bool AddUser(Model.Tab_user tab_user)
        {
            return DAL.UserAccess.AddUser(tab_user);
        }
       /// <summary>
       /// 登录
       /// </summary>
       /// <param name="u_emaile"></param>
       /// <param name="u_password"></param>
       /// <returns></returns>
        public static bool Login(string u_emaile, string u_password)
        {
            return DAL.UserAccess.Login(u_emaile, u_password);
        }

       /// <summary>
       /// 判断用户是否存在
       /// </summary>
       /// <param name="u_emaile"></param>
       /// <returns></returns>
        public static bool UserIsExist(string u_emaile)
        {
            return DAL.UserAccess.UserIsExist(u_emaile);
        }

       /// <summary>
       /// 根据用户Emaile获取用户
       /// </summary>
       /// <param name="u_emaile"></param>
       /// <returns></returns>
        public static Tab_user GetUserByEmaile(string u_emaile)
        {
            return DAL.UserAccess.GetUserByEmaile(u_emaile);
        }

       /// <summary>
       /// 根据用户昵称获取用户
       /// </summary>
       /// <param name="u_name"></param>
       /// <returns></returns>
        public static Tab_user GetUserByName(string u_name)
        {
            return DAL.UserAccess.GetUserByName(u_name);
        }
       /// <summary>
       /// 修改密码
       /// </summary>
       /// <param name="u_emaile"></param>
       /// <param name="u_password"></param>
       /// <param name="u_newpassword"></param>
       /// <returns></returns>
        public static bool ChangePassword(string u_emaile,string u_password, string u_newpassword)
        {
            string u_NewPassword = GetUserByEmaile(u_emaile).U_password;
            if (u_NewPassword ==u_password)
            {
                return DAL.UserAccess.ChangePassword(u_emaile, u_newpassword);
            }
            return false;

        }

       /// <summary>
       /// 修改登录时间
       /// </summary>
       /// <param name="u_emaile"></param>
       /// <returns></returns>
        public static bool ChangelastLoginTime(string u_emaile)
        {
            return DAL.UserAccess.ChangelastLoginTime(u_emaile);
        }


       /// <summary>
       /// 删除用户
       /// </summary>
       /// <param name="u_emaile"></param>
       /// <returns></returns>
        public static bool DeleteUser(string u_emaile)
        {
            return DAL.UserAccess.DeleteUser(u_emaile);
        }

       /// <summary>
       /// 修改用户头像
       /// </summary>
       /// <param name="u_emaile"></param>
       /// <param name="u_head"></param>
       /// <returns></returns>
        public static bool ChangeUserHead(string u_emaile, string u_head)
        {
            return DAL.UserAccess.ChangeUserHead(u_emaile, u_head);
        }

       /// <summary>
       /// 修改用户昵称
       /// </summary>
       /// <param name="u_emaile"></param>
       /// <param name="u_name"></param>
       /// <returns></returns>
       public static bool ChangeUserName(string u_emaile, string u_name)
        {
            return DAL.UserAccess.ChangeUserName(u_emaile, u_name);
        }

    }
}
