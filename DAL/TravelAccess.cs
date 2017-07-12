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
    public class TravelAccess
    {
        /// <summary>
        /// 判断行程计划是否存在
        /// </summary>
        /// <param name="t_depart"></param>
        /// <returns></returns>
        public static bool TravelIsExist(string t_destination)
        {
            SqlParameter[] p = new SqlParameter[]
             {
                  new SqlParameter("@t_destination", t_destination)
             };
            int i = Convert.ToInt32(SQLHelper.ExecuteScalar("TravelIsExist", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        /// 获取所有的行程
        /// </summary>
        /// <returns></returns>
        public static List<Tab_travel> GetAllTravel()
        {
            SqlDataReader dr = SQLHelper.ExecuteReader("GetAllTravel", CommandType.StoredProcedure, null);
            List<Tab_travel> List = new List<Tab_travel>();
            while (dr.Read())
            {
                Tab_travel tab_travel = new Tab_travel();

                tab_travel.U_emaile = Convert.ToString(dr["u_emaile"]);
                tab_travel.U_name = Convert.ToString(dr["u_name"]);
                tab_travel.T_title = Convert.ToString(dr["t_title"]);
                tab_travel.T_depart = Convert.ToString(dr["t_depart"]);
                tab_travel.T_destination = Convert.ToString(dr["t_destination"]);
                tab_travel.T_day1 = Convert.ToString(dr["t_day1"]);
                tab_travel.T_day2 = Convert.ToString(dr["t_day2"]);
                tab_travel.T_day3 = Convert.ToString(dr["t_day3"]);
                tab_travel.T_day4 = Convert.ToString(dr["t_day4"]);
                tab_travel.T_day5 = Convert.ToString(dr["t_day5"]);
                tab_travel.UploadTime = Convert.ToDateTime(dr["UploadTime"]);
                tab_travel.T_startTime = Convert.ToDateTime(dr["t_startTime"]);
                tab_travel.T_sumTime = Convert.ToInt32(dr["t_sumTime"]);
               
                List.Add(tab_travel);

            }
            return List;
        }


        /// <summary>
        /// 添加行程
        /// </summary>
        /// <param name="travel"></param>
        /// <returns></returns>
        public static bool AddTravel(Tab_travel travel)
        {

            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@u_emaile",travel.U_emaile),
                new SqlParameter("@t_title",travel.T_title),
                new SqlParameter("@t_depart",travel.T_depart),
                new SqlParameter("@t_destination",travel.T_destination),
                new SqlParameter("@UploadTime",travel.UploadTime),
                new SqlParameter("@t_startTime",travel.T_startTime),
                new SqlParameter("@t_sumTime",travel.T_sumTime),
            };
            int i = SQLHelper.ExecuteNonQuery("AddTravel", CommandType.StoredProcedure, p);
            return i > 0;
        }

        /// <summary>
        /// 删除行程
        /// </summary>
        /// <param name="u_emaile"></param>
        /// <returns></returns>
        public static bool DeleteTravel(string u_emaile,string t_title)
        {
            SqlParameter[] p = new SqlParameter[]
            {
                 new SqlParameter("@u_emaile",u_emaile),
                new SqlParameter("@t_title",t_title)
               
            };
            int i = SQLHelper.ExecuteNonQuery("DeleteTravel", CommandType.StoredProcedure, p);
            return i > 0;
        }



        /// <summary>
        /// 根据用户Emaile获取用户行程
        /// </summary>
        /// <param name="u_emaile"></param>
        /// <returns></returns>
        public static Tab_travel GetTravelByEmaile(string u_emaile)
        {
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@u_emaile",u_emaile)
            };
            SqlDataReader dr = SQLHelper.ExecuteReader("GetTravelByEmaile", CommandType.StoredProcedure, p);
            Tab_travel tab_travel = new Tab_travel();
            if (dr.Read())
            {
                tab_travel.U_emaile = Convert.ToString(dr["u_emaile"]);
                tab_travel.U_name = Convert.ToString(dr["u_name"]);
                tab_travel.T_title = Convert.ToString(dr["t_title"]);
                tab_travel.T_depart = Convert.ToString(dr["t_depart"]);
                tab_travel.T_destination = Convert.ToString(dr["t_destination"]);
                tab_travel.T_day1 = Convert.ToString(dr["t_day1"]);
                tab_travel.T_day2 = Convert.ToString(dr["t_day2"]);
                tab_travel.T_day3 = Convert.ToString(dr["t_day3"]);
                tab_travel.T_day4 = Convert.ToString(dr["t_day4"]);
                tab_travel.T_day5 = Convert.ToString(dr["t_day5"]);
                tab_travel.UploadTime = Convert.ToDateTime(dr["UploadTime"]);
                tab_travel.T_startTime = Convert.ToDateTime(dr["t_startTime"]);
                tab_travel.T_sumTime = Convert.ToInt32(dr["t_sumTime"]);
            }
            return tab_travel;
        }

        /// <summary>
        /// 通过id获取行程
        /// </summary>
        /// <param name="u_id"></param>
        /// <returns></returns>
        public static Tab_travel GetTravelByID(int u_id)
        {
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@u_id",u_id)
            };
            SqlDataReader dr = SQLHelper.ExecuteReader("GetTravelByID", CommandType.StoredProcedure, p);
            Tab_travel tab_travel = new Tab_travel();
            if (dr.Read())
            {
                tab_travel.U_emaile = Convert.ToString(dr["u_emaile"]);
                tab_travel.U_name = Convert.ToString(dr["u_name"]);
                tab_travel.T_title = Convert.ToString(dr["t_title"]);
                tab_travel.T_depart = Convert.ToString(dr["t_depart"]);
                tab_travel.T_destination = Convert.ToString(dr["t_destination"]);
                tab_travel.T_day1 = Convert.ToString(dr["t_day1"]);
                tab_travel.T_day2 = Convert.ToString(dr["t_day2"]);
                tab_travel.T_day3 = Convert.ToString(dr["t_day3"]);
                tab_travel.T_day4 = Convert.ToString(dr["t_day4"]);
                tab_travel.T_day5 = Convert.ToString(dr["t_day5"]);
                tab_travel.UploadTime = Convert.ToDateTime(dr["UploadTime"]);
                tab_travel.T_startTime = Convert.ToDateTime(dr["t_startTime"]);
                tab_travel.T_sumTime = Convert.ToInt32(dr["t_sumTime"]);
            }
            return tab_travel;
        }
        /// <summary>
        /// 修改行程
        /// </summary>
        /// <param name="travel"></param>
        /// <returns></returns>
        public static bool ChangeTravel(Tab_travel travel)
        {
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@u_id",travel.U_id),
                new SqlParameter("@t_title",travel.T_title),
                new SqlParameter("@t_depart",travel.T_depart),
                new SqlParameter("@t_destination",travel.T_destination),
                new SqlParameter("@t_day1",travel.T_day1),
                new SqlParameter("@t_day2",travel.T_day2),
                new SqlParameter("@t_day3",travel.T_day3),
                new SqlParameter("@t_day4",travel.T_day4),
                new SqlParameter("@t_day5",travel.T_day5),
                new SqlParameter("@UploadTime",travel.UploadTime),
                new SqlParameter("@t_startTime",travel.T_startTime),
                new SqlParameter("@t_sumTime",travel.T_sumTime)
              
            };
            int i = SQLHelper.ExecuteNonQuery("ChangeTravel", CommandType.StoredProcedure, p);
            return i > 0;

        }


        /// <summary>
        /// 获取最新的行程
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public static List<Tab_travel> GetNewTravel(int count)
        {
            SqlParameter[] p = new SqlParameter[]
          {
           new SqlParameter("@Count",count)
          };

            SqlDataReader dr = SQLHelper.ExecuteReader("GetNewTravel", CommandType.StoredProcedure, p);
            List<Tab_travel> list = new List<Tab_travel>();
            while (dr.Read())
            {
                Tab_travel tab_travel = new Tab_travel();
                tab_travel.U_emaile = Convert.ToString(dr["u_emaile"]);
                tab_travel.U_name = Convert.ToString(dr["u_name"]);
                tab_travel.T_title = Convert.ToString(dr["t_title"]);
                tab_travel.T_depart = Convert.ToString(dr["t_depart"]);
                tab_travel.T_destination = Convert.ToString(dr["t_destination"]);
                tab_travel.T_day1 = Convert.ToString(dr["t_day1"]);
                tab_travel.T_day2 = Convert.ToString(dr["t_day2"]);
                tab_travel.T_day3 = Convert.ToString(dr["t_day3"]);
                tab_travel.T_day4 = Convert.ToString(dr["t_day4"]);
                tab_travel.T_day5 = Convert.ToString(dr["t_day5"]);
                tab_travel.T_startTime = Convert.ToDateTime(dr["t_startTime"]);
                tab_travel.T_sumTime = Convert.ToInt32(dr["t_sumTime"]);

                list.Add(tab_travel);
            }
            return list;
        }
       


    }
}
