using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Model;

namespace Travel.DAL
{
    /// <summary>
    /// user的业务逻辑层
    /// </summary>
    public class UserAccess
    {
        /// <summary>
        /// 判断用户是否存在
        /// </summary>
        /// <param name="u_emaile"></param>
        /// <returns></returns>
        public static bool UserIsExist(string u_emaile)
        {
            SqlParameter[] p = new SqlParameter[]
             {
                  new SqlParameter("@u_emaile",u_emaile)
             };
            int i = Convert.ToInt32(SQLHelper.ExecuteScalar("UserIsExist", CommandType.StoredProcedure, p));
            return i > 0;
        }


        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool AddUser(Tab_user user)
        {
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@u_emaile",user.U_emaile),
                new SqlParameter("@u_name",user.U_name),
                new SqlParameter("@u_password",user.U_password),
                new SqlParameter("@LastLoginTime",user.LastLoginTime)
               
            };
            int i = SQLHelper.ExecuteNonQuery("AddUser", CommandType.StoredProcedure, p);
            return i > 0;

        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="u_emaile"></param>
        /// <returns></returns>
        public static bool DeleteUser(string u_emaile)
        {
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@u_emaile",u_emaile)
            };
            int i = SQLHelper.ExecuteNonQuery("DeleteUser", CommandType.StoredProcedure, p);
            return i > 0;
        }

        /// <summary>
        /// 根据用户Emaile获取用户信息
        /// </summary>
        /// <param name="u_emaile"></param>
        /// <returns></returns>
        public static Tab_user GetUserByEmaile(string u_emaile)
        {
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@u_emaile",u_emaile)
            };
            SqlDataReader dr = SQLHelper.ExecuteReader("GetUserByEmaile", CommandType.StoredProcedure, p);
            Tab_user tab_user = new Tab_user();
            if (dr.Read())
            {
                tab_user.U_emaile = Convert.ToString(dr["u_emaile"]);
                tab_user.U_name = Convert.ToString(dr["u_name"]);
                tab_user.U_password = Convert.ToString(dr["u_password"]);
                tab_user.U_head = Convert.ToString(dr["u_head"]);
                tab_user.U_message = Convert.ToString(dr["u_message"]);
                tab_user.U_collect = Convert.ToString(dr["u_collect"]);
                tab_user.LastLoginTime = Convert.ToDateTime(dr["LastLoginTime"]);
                tab_user.U_discuss = Convert.ToString(dr["u_discuss"]);
            }
            return tab_user;
        }

        /// <summary>
        /// 根据用户昵称获取用户信息
        /// </summary>
        /// <param name="u_name"></param>
        /// <returns></returns>
        public static Tab_user GetUserByName(string u_name)
        {
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@u_name",u_name)
            };
            SqlDataReader dr = SQLHelper.ExecuteReader("GetUserByName", CommandType.StoredProcedure, p);
            Tab_user tab_user = new Tab_user();
            if (dr.Read())
            {
                tab_user.U_emaile = Convert.ToString(dr["u_emaile"]);
                tab_user.U_name = Convert.ToString(dr["u_name"]);
                tab_user.U_password = Convert.ToString(dr["u_password"]);
                tab_user.U_head = Convert.ToString(dr["u_head"]);
                tab_user.U_message = Convert.ToString(dr["u_message"]);
                tab_user.U_collect = Convert.ToString(dr["u_collect"]);
                tab_user.LastLoginTime = Convert.ToDateTime(dr["LastLoginTime"]);
                tab_user.U_discuss = Convert.ToString(dr["u_discuss"]);
            }
            return tab_user;
        }



        /// <summary>
        /// 修改用户最后登录时间
        /// </summary>
        /// <param name="u_emaile"></param>
        /// <returns></returns>
        public static bool ChangelastLoginTime(string u_emaile)
        {
            SqlParameter[] p = new SqlParameter[]
           {
               new SqlParameter("@u_emaile",u_emaile)
           };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("ChangelastLoginTime", CommandType.StoredProcedure, p));
            return (i > 0);
        }

        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="u_emaile"></param>
        /// <param name="u_newpassword"></param>
        /// <returns></returns>
        public static bool ChangePassword(string u_emaile, string u_newpassword)
        {
            SqlParameter[] p = new SqlParameter[]
          {
              new SqlParameter("@u_emaile",u_emaile),
              new SqlParameter("@u_Newpassword",u_newpassword)
          };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("ChangePassword", CommandType.StoredProcedure, p));
            return (i > 0);
        }


        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        public static List<Tab_user> GetAllUsers()
        {
            SqlDataReader dr = SQLHelper.ExecuteReader("GetAllUsers", CommandType.StoredProcedure, null);
            List<Tab_user> List = new List<Tab_user>();
            while (dr.Read())
            {
               Tab_user tab_user = new Tab_user();
               tab_user.U_emaile= Convert.ToString(dr["u_emaile"]);
               tab_user.U_name= Convert.ToString(dr["u_name"]);
               tab_user.U_password = Convert.ToString(dr["u_password"]);
               tab_user.U_head = Convert.ToString(dr["u_head"]);
               tab_user.U_message = Convert.ToString(dr["u_message"]);
               tab_user.U_collect = Convert.ToString(dr["u_collect"]);
               tab_user.LastLoginTime = Convert.ToDateTime(dr["lastLoginTime"]);
               tab_user.U_discuss = Convert.ToString(dr["u_discuss"]);
               List.Add(tab_user);

            }
            return List;
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="u_emaile"></param>
        /// <param name="u_password"></param>
        /// <returns></returns>
        public static bool Login(string u_emaile, string u_password)
        {
            SqlParameter[] p = new SqlParameter[]
             {
               new SqlParameter("@u_emaile",u_emaile),
               new SqlParameter("@u_password",u_password)
             };
            int i = Convert.ToInt32(SQLHelper.ExecuteScalar("Login", CommandType.StoredProcedure, p));
            return (i > 0);
        }

        /// <summary>
        /// 修改用户头像
        /// </summary>
        /// <param name="u_emaile"></param>
        /// <param name="u_head"></param>
        /// <returns></returns>
        public static bool ChangeUserHead(string u_emaile, string u_head)
        {
            SqlParameter[] p = new SqlParameter[]
          {
              new SqlParameter("@u_emaile",u_emaile),
              new SqlParameter("@u_head",u_head)
          };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("ChangeUserHead", CommandType.StoredProcedure, p));
            return (i > 0);
        }

        /// <summary>
        /// 修改用户昵称
        /// </summary>
        /// <param name="u_emaile"></param>
        /// <param name="u_name"></param>
        /// <returns></returns>
        public static bool ChangeUserName(string u_emaile, string u_name)
        {
            SqlParameter[] p = new SqlParameter[]
          {
              new SqlParameter("@u_emaile",u_emaile),
              new SqlParameter("@u_name",u_name)
          };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("ChangeUserName", CommandType.StoredProcedure, p));
            return (i > 0);
        }




    }
}
