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
    /// <summary>
    /// collect的业务逻辑层
    /// </summary>
    /// <returns></returns>
   public  class CollectAccess
    {
    /// <summary>
    ///  删除收藏
    /// </summary>
    /// <param name="u_emaile"></param>
    /// <param name="u_collect"></param>
    /// <returns></returns>
       public static bool DeleteCollect(string u_emaile, string u_collect)
       {
           SqlParameter[] p = new SqlParameter[]
           {
               new SqlParameter("@u_emaile",u_emaile),
               new SqlParameter("@u_collect",u_collect)
           };
           int i = SQLHelper.ExecuteNonQuery("DeleteCollect", CommandType.StoredProcedure, p);
           return i > 0;
       }

       /// <summary>
       /// 根据u_emaile获取用户的收藏
       /// </summary>
       /// <param name="u_emaile"></param>
       /// <returns></returns>
       public static Tab_collect GetCollectByEmaile(string u_emaile)
       {
           SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@u_emaile",u_emaile)
            };
           SqlDataReader dr = SQLHelper.ExecuteReader("GetCollectByEmaile", CommandType.StoredProcedure, p);
           Tab_collect tab_collect = new Tab_collect();
         
           if (dr.Read())
           {
               tab_collect.U_id = Convert.ToInt32(dr["u_id"]);
               tab_collect.U_emaile = Convert.ToString(dr["u_emaile"]);
               tab_collect.U_emaile = Convert.ToString(dr["u_collect"]);
               tab_collect.T_content = Convert.ToString(dr["t_content"]);
               
           }
           return tab_collect;
       }

       public static bool AddCollect(Tab_collect collect)
       {
           SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@u_emaile",collect.U_emaile),
                new SqlParameter("@u_collect",collect.U_collect),
                new SqlParameter("@t_content",collect.T_content),
               
                new SqlParameter("@UploadTime",collect.UploadTime)
            };
           int i = SQLHelper.ExecuteNonQuery("AddCollect", CommandType.StoredProcedure, p);
           return i > 0;

       }


       public static Tab_collect GetCollectById(int u_id)
       {
           SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@u_id",u_id)
            };
           SqlDataReader dr = SQLHelper.ExecuteReader("GetCollectById", CommandType.StoredProcedure, p);
           Tab_collect tab_collect = new Tab_collect();

           if (dr.Read())
           {
               tab_collect.U_id = Convert.ToInt32(dr["u_id"]);
               tab_collect.U_emaile = Convert.ToString(dr["u_emaile"]);
               tab_collect.U_emaile = Convert.ToString(dr["u_collect"]);
               tab_collect.T_content = Convert.ToString(dr["t_content"]);

           }
           return tab_collect;
       }

     
    }
}
