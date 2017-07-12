using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Model;
using Travel.DAL;


namespace Travel.DAL
{
    public class DiscussAccess
    {
        /// <summary>
        /// 根据用户Emaile获取评论
        /// </summary>
        /// <param name="u_emaileA"></param>
        /// <returns></returns>
        public static Tab_discuss GetDiscussByEmaileB(string u_emaileB)
        {
            SqlParameter[] p = new SqlParameter[]
        {
          new SqlParameter("@u_emaileB",u_emaileB)
        };

            SqlDataReader dr = SQLHelper.ExecuteReader("GetDiscussByEmaile", CommandType.StoredProcedure, p);
            Tab_discuss tab_discuss = new Tab_discuss();
            if (dr.Read())
            {
                tab_discuss.U_id = Convert.ToInt32(dr["u_id"]);
                tab_discuss.U_emaileA = Convert.ToString(dr["u_emaileA"]);
                tab_discuss.U_emaileB = Convert.ToString(dr["u_emaileB"]);
                tab_discuss.U_discuss = Convert.ToString(dr["u_discuss"]);
                tab_discuss.UploadTime = Convert.ToDateTime(dr["UploadTime"]);

            }
            return tab_discuss;
        }

        /// <summary>
        /// 通过id获取评论
        /// </summary>
        /// <param name="u_id"></param>
        /// <returns></returns>
        public static Tab_discuss GetDiscussById(int u_id)
        {
            SqlParameter[] p = new SqlParameter[]
        {
          new SqlParameter("@u_id",u_id)
        };

            SqlDataReader dr = SQLHelper.ExecuteReader("GetDiscussById", CommandType.StoredProcedure, p);
            Tab_discuss tab_discuss = new Tab_discuss();
            if (dr.Read())
            {
                tab_discuss.U_id = Convert.ToInt32(dr["u_id"]);
                tab_discuss.U_emaileA = Convert.ToString(dr["u_emaileA"]);
                tab_discuss.U_emaileB = Convert.ToString(dr["u_emaileB"]);
                tab_discuss.U_discuss = Convert.ToString(dr["u_discuss"]);
                tab_discuss.UploadTime = Convert.ToDateTime(dr["UploadTime"]);

            }
            return tab_discuss;
        }

        /// <summary>
        /// 删除评论
        /// </summary>
        /// <param name="u_emaileA"></param>
        /// <param name="u_discuss"></param>
        /// <returns></returns>
        public static bool DeleteDiscuss(string u_emaileB, string u_discuss)
        {
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@u_emaileB",u_emaileB),
                new SqlParameter("@u_discuss",u_discuss)
            };
            int i = SQLHelper.ExecuteNonQuery("DeleteDiscuss", CommandType.StoredProcedure, p);
            return i > 0;

        }


        /// <summary>
        /// 添加评论
        /// </summary>
        /// <param name="discuss"></param>
        /// <returns></returns>
        public static bool AddDiscuss(Tab_discuss discuss)
        {
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@u_discuss",discuss.U_discuss),
                new SqlParameter("@u_emaileA",discuss.U_emaileA),
                new SqlParameter("@u_emaileB",discuss.U_emaileB),
                new SqlParameter("@UploadTime",discuss.UploadTime),
            };
            int i = SQLHelper.ExecuteNonQuery("AddDiscuss", CommandType.StoredProcedure, p);
            return i > 0;

        }

    }
}
