using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Model;
using Travel.DAL;

namespace Travel.BLL
{
    /// <summary>
    /// collect的数据访问层
    /// </summary>
    public class CollectBusiness
    {
        /// <summary>
        /// 删除收藏
        /// </summary>
        /// <param name="u_emaile"></param>
        /// <returns></returns>
        public static bool DeleteCollect(string u_emaile, string u_collect)
        {
            return DAL.CollectAccess.DeleteCollect(u_emaile, u_collect);
        }

        /// <summary>
        /// 根据u_emaile获取用户的收藏
        /// </summary>
        /// <param name="u_emaile"></param>
        /// <returns></returns>
        public static Tab_collect GetCollectByEmaile(string u_emaile)
        {
            return DAL.CollectAccess.GetCollectByEmaile(u_emaile);
        }

        /// <summary>
        /// 添加收藏
        /// </summary>
        /// <param name="collect"></param>
        /// <returns></returns>
        public static bool AddCollect(Tab_collect collect)
        {
            return DAL.CollectAccess.AddCollect(collect);
        }

        /// <summary>
        /// 根据id获取收藏
        /// </summary>
        /// <param name="u_id"></param>
        /// <returns></returns>
        public static Tab_collect GetCollectById(int u_id)
        {
            return DAL.CollectAccess.GetCollectById(u_id);
        }
    }
}
