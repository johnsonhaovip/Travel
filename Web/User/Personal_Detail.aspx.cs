using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
public partial class User_Personal_Detail : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

        //re_travel.DataSource = Travel.BLL.TravelBusiness.GetNewTravel(5);
        //re_travel.DataBind();

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

        }




    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        this.MultiView1.ActiveViewIndex = 0;

    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        this.MultiView1.ActiveViewIndex = 1;
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        this.MultiView1.ActiveViewIndex = 2;
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        this.MultiView1.ActiveViewIndex = 3;
    }
    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        this.MultiView1.ActiveViewIndex = 4;

    }
    protected void LinkButton7_Click(object sender, EventArgs e)
    {
        this.MultiView1.ActiveViewIndex = 5;
    }
    protected void LinkButton8_Click(object sender, EventArgs e)
    {
        this.MultiView1.ActiveViewIndex = 6;
    }

    /// <summary>
    /// 上传用户头像
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_up_head_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile && Path.GetExtension(FileUpload1.FileName).ToLower() == ".jpg")
        {
            Travel.Model.Tab_user tab_user = new Travel.Model.Tab_user();
            tab_user.U_emaile = Travel.BLL.UserBusiness.GetUserByEmaile(Session["u_emaile"].ToString()).U_emaile;
            tab_user.U_head = "head\\" + Guid.NewGuid().ToString() + ".jpg";

            //再上传到服务器
            FileUpload1.SaveAs(Server.MapPath(tab_user.U_head));

            if (Travel.BLL.UserBusiness.ChangeUserHead(tab_user.U_emaile, tab_user.U_head))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('修改头像成功！')</script>");

            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('修改失败,请重试')</script>");

            }
        }

        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('请先选择jpg文件')</script>");
        }


    }
    /// <summary>
    /// 修改用户昵称
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_chenge_name_Click(object sender, EventArgs e)
    {

        string nameNew = u_nameNew.Text.Trim();
        Travel.Model.Tab_user tab_user = new Travel.Model.Tab_user();
        //通过Session获取用户emaile
        tab_user.U_emaile = Travel.BLL.UserBusiness.GetUserByEmaile(Session["u_emaile"].ToString()).U_emaile;
        if (string.IsNullOrEmpty(nameNew))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('请输入新昵称！')</script>");

        }
        else
        {
            if (Travel.BLL.UserBusiness.ChangeUserName(tab_user.U_emaile, nameNew))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('修改昵称成功！')</script>");
                Response.AddHeader("Refresh", "0");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('修改失败,请重新尝试！')</script>");
            }
        }

    }
    /// <summary>
    /// 修改用户密码
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_change_password_Click(object sender, EventArgs e)
    {
        string password = txt_password.Text.Trim();
        string newpassword = txt_newpassword.Text.Trim();

        Travel.Model.Tab_user tab_user = new Travel.Model.Tab_user();
        //通过Session获取用户emaile
        tab_user.U_emaile = Travel.BLL.UserBusiness.GetUserByEmaile(Session["u_emaile"].ToString()).U_emaile;

        if (string.IsNullOrEmpty(newpassword))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('新密码不能为空')</script>");

        }
        else
        {

            if (password == newpassword)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('两次密码相同SB')</script>");

            }
            else
            {
                if (Travel.BLL.UserBusiness.ChangePassword(tab_user.U_emaile, password, newpassword))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('修改密码成功！请记住新密码')</script>");
                    Response.AddHeader("Refresh", "0");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('修改失败,请重新尝试！')</script>");
                }
            }

        }

    }


    /// <summary>
    /// 我的行程修改和删除
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {


        if (e.CommandName == "delete")
        {
            string u_id = e.CommandArgument.ToString();
            Session["u_id"] = u_id;

            Travel.Model.Tab_user tab_user = new Travel.Model.Tab_user();
            Travel.Model.Tab_travel tab_travel = new Travel.Model.Tab_travel();
            //通过Session获取用户行程标题
            tab_travel.T_title = Travel.BLL.TravelBusiness.GetTravelByID(Convert.ToInt32(Session["u_id"])).T_title;
            //通过Session获取用户emaile
            tab_user.U_emaile = Travel.BLL.UserBusiness.GetUserByEmaile(Session["u_emaile"].ToString()).U_emaile;

          

            //调用数据库里的删除行程的存储过程
            if(Travel.BLL.TravelBusiness.DeleteTravel(tab_user.U_emaile, tab_travel.T_title))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('删除行程成功!')</script>");
                Response.AddHeader("Refresh", "0");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('删除行程失败!')</script>");

            }

        }
        if (e.CommandName == "change")
        {
            //通过commandArgument传参数过来
            string u_id = Convert.ToString(e.CommandArgument);

            Session["u_id"] = u_id;
            Response.Redirect("ChangeTravel.aspx?u_id=" + Session["u_id"]);
           
        }

    }

    /// <summary>
    /// 我的游记修改和删除
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    protected void DataList2_ItemCommand(object source, DataListCommandEventArgs e)
    {
        
        if (e.CommandName == "delete")
        {
            string u_id= e.CommandArgument.ToString();
            Session["u_id"] = u_id;

            Travel.Model.Tab_user tab_user = new Travel.Model.Tab_user();
            Travel.Model.Tab_article tab_article = new Travel.Model.Tab_article();
        

            //通过Session获取游记title
            tab_article.T_title = Travel.BLL.ArticleBusiness.GetArticleById(Convert.ToInt32( Session["u_id"])).T_title;

            //通过Session获取用户emaile
            tab_user.U_emaile = Travel.BLL.UserBusiness.GetUserByEmaile(Session["u_emaile"].ToString()).U_emaile;
            //调用数据库里的删除游记的存储过程
           if( Travel.BLL.ArticleBusiness.DeleteArticle(tab_user.U_emaile, tab_article.T_title))
           {
               Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('删除游记成功!')</script>");
               Response.AddHeader("Refresh", "0");
           }
           else
           {
               Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('删除游记失败!')</script>");

           }
         

        }
        if (e.CommandName == "change")
        {
            //通过commandArgument传参数过来
            string u_id=Convert.ToString( e.CommandArgument);
            Session["u_id"] = u_id;
            Response.Redirect("ChangeArticle.aspx?u_id="+Session["u_id"]);
            
        }

    }
    /// <summary>
    /// 我的收藏删除
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    protected void DataList3_ItemCommand(object source, DataListCommandEventArgs e)
    {

        if (e.CommandName == "delete")
        {
            string u_id = e.CommandArgument.ToString();
            Session["u_id"] = u_id;

            Travel.Model.Tab_user tab_user = new Travel.Model.Tab_user();

            Travel.Model.Tab_collect tab_collect = new Travel.Model.Tab_collect();
            ////通过Session获取用户的 u_collect
            tab_collect.U_collect = Travel.BLL.CollectBusiness.GetCollectById(Convert.ToInt32(Session["u_id"])).U_emaile;
            //通过Session获取用户emaile
            tab_user.U_emaile = Travel.BLL.UserBusiness.GetUserByEmaile(Session["u_emaile"].ToString()).U_emaile;
            //Travel.Model.Tab_collect tc = Travel.BLL.CollectBusiness.GetCollectByEmaile(Session["u_emaile"].ToString());

            //tab_collect.U_collect = tc.U_emaile;

            //调用数据库里的删除收藏的存储过程
           if( Travel.BLL.CollectBusiness.DeleteCollect(tab_user.U_emaile, tab_collect.U_collect))
           {
               Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('删除收藏成功!')</script>");
               Response.AddHeader("Refresh", "0");
           }
           else
           {
               Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('删除收藏失败!')</script>");

           }

            

        }
    }

    /// <summary>
    /// 我的评论删除
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    protected void DataList4_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            string u_id = e.CommandArgument.ToString();
            Session["u_id"] = u_id;

            Travel.Model.Tab_user tab_user = new Travel.Model.Tab_user();
            Travel.Model.Tab_discuss tab_discuss = new Travel.Model.Tab_discuss();
            //通过Session获取用户emaile
            tab_user.U_emaile = Travel.BLL.UserBusiness.GetUserByEmaile(Session["u_emaile"].ToString()).U_emaile;
            //通过Session获取用户的 u_discuss

            //tab_discuss.U_discuss = Travel.BLL.DiscussBusiness.GetDiscussByEmaileB(Session["u_emaile"].ToString()).U_discuss;
            tab_discuss.U_discuss = Travel.BLL.DiscussBusiness.GetDiscussById(Convert.ToInt32(Session["u_id"])).U_discuss;
            //调用数据库里的删除评论的存储过程

            if(Travel.BLL.DiscussBusiness.DeleteDiscuss(tab_user.U_emaile, tab_discuss.U_discuss))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('删除评论成功!')</script>");
                Response.AddHeader("Refresh", "0");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('删除评论失败!')</script>");

            }
            this.MultiView1.ActiveViewIndex = 3;
        }
    }



}