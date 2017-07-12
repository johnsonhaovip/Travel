using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_ChangeTravel : System.Web.UI.Page
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
            
        }
    }

    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        //if(e.CommandName=="tijiao")
        //{
        //    string title = "";
        //    string depart = "";
        //    string destination = "";
        //    string startTime = "";
        //    string sumTime = "";

        //    for (int i = 0; i < this.DataList1.Items.Count; i++)
        //    {
        //        TextBox t_title = ((System.Web.UI.WebControls.TextBox)DataList1.Items[i].FindControl("t_title"));
        //        TextBox t_depart = ((System.Web.UI.WebControls.TextBox)DataList1.Items[i].FindControl("t_depart"));
        //        TextBox t_destination = ((System.Web.UI.WebControls.TextBox)DataList1.Items[i].FindControl("t_destination"));
        //        TextBox t_startTime = ((System.Web.UI.WebControls.TextBox)DataList1.Items[i].FindControl("t_startTime"));
        //        TextBox t_sumTime = ((System.Web.UI.WebControls.TextBox)DataList1.Items[i].FindControl("t_sumTime"));

        //        title = t_title.Text.Trim();//获取值
        //        depart = t_depart.Text.Trim();
        //        destination = t_destination.Text.Trim();
        //        startTime = t_startTime.Text.Trim();
        //        sumTime = t_sumTime.Text.Trim();
        //    }


        //    string u_id = Request.QueryString["u_id"];//从个人资料里获取u_id
        //    int id = Convert.ToInt32(u_id);

        //    Travel.Model.Tab_travel tab_travel = new Travel.Model.Tab_travel();
        //    tab_travel.U_id = id;
        //    tab_travel.T_title = Convert.ToString(title);
        //    tab_travel.T_depart = Convert.ToString(depart);
        //    tab_travel.T_destination = Convert.ToString(destination);
        //    tab_travel.T_startTime = Convert.ToDateTime(startTime);
        //    tab_travel.T_sumTime = Convert.ToInt32(sumTime);


        //    if (Travel.BLL.TravelBusiness.ChangeTravel(tab_travel))
        //    {
        //        Page.ClientScript.RegisterStartupScript(GetType(), "info", "<script>alert('修改行程成功！')</script>");

        //    }
        //    else
        //    {
        //        Page.ClientScript.RegisterStartupScript(GetType(), "info", "<script>alert('失败,请重新尝试！')</script>");

        //    }


        //}
    }
}