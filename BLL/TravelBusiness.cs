using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.DAL;
using Travel.Model;
using Travel.BLL;

namespace Travel.BLL
{

    /// <summary>
    /// 行程的数据访问层
    /// </summary>
    public class TravelBusiness
    {
        /// <summary>
        /// 根据出发地判断是否有行程
        /// </summary>
        /// <param name="t_depart"></param>
        /// <returns></returns>
        public static bool TravelIsExist(string t_destination)
        {
            return DAL.TravelAccess.TravelIsExist(t_destination);
        }

        /// <summary>
        /// 添加行程
        /// </summary>
        /// <param name="travel"></param>
        /// <returns></returns>
        public static bool AddTravel(Tab_travel travel)
        {
            return DAL.TravelAccess.AddTravel(travel);
        }

        /// <summary>
        /// 删除行程
        /// </summary>
        /// <param name="u_emaile"></param>
        /// <returns></returns>
        public static bool DeleteTravel(string u_emaile, string t_title)
        {
            return DAL.TravelAccess.DeleteTravel(u_emaile, t_title);
        }

        /// <summary>
        /// 根据用户Emaile获取行程
        /// </summary>
        /// <param name="u_emaile"></param>
        /// <returns></returns>
        public static Tab_travel GetTravelByEmaile(string u_emaile)
        {
            return DAL.TravelAccess.GetTravelByEmaile(u_emaile);
        }

        /// <summary>
        /// 修改行程
        /// </summary>
        /// <param name="travel"></param>
        /// <returns></returns>
        public static bool ChangeTravel(Tab_travel travel)
        {
            return DAL.TravelAccess.ChangeTravel(travel);
        }

        /// <summary>
        /// 获取所有的行程
        /// </summary>
        /// <returns></returns>
        public static List<Tab_travel> GetAllTravel()
        {
            return DAL.TravelAccess.GetAllTravel();
        }

        /// <summary>
        /// 获取最新行程
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public static List<Tab_travel> GetNewTravel(int count)
        {
            return DAL.TravelAccess.GetNewTravel(count);
        }
        /// <summary>
        /// 通过id获取行程
        /// </summary>
        /// <param name="u_id"></param>
        /// <returns></returns>
         public static Tab_travel GetTravelByID(int u_id)
        {
            return DAL.TravelAccess.GetTravelByID(u_id);
        }

    }
}
