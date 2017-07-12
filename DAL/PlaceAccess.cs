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
   public class PlaceAccess
    {

       /// <summary>
       /// 添加目的地
       /// </summary>
       /// <param name="place"></param>
       /// <returns></returns>
       public static bool AddPlace(Tab_place place)
       {

           SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@u_emaile",place.U_emaile),
                new SqlParameter("@s_place",place.S_place),
                new SqlParameter("@s_picture",place.S_picture),
                new SqlParameter("@s_introduce",place.S_introduce),
                new SqlParameter("@s_type",place.S_type),
                new SqlParameter("@s_ClickNumber",place.S_ClickNumber),
                new SqlParameter("@s_update",place.S_update)

               
            };
           int i = SQLHelper.ExecuteNonQuery("AddPlace", CommandType.StoredProcedure, p);
           return i > 0;
       }


       /// <summary>
       /// 修改地点的点击量
       /// </summary>
       /// <param name="u_id"></param>
       /// <returns></returns>
       public static bool ChangePlaceClickNumber(int u_id)
       {
           SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@u_id",u_id)   
            };
           int i = SQLHelper.ExecuteNonQuery("ChangePlaceClickNumber", CommandType.StoredProcedure, p);
           return i > 0;

       }

    }
}
