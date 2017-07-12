using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Model;
using Travel.DAL;

namespace Travel.BLL
{
    public class DiscussBusiness
    {
        /// <summary>
        /// 删除评论
        /// </summary>
        /// <param name="u_emaileA"></param>
        /// <param name="u_discuss"></param>
        /// <returns></returns>
        public static bool DeleteDiscuss(string u_emaileA, string u_discuss)
        {
            return DAL.DiscussAccess.DeleteDiscuss(u_emaileA, u_discuss);
        }

        /// <summary>
        /// 根据作者emaile获取作者信息
        /// </summary>
        /// <param name="u_emaileA"></param>
        /// <returns></returns>
        public static Tab_discuss GetDiscussByEmaileB(string u_emaileB)
        {
            return DAL.DiscussAccess.GetDiscussByEmaileB(u_emaileB);
        }

        /// <summary>
        /// 添加评论
        /// </summary>
        /// <param name="discuss"></param>
        /// <returns></returns>
        public static bool AddDiscuss(Tab_discuss discuss)
        {
            return DAL.DiscussAccess.AddDiscuss(discuss);
        }

        /// <summary>
        /// 通过id获取评论
        /// </summary>
        /// <param name="u_id"></param>
        /// <returns></returns>
        public static Tab_discuss GetDiscussById(int u_id)
        {
            return DAL.DiscussAccess.GetDiscussById(u_id);
        }

    }
}
