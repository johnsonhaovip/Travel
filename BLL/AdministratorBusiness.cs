using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.DAL;
using Travel.BLL;
using Travel.Model;

namespace Travel.BLL
{
  public class AdministratorBusiness
    {
      /// <summary>
      /// 判断管理员是否存在
      /// </summary>
      /// <param name="a_emaile"></param>
      /// <returns></returns>
       public static bool AdminIsExist(string a_emaile)
        {
            return DAL.AdiministratorAccess.AdminIsExist(a_emaile);
       }

      /// <summary>
      /// 添加管理员
      /// </summary>
      /// <param name="admin"></param>
      /// <returns></returns>
       public static bool AddAdmin(Tab_administrators admin)
       {
           return DAL.AdiministratorAccess.AddAdmin(admin);

       }

      /// <summary>
      /// 删除管理员
      /// </summary>
      /// <param name="a_emaile"></param>
      /// <returns></returns>
       public static bool DeleteAdmin(Tab_administrators a_emaile)
       {
           return DAL.AdiministratorAccess.DeleteAdmin(a_emaile);

       }
      /// <summary>
      /// 根据管理员emaile获取管理员信息
      /// </summary>
      /// <param name="a_emaile"></param>
      /// <returns></returns>
       public static Tab_administrators GetAdminByEmaile(string a_emaile)
       {
           return DAL.AdiministratorAccess.GetAdminByEmaile(a_emaile);
       }

      /// <summary>
      /// 修改管理员密码
      /// </summary>
      /// <param name="a_emaile"></param>
      /// <param name="a_password"></param>
      /// <param name="a_newpassword"></param>
      /// <returns></returns>
       public static bool ChangeAdminPassword(string a_emaile, string a_password, string a_newpassword)
       {
           string u_NewPassword = GetAdminByEmaile(a_emaile).A_password;
           if (u_NewPassword == a_password)
           {
               return DAL.AdiministratorAccess.ChangeAdminPassword(a_emaile, a_newpassword);
           }
           return false;
       }

      /// <summary>
      /// 获取所有的管理员
      /// </summary>
      /// <returns></returns>
       public static List<Tab_administrators> GetAllAdmin()
       {
           return DAL.AdiministratorAccess.GetAllAdmin();
       }
       

    }
}
