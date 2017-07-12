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
    /// <summary>
    /// 游记article的业务逻辑层
    /// </summary>
    public class ArticleAccess
    {
        /// <summary>
        /// 判断游记是否存在
        /// </summary>
        /// <param name="art_title"></param>
        /// <returns></returns>
        public static bool ArticleIsExist(string t_title)
        {
            SqlParameter[] p = new SqlParameter[]
             {
                  new SqlParameter("@t_title",t_title)
             };
            int i = Convert.ToInt32(SQLHelper.ExecuteScalar("ArticleIsExist", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        /// 添加游记
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        public static bool AddArticle(Tab_article article)
        {
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@u_emaile",article.U_emaile),
                new SqlParameter("@t_title",article.T_title),
                new SqlParameter("@t_content",article.T_content),
                new SqlParameter("@art_illustration",article.Art_illustration),
                new SqlParameter("@UploadTime",article.UploadTime),
                new SqlParameter("@art_ClickNumber",article.Art_ClickNumber)
            };
            int i = SQLHelper.ExecuteNonQuery("AddArticle", CommandType.StoredProcedure, p);
            return i > 0;

        }

        /// <summary>
        /// 修改游记的点击量
        /// </summary>
        /// <param name="art_title"></param>
        /// <returns></returns>
        public static bool ChangeClickNumber(int u_id)
        {
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@u_id",u_id)   
            };
            int i = SQLHelper.ExecuteNonQuery("ChangeClickNumber", CommandType.StoredProcedure, p);
            return i > 0;

        }


        /// <summary>
        /// 修改游记
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        public static bool ChangeArticle(Tab_article article)
        {
            SqlParameter[] p = new SqlParameter[]
          {
                new SqlParameter("u_id",article.U_id),
                new SqlParameter("@t_title",article.T_title),
                new SqlParameter("@t_content",article.T_content),
                new SqlParameter("@UploadTime",article.UploadTime),
                new SqlParameter("@art_ClickNumber",article.Art_ClickNumber)
          };
            int i =SQLHelper.ExecuteNonQuery("ChangeArticle", CommandType.StoredProcedure, p);
            return (i > 0);
        }

        /// <summary>
        /// 删除游记
        /// </summary>
        /// <param name="u_emaile"></param>
        /// <returns></returns>
        public static bool DeleteArticle(string u_emaile,string t_title)
        {
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@u_emaile",u_emaile),
                new SqlParameter("@t_title",t_title)
                
            };
            int i = SQLHelper.ExecuteNonQuery("DeleteArticle", CommandType.StoredProcedure, p);
            return i > 0;
        }



        /// <summary>
        /// 获取所有的游记
        /// </summary>
        /// <returns></returns>
        public static List<Tab_article> GetAllArticle()
        {
            SqlDataReader dr = SQLHelper.ExecuteReader("GetAllArticle", CommandType.StoredProcedure, null);
            List<Tab_article> List = new List<Tab_article>();
            while (dr.Read())
            {
                Tab_article tab_article = new Tab_article();

                tab_article.U_name = Convert.ToString(dr["u_name"]);
                tab_article.U_emaile = Convert.ToString(dr["u_emaile"]);
                tab_article.T_title = Convert.ToString(dr["t_title"]);
                tab_article.T_content = Convert.ToString(dr["t_content"]);
                tab_article.Art_illustration = Convert.ToString(dr["art_illustration"]);
                tab_article.D_emaile = Convert.ToString(dr["d_emaile"]);
                tab_article.D_name = Convert.ToString(dr["d_name"]);
                tab_article.UploadTime = Convert.ToDateTime(dr["UploadTime"]);
                tab_article.Art_discuss = Convert.ToString(dr["art_discuss"]);
                tab_article.Art_ClickNumber = Convert.ToInt32(dr["art_ClickNumber"]);
                List.Add(tab_article);

            }
            return List;
        }


        /// <summary>
        /// 获取几首游记
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public static List<Tab_article> GetArticle(int count)
        {
            SqlParameter[] p = new SqlParameter[]
          {
           new SqlParameter("@Count",count)
          };

            SqlDataReader dr = SQLHelper.ExecuteReader("GetArticle", CommandType.StoredProcedure, p);
            List<Tab_article> list = new List<Tab_article>();
            while (dr.Read())
            {
                Tab_article tab_article = new Tab_article();
                tab_article.U_id = Convert.ToInt32(dr["u_id"]);
                tab_article.U_name = Convert.ToString(dr["u_name"]);
                tab_article.U_emaile = Convert.ToString(dr["u_emaile"]);
                tab_article.T_title = Convert.ToString(dr["t_title"]);
                tab_article.T_content = Convert.ToString(dr["t_content"]);
                tab_article.Art_illustration = Convert.ToString(dr["art_illustration"]);
                tab_article.D_emaile = Convert.ToString(dr["d_emaile"]);
                tab_article.D_name = Convert.ToString(dr["d_name"]);
                tab_article.UploadTime = Convert.ToDateTime(dr["UploadTime"]);
                tab_article.Art_discuss = Convert.ToString(dr["art_discuss"]);
                tab_article.Art_ClickNumber = Convert.ToInt32(dr["art_ClickNumber"]);
                list.Add(tab_article);
            }
            return list;
        }

        /// <summary>
        /// 根据用户Emaile获取游记
        /// </summary>
        /// <param name="u_emaile"></param>
        /// <returns></returns>
        public static Tab_article GetArticleByEmaile(string u_emaile)
        {
            SqlParameter[] p = new SqlParameter[]
        {
          new SqlParameter("@u_emaile",u_emaile)
        };

            SqlDataReader dr = SQLHelper.ExecuteReader("GetArticleByEmaile", CommandType.StoredProcedure, p);
            Tab_article tab_article = new Tab_article();
            if (dr.Read())
            {

                tab_article.U_id = Convert.ToInt32(dr["u_id"]);
                tab_article.U_name = Convert.ToString(dr["u_name"]);
                tab_article.U_emaile = Convert.ToString(dr["u_emaile"]);
                tab_article.T_title = Convert.ToString(dr["t_title"]);
                tab_article.T_content = Convert.ToString(dr["t_content"]);
                tab_article.Art_illustration = Convert.ToString(dr["art_illustration"]);
                tab_article.D_emaile = Convert.ToString(dr["d_emaile"]);
                tab_article.D_name = Convert.ToString(dr["d_name"]);
                tab_article.UploadTime = Convert.ToDateTime(dr["UploadTime"]);
                tab_article.Art_discuss = Convert.ToString(dr["art_discuss"]);
                tab_article.Art_ClickNumber = Convert.ToInt32(dr["art_ClickNumber"]);

            }
            return tab_article;
        }

        /// <summary>
        /// 根据id获取游记
        /// </summary>
        /// <param name="u_id"></param>
        /// <returns></returns>
        public static Tab_article GetArticleById(int  u_id)
        {
            SqlParameter[] p = new SqlParameter[]
        {
          new SqlParameter("@u_id",u_id)
        };

            SqlDataReader dr = SQLHelper.ExecuteReader("GetArticleById", CommandType.StoredProcedure, p);
            Tab_article tab_article = new Tab_article();
            if (dr.Read())
            {

                tab_article.U_id = Convert.ToInt32(dr["u_id"]);
                tab_article.U_name = Convert.ToString(dr["u_name"]);
                tab_article.U_emaile = Convert.ToString(dr["u_emaile"]);
                tab_article.T_title = Convert.ToString(dr["t_title"]);
                tab_article.T_content = Convert.ToString(dr["t_content"]);
                tab_article.Art_illustration = Convert.ToString(dr["art_illustration"]);
                tab_article.D_emaile = Convert.ToString(dr["d_emaile"]);
                tab_article.D_name = Convert.ToString(dr["d_name"]);
                tab_article.UploadTime = Convert.ToDateTime(dr["UploadTime"]);
                tab_article.Art_discuss = Convert.ToString(dr["art_discuss"]);
                tab_article.Art_ClickNumber = Convert.ToInt32(dr["art_ClickNumber"]);

            }
            return tab_article;
        }


        /// <summary>
        /// 根据游记题目获取游记
        /// </summary>
        /// <param name="t_title"></param>
        /// <returns></returns>
        public static Tab_article GetArticleByTitle(string t_title)
        {
            SqlParameter[] p = new SqlParameter[]
        {
          new SqlParameter("@t_title",t_title)
        };

            SqlDataReader dr = SQLHelper.ExecuteReader("GetArticleByTitle", CommandType.StoredProcedure, p);
            Tab_article tab_article = new Tab_article();
            if (dr.Read())
            {

                tab_article.U_id = Convert.ToInt32(dr["u_id"]);
                tab_article.U_name = Convert.ToString(dr["u_name"]);
                tab_article.U_emaile = Convert.ToString(dr["u_emaile"]);
                tab_article.T_title = Convert.ToString(dr["t_title"]);
                tab_article.T_content = Convert.ToString(dr["t_content"]);
                tab_article.Art_illustration = Convert.ToString(dr["art_illustration"]);
                tab_article.D_emaile = Convert.ToString(dr["d_emaile"]);
                tab_article.D_name = Convert.ToString(dr["d_name"]);
                tab_article.UploadTime = Convert.ToDateTime(dr["UploadTime"]);
                tab_article.Art_discuss = Convert.ToString(dr["art_discuss"]);
                tab_article.Art_ClickNumber = Convert.ToInt32(dr["art_ClickNumber"]);

            }
            return tab_article;
        }



        /// <summary>
        /// 根据作者获取游记
        /// </summary>
        /// <param name="u_id"></param>
        /// <returns></returns>
        public static List<Tab_article> GetArticleByUserID(int u_id)
        {
            SqlParameter[] p = new SqlParameter[]
           {
             new SqlParameter("@u_id",u_id)
           };
            List<Tab_article> list = new List<Tab_article>();
            SqlDataReader dr = SQLHelper.ExecuteReader("GetArticleByUserID", CommandType.StoredProcedure, p);
            while (dr.Read())
            {
                Tab_article tab_article = new Tab_article();

                tab_article.U_id = Convert.ToInt32(dr["u_id"]);
                tab_article.U_name = dr["u_name"].ToString();
                tab_article.U_emaile = dr["u_emaile"].ToString();
                tab_article.T_title = Convert.ToString(dr["t_title"]);
                tab_article.T_content = Convert.ToString(dr["t_content"]);
                tab_article.Art_illustration = dr["art_illustration"].ToString();
                tab_article.D_emaile = Convert.ToString(dr["d_emaile"]);
                tab_article.UploadTime = Convert.ToDateTime(dr["UploadTime"]);
                tab_article.D_name = dr["d_name"].ToString();
                tab_article.Art_discuss = dr["art_discuss"].ToString();
                tab_article.Art_ClickNumber = (int)(dr["art_ClickNumber"]);

                list.Add(tab_article);
            }
            return list;
        }


        /// <summary>
        /// 根据游记id获取游记
        /// </summary>
        /// <param name="u_id"></param>
        /// <returns></returns>
        /// 
        public static Tab_article GetArctileById(int u_id)
        {
            SqlParameter[] p = new SqlParameter[]
        {
          new SqlParameter("@u_id",u_id)
        };

            SqlDataReader dr = SQLHelper.ExecuteReader("GetArctileById", CommandType.StoredProcedure, p);
            Tab_article tab_article = new Tab_article();
            if (dr.Read())
            {

                tab_article.U_id = Convert.ToInt32(dr["u_id"]);
                tab_article.U_name = Convert.ToString(dr["u_name"]);
                tab_article.U_emaile = Convert.ToString(dr["u_emaile"]);
                tab_article.T_title = Convert.ToString(dr["t_title"]);
                tab_article.T_content = Convert.ToString(dr["t_content"]);
                tab_article.Art_illustration = Convert.ToString(dr["art_illustration"]);
                tab_article.D_emaile = Convert.ToString(dr["d_emaile"]);
                tab_article.D_name = Convert.ToString(dr["d_name"]);
                tab_article.UploadTime = Convert.ToDateTime(dr["UploadTime"]);
                tab_article.Art_discuss = Convert.ToString(dr["art_discuss"]);
                tab_article.Art_ClickNumber = Convert.ToInt32(dr["art_ClickNumber"]);

            }
            return tab_article;
        }

    }
}
