using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Travel.BLL;
using Travel.DAL;
using Travel.Model;
using AjaxControlToolkit;

public partial class User_Route : System.Web.UI.Page
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


    protected void btn_search_Click(object sender, EventArgs e)
    {

        Session["t_destination"] = txt_search.Text.Trim();//并将目标地交给Session,方便调用
        lab_place.Text = txt_search.Text.Trim();//将用户输入的地点交给右边的地点导航,方便搜索

    }
    protected void btn_sure_Click(object sender, EventArgs e)
    {
        string title = tx_title.Text.Trim();//旅行名字
        string depart = tx_depart.Text.Trim();//获取出发地
        string destination = tx_destination.Text.Trim();//从地图上获取目的地
        string sumtime = tx_sumTime.Text.Trim();//获取旅行的天数
        string starttime = tx_startTime.Text.Trim();//获取开始旅行的时间

        Travel.Model.Tab_user tab_user = new Travel.Model.Tab_user();
        Travel.Model.Tab_travel tab_travel = new Travel.Model.Tab_travel();

        //通过Session将emaile和ID交给tab_travel对象
        tab_travel.U_emaile = Travel.BLL.UserBusiness.GetUserByEmaile(Session["u_emaile"].ToString()).U_emaile;//获取用户emaile
        
        if (string.IsNullOrEmpty(tab_travel.U_emaile))
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "info", "<script>alert('请先登录！')</script>");
            //跳转到指定界面
            Response.Redirect("Login.aspx");
        }

        else
        {

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(depart) || string.IsNullOrEmpty(destination) || string.IsNullOrEmpty(sumtime) || string.IsNullOrEmpty(starttime))
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "info", "<script>alert('请先填写完整数据！')</script>");
            }
            else
            {
                int sumTime = Convert.ToInt32(sumtime);
                DateTime startTime = Convert.ToDateTime(starttime);
                tab_travel.T_title = title;
                tab_travel.T_depart = depart;//将其交给它
                tab_travel.T_destination = destination;
                tab_travel.T_sumTime = sumTime;
                tab_travel.T_startTime = startTime;
                tab_travel.UploadTime = Convert.ToDateTime(DateTime.Now.ToString());


                if (Travel.BLL.TravelBusiness.TravelIsExist(destination))
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "info", "<script>alert('您已经有该行程！')</script>");
                }

                else
                {
                    if (Travel.BLL.TravelBusiness.AddTravel(tab_travel))
                    {

                        Page.ClientScript.RegisterStartupScript(GetType(), "info", "<script>alert('添加行程成功！')</script>");
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "info", "<script>alert('添加行程失败！')</script>");
                    }
                }

            }
        }







    }

}