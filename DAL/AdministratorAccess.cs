using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Model;
using Travel.DAL;
using System.Data.SqlClient;
using System.Data;

namespace Travel.DAL
{
   public class AdiministratorAccess
    {
       /// <summary>
       /// 判断此管理员是否存在
       /// </summary>
       /// <param name="a_emaile"></param>
       /// <returns></returns>
       public static bool AdminIsExist(string a_emaile)
       {
           SqlParameter[] p = new SqlParameter[]
             {
                  new SqlParameter("@a_emaile",a_emaile)
             };
           int i = Convert.ToInt32(SQLHelper.ExecuteScalar("AdminIsExist", CommandType.StoredProcedure, p));
           return i > 0;
       }

       /// <summary>
       /// 添加管理员
       /// </summary>
       /// <param name="admin"></param>
       /// <returns></returns>
       public static bool AddAdmin(Tab_administrators admin)
       {
           SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@a_emaile",admin.A_emaile),
                new SqlParameter("@a_name",admin.A_password)
             
            };
           int i = SQLHelper.ExecuteNonQuery("AddAdmin", CommandType.StoredProcedure, p);
           return i > 0;
       }

       /// <summary>
       /// 删除管理员
       /// </summary>
       /// <param name="a_emaile"></param>
       /// <returns></returns>
       public static bool DeleteAdmin(Tab_administrators a_emaile)
       {
           SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@a_emaile",a_emaile)
            };
           int i = SQLHelper.ExecuteNonQuery("DeleteAdmin", CommandType.StoredProcedure, p);
           return i > 0;
       }

       /// <summary>
       /// 修改管理员密码
       /// </summary>
       /// <param name="a_emaile"></param>
       /// <param name="a_newpassword"></param>
       /// <returns></returns>
       public static bool ChangeAdminPassword(string a_emaile, string a_newpassword)
       {
           SqlParameter[] p = new SqlParameter[]
          {
              new SqlParameter("@a_emaile",a_emaile),
              new SqlParameter("@a_Newpassword",a_newpassword)
          };
           int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("ChangeAdminPassword", CommandType.StoredProcedure, p));
           return (i > 0);
       }

       /// <summary>
       /// 根据管理员emaile获取管理员信息
       /// </summary>
       /// <param name="a_emaile"></param>
       /// <returns></returns>
       public static Tab_administrators GetAdminByEmaile(string a_emaile)
       {
           SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@a_emaile",a_emaile)
            };
           SqlDataReader dr = SQLHelper.ExecuteReader("GetAdminByEmaile", CommandType.StoredProcedure, p);
           Tab_administrators tab_admin = new Tab_administrators();
           if (dr.Read())
           {
               tab_admin.A_emaile = Convert.ToString(dr["a_emaile"]);
               tab_admin.A_password= Convert.ToString(dr["a_name"]);
               tab_admin.A_id = Convert.ToInt32(dr["a_id"]);
              
           }
           return tab_admin;
       }



       /// <summary>
       /// 获取所有的管理员信息
       /// </summary>
       /// <returns></returns>
       public static List<Tab_administrators> GetAllAdmin()
       {
           SqlDataReader dr = SQLHelper.ExecuteReader("GetAllAdmin", CommandType.StoredProcedure, null);
           List<Tab_administrators> List = new List<Tab_administrators>();
           while (dr.Read())
           {
               Tab_administrators tab_admin = new Tab_administrators();
               tab_admin.A_id= Convert.ToInt32(dr["a_id"]);
               tab_admin.A_emaile= Convert.ToString(dr["a_emaile"]);
               tab_admin.A_password = Convert.ToString(dr["a_password"]);
               List.Add(tab_admin);

           }
           return List;
       }


     
    }
}
