using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.BLL;
using Travel.DAL;
using Travel.Model;

namespace Travel.BLL
{
    /// <summary>
    /// 游记的数据访问层
    /// </summary>
    public class ArticleBusiness
    {
        /// <summary>
        /// 判断游记是否存在
        /// </summary>
        /// <param name="art_title"></param>
        /// <returns></returns>
        public static bool ArticleIsExist(string t_title)
        {
            return DAL.ArticleAccess.ArticleIsExist(t_title);
        }

        /// <summary>
        /// 添加游记
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        public static bool AddArticle(Tab_article article)
        {
            return DAL.ArticleAccess.AddArticle(article);

        }
        /// <summary>
        /// 获取所有的游记
        /// </summary>
        /// <returns></returns>
        public static List<Tab_article> GetAllArticle()
        {
            return DAL.ArticleAccess.GetAllArticle();
        }

        /// <summary>
        /// 修改游记的点击量
        /// </summary>
        /// <param name="art_title"></param>
        /// <returns></returns>
        public static bool ChangeClickNumber(int u_id)
        {
            return DAL.ArticleAccess.ChangeClickNumber(u_id);
        }

        /// <summary>
        /// 修改游记
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        public static bool ChangeArticle(Tab_article article)
        {
            return DAL.ArticleAccess.ChangeArticle(article);
        }

        /// <summary>
        /// 根据用户邮箱删除游记
        /// </summary>
        /// <param name="u_emaile"></param>
        /// <returns></returns>
        public static bool DeleteArticle(string u_emaile, string t_title)
        {
            return DAL.ArticleAccess.DeleteArticle(u_emaile, t_title);
        }

        /// <summary>
        /// 根据用户邮箱获取他所写的游记
        /// </summary>
        /// <param name="u_emaile"></param>
        /// <returns></returns>
        public static Tab_article GetArticleByEmaile(string u_emaile)
        {
            return DAL.ArticleAccess.GetArticleByEmaile(u_emaile);
        }


        /// <summary>
        /// 根据游记题目获取游记
        /// </summary>
        /// <param name="art_title"></param>
        /// <returns></returns>
        public static Tab_article GetArticleByTitle(string t_title)
        {
            return DAL.ArticleAccess.GetArticleByTitle(t_title);
        }


        /// <summary>
        /// 根据用户ID获取用户游记
        /// </summary>
        /// <param name="u_id"></param>
        /// <returns></returns>
        public static List<Tab_article> GetArticleByUserID(int u_id)
        {
            return DAL.ArticleAccess.GetArticleByUserID(u_id);
        }

        /// <summary>
        /// 获取几个游记
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public static List<Tab_article> GetArticle(int count)
        {
            return DAL.ArticleAccess.GetArticle(count);
        }
        /// <summary>
        /// 根据id获取游记
        /// </summary>
        /// <param name="u_id"></param>
        /// <returns></returns>
        public static Tab_article GetArctileById(int u_id)
        {
            return DAL.ArticleAccess.GetArctileById(u_id);
        }


        /// <summary>
        /// 根据ID 获取游记
        /// </summary>
        /// <param name="u_id"></param>
        /// <returns></returns>
        public static Tab_article GetArticleById(int u_id)
        {
            return DAL.ArticleAccess.GetArctileById(u_id);
        }
    }
}
