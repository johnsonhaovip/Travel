using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Article : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        string str = "";
        if (Convert.ToString(Session["u_emaile"]) == str)
        {
            (Master.FindControl("lab_denglu") as Button).Text = "登录";
            (Master.FindControl("lab_loginoff") as Button).Visible = false;
        }
        else
        {
            //把用户登录后session 交给登录按钮
            (Master.FindControl("lab_denglu") as Button).Text = Convert.ToString(Session["u_emaile"]);
            (Master.FindControl("lab_loginoff") as Button).Visible = true;
            (Master.FindControl("lab_loginoff") as Button).Text = "注销";
            string u_id = Request.QueryString["u_id"];//从个人资料里获取u_id
            Session["u_id"] = u_id;//将u_id保存在session中
            
        }


        rp_Arctile.DataSource = Travel.BLL.ArticleBusiness.GetArticle(6);
        rp_Arctile.DataBind();

    }
 
    protected void Unnamed_ServerClick(object sender, EventArgs e)
    {
        Travel.Model.Tab_article tab_article = new Travel.Model.Tab_article();

        Travel.Model.Tab_collect tab_collect = new Travel.Model.Tab_collect();

        tab_collect.U_emaile = Convert.ToString(Session["u_emaile"]);//将session中的emaile交给
        //tab_collect.U_emaile = "1550940391@qq.com";
        string  title = Convert.ToString(((System.Web.UI.HtmlControls.HtmlAnchor)sender).HRef);
        Session["t_title"] = title;
        //直接将文章的标题交给收藏
        tab_collect.U_collect = Travel.BLL.ArticleBusiness.GetArticleByTitle(Session["t_title"].ToString()).T_title;

        tab_collect.T_content = Travel.BLL.ArticleBusiness.GetArticleByTitle(Session["t_title"].ToString()).T_content;

        tab_collect.UploadTime = Travel.BLL.ArticleBusiness.GetArticleByTitle(Session["t_title"].ToString()).UploadTime;


          if (string.IsNullOrEmpty(tab_collect.U_emaile))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('请先登录！')</script>");
                //跳转到指定界面
                Response.Redirect("Login.aspx");

            }
            else
            {
                if (string.IsNullOrEmpty(tab_collect.T_content) || string.IsNullOrEmpty(tab_collect.U_collect))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('数据错误！')</script>");
                }
                else
                {
                    if (Travel.BLL.CollectBusiness.AddCollect(tab_collect))
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('收藏成功！')</script>");

                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('请重新尝试！')</script>");

                    }
                }
            }

        }
    


    /// <summary>
    /// 截取字段
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public string foramtstr(string s)
    {
        if(s.Length>35){
            return s.Substring(0, 55) + "..";
        }
        return s;
    }


}